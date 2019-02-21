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

        public Character Character { get; set; }
        public CharacterForm()
        {
            InitializeComponent();
        }

        private void OnNameLeave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_txtName.SelectedText))
            {
                _nameLabel.Visible = true;
            }
            
        }

        private decimal ReadDecimal( TextBox control )
        {
            if (Decimal.TryParse(control.Text, out var value))
                return value;

            return -1;
        }

        //Loads UI with game
        private void LoadData( Character character )
        {
            //_txtName.Text = game.Name;
            //_txtPublisher.Text = game.Publisher;
            //_txtPrice.Text = game.Price.ToString();
            //_cbOwned.Checked = game.Owned;
            //_cbCompleted.Checked = game.Completed;
        }

        //Saves UI into new game
        private Character SaveData()
        {
            var character = new Character();
            //game.Name = _txtName.Text;
            //game.Publisher = _txtPublisher.Text;
            //game.Price = ReadDecimal(_txtPrice);
            //game.Owned = _cbOwned.Checked;
            //game.Completed = _cbCompleted.Checked;

            return character;
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //Init UI if editing a game
            if (Character != null)
                LoadData(Character);
        }
    }
}
