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

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// closes the form when user clicks File/Exit or Alt+F4
        /// </summary>
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        /// <summary>
        /// opens the About form that displays the lab, class and author information
        /// </summary>
        private void OnHelpAbout( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog();
        }

        /// <summary>
        /// opens the Character Form to create a new Character
        /// </summary>
        private void OnCharacterNew( object sender, EventArgs e )
        {
            // display UI
            var form = new CharacterForm();

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
                //catch (InvalidOperationException)
                //{
                //    MessageBox.Show(this, "Choose a better game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                catch (Exception ex)
                {
                    //Recover from errors
                    DisplayError(ex);
                };
            };

            // bind list to ListBox
            BindList();
        }

        /// <summary>
        /// displays the raised exception
        /// </summary>
        private void DisplayError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// bind list to ListBox. clears intems already there and adds all current items back in to support deleting and creating Character
        /// </summary>
        private void BindList()
        {
            // clear all items in ListBox
            _listCharacters.Items.Clear();

            // display the name of the Character
            _listCharacters.DisplayMember = nameof(Character.Name);
            
            // add all Characters to ListBox
            _listCharacters.Items.AddRange(_characters.GetAll());
        }

        /// <summary>
        /// OnLoad bind the current list of Characters to ListBox. if none adds none
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnSafeAdd(CharacterForm form)
        {
            try
            {
                // adds Character from Character form
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

        /// <summary>
        /// faux CharacterDatabase for MainForm
        /// </summary>
        private CharacterDatabase _characters = new CharacterDatabase();

        /// <summary>
        /// grabs the character that is selected from ListBox to edit or delete the appropriate Character
        /// </summary>
        /// <returns>Selected Character</returns>
        private Character GetSelectedCharacter()
        {
            return _listCharacters.SelectedItem as Character;
        }

        /// <summary>
        /// opens the CharacterForm after user selects the character and chooses the appropriate menu item or hotkey
        /// </summary>
        private void OnGameEdit( object sender, EventArgs e )
        {
            // opens character form
            var form = new CharacterForm();

            // change title of Form to edit
            form.Text = "Edit Character";

            //make sure we're editing appropriate Character, if no Character, return
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            // Character to edit
            form.Character = character;

            while (true)
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                // try to update the Character 
                try
                {          
                    _characters.Update(character.Id, form.Character);
                    break;
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                };
            };

            BindList();
        }

        /// <summary>
        /// deletes the chosen Character with menu item or appropriate hotkey
        /// </summary>
        private void OnCharacterDelete(object sender, EventArgs e)
        {
            // get selected Character, if any
            var selected = GetSelectedCharacter();
            if (selected == null)
                return;

            // display confirmation
            if (MessageBox.Show(this, $"Are you sure you want to delete {selected.Name}?",
                               "Confirm Delete", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // attempt to delete the Character
            try
            {
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
