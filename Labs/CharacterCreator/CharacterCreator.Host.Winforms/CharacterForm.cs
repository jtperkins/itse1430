using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Host.Winforms
{
    public partial class CharacterForm : Form
    {
        /// <summary>
        /// gets or sets the property being edited
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// allows adding or editing a character
        /// </summary>
        public CharacterForm()
        {
            InitializeComponent();
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;


            var character = SaveData();

            try
            {
                character.Validate(character);
            } catch(Exception ex)
            {
                _attributesError.SetError(_attributesLabel, "You only have 300 points to spend");
                return;
            }
            
            Character = character;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Error(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Name is required");
            } else
                _error.SetError(tb, "");
            
        }

        //private decimal ReadDecimal( TextBox control )
        //{
        //    if (Decimal.TryParse(control.Text, out var value))
        //        return value;

        //    return -1;
        //}

        //Loads UI with game
        private void LoadData( Character character )
        {
            _txtName.Text = character.Name;
            _raceBox.Text = character.Race;
            _professionBox.Text = character.Profession;
            _strength.Value = character.Strength;
            _intelligence.Value = character.Intellect;
            _agility.Value = character.Agility;
            _constitution.Value = character.Constitution;
            _charisma.Value = character.Charisma;
            _description.Text = character.Description;
        }

        //Saves UI into new game
        private Character SaveData()
        {
            var character = new Character();
   
            character.Name = _txtName.Text;
            character.Race = _raceBox.Text;
            character.Profession = _professionBox.Text;
            character.Strength = (int)_strength.Value;
            character.Intellect = (int)_intelligence.Value;
            character.Agility = (int)_agility.Value;
            character.Constitution = (int)_constitution.Value;
            character.Charisma = (int)_charisma.Value;
            character.Description = _description.Text;
            
            return character;
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //Init UI if editing a game
            if (Character != null)
                LoadData(Character);
        }

        private void OnValidateName( object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Name is required");
            } else
                _error.SetError(tb, "");
        }

        private void OnValidateRace( object sender, CancelEventArgs e )
        {
            var tb = sender as ComboBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Race is required");
            } else
                _error.SetError(tb, "");
        }

        private void OnValidateProfession( object sender, CancelEventArgs e )
        {
            var tb = sender as ComboBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Profession is required");
            } else
                _error.SetError(tb, "");
        }
    }
}
