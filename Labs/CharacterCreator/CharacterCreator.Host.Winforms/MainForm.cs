using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CharacterCreator.Character;
using System.Windows.Input;
using CharacterCreator;

namespace CharacterCreator.Host.Winforms
{
    public partial class MainForm : Form
    {
        private Character _character = new Character();
        //private Character[] _characters = new Character[100];
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog();
        }

        //private void f( object sender, KeyPressEventArgs e )
        //{
           
        //    var form = new AboutBox();
        //    form.ShowDialog();
        //}

        private void OnCharacterNew( object sender, EventArgs e )
        {
            // display UI
            var form = new CharacterForm();

            // modeless
            // form.Show();

            // modal
            while(true)
            {
                //Modal
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                //Add
                try
                {
                    //Anything in here that raises an exception will
                    //be sent to the catch block

                    OnSafeAdd(form);
                    break;
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show(this, "Choose a better game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    //Recover from errors
                    DisplayError(ex);
                };
            };

            BindList();

            // if ok then add to system
            //_character = form.Character;

            //TODO: New
            //_characters[GetNextEmptyCharacter()] = new Character();
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //HACK: find first spot in array with no game
        //private int GetNextEmptyCharacter()
        //{
        //    for (var index = 0; index < _characters.Length; ++index)
        //        if (_characters[index] == null)
        //            return index;
        //    return -1;
        //}

        private void OnCharacterSelected( object sender, EventArgs e )
        {

        }


        //private void UpdateGame( Character oldGame, Character newGame )
        //{
        //    for (var index = 0; index < _characters.Length; ++index)
        //    {
        //        if (_characters[index] == oldGame)
        //        {
        //            _characters[index] = newGame;
        //            break;
        //        };
        //    };
        //}

        //private void OnCharacterDelete( object sender, EventArgs e )
        //{
        //    //Get selected game, if any
        //    var selected = GetSelectedCharacter();
        //    if (selected == null)
        //        return;

        //    //Display confirmation
        //    if (MessageBox.Show(this, $"Are you sure you want to delete {selected.Name}?",
        //                       "Confirm Delete", MessageBoxButtons.YesNo,
        //                       MessageBoxIcon.Question) != DialogResult.Yes)
        //        return;

        //    //TODO: Delete
        //    DeleteGame(selected);
        //    BindList();
        //}

        //private void DeleteGame( Character character )
        //{
        //    for (var index = 0; index < _characters.Length; ++index)
        //    {
        //        if (_characters[index] == character)
        //        {
        //            _characters[index] = null;
        //            break;
        //        };
        //    };
        //}


        private void BindList()
        {
            // Bind games to listbox
            _listCharacters.Items.Clear();

            _listCharacters.DisplayMember = nameof(Character.Name);

            //Can use AddRange now that we don't care about null items
            _listCharacters.Items.AddRange(_characters.GetAll());

            //_listCharacter
            //foreach (var character in _characters)
            //{
            //    if (character != null)
            //        _listCharacters.Items.Add(character);
            //}
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindList();
        }

        private void OnSafeAdd(CharacterForm form)
        {
            try
            {
                //_games[GetNextEmptyGame()] = form.Game;
                _characters.Add(form.Character);
            }
            catch (NotImplementedException e)
            {
                //Rewriting an exception
                throw new Exception("Not implemented yet", e);
            }
            catch (Exception e)
            {
                //Log a message 

                //Rethrow exception - wrong way
                //throw e;
                throw;
            };
        }

        private CharacterDatabase _characters = new CharacterDatabase();

        private Character GetSelectedCharacter()
        {

            var value = _listCharacters.SelectedItem;

            // C-style cast - dont do this
            //var game = (Character)value;

            var game = value as Character;

            //type check
            //var game = (value is Character) ? (Character)value : null;

            return _listCharacters.SelectedItem as Character;
        }

        private void OnGameEdit( object sender, EventArgs e )
        {

            var form = new CharacterForm();
            form.Text = "Edit Character";
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            //Game to edit
            form.Character = character;

            while (true)
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //UpdateGame(game, form.Game);            
                    _characters.Update(character.Id, form.Character);
                    break;
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                };
            };

            BindList();
            //var form = new CharacterForm();

            //var character = GetSelectedCharacter();
            //if (character == null)
            //    return;

            //// Characterx` to edit
            //form.Character = character;

            //if (form.ShowDialog(this) != DialogResult.OK)
            //    return;

            ////TODO: Fix to edit, not add
            //UpdateGame(character, form.Character);
            //BindList();
        }

        private void OnCharacterDelete(object sender, EventArgs e)
        {
            //Get selected game, if any
            var selected = GetSelectedCharacter();
            if (selected == null)
                return;

            //Display confirmation
            if (MessageBox.Show(this, $"Are you sure you want to delete {selected.Name}?",
                               "Confirm Delete", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                //DeleteGame(selected);
                _characters.Delete(selected.Id);
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            };
            BindList();
        }
    }
}
