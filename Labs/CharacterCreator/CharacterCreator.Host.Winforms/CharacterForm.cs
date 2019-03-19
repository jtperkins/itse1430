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

        /// <summary>
        /// Function called when user tries to save the character. checks for validation and if validated, saves the character
        /// </summary>
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

        /// <summary>
        /// closes the character form when user clicks the cancel button, does not save any data
        /// </summary>
        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// loads UI with Character
        /// </summary>
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

        /// <summary>
        /// saves UI into new Character
        /// </summary>
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

        /// <summary>
        /// Init UI if editing a game
        /// </summary>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
                LoadData(Character);
        }

        /// <summary>
        /// validates the _txtName field
        /// </summary>
        private void OnValidateName( object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Name is required");
            } else
                _error.SetError(tb, "");
        }

        /// <summary>
        /// validates _raceBox ComboBox
        /// </summary>
        private void OnValidateRace( object sender, CancelEventArgs e )
        {
            var tb = sender as ComboBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Race is required");
            } else
                _error.SetError(tb, "");
        }

        /// <summary>
        /// validates _professionBox ComboBox
        /// </summary>
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
