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
        public CharacterForm()
        {
            InitializeComponent();
        }

        private void OnNameLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_txtName.SelectedText))
            {
                _nameLabel.Visible = true;
            }
            else
            {
                
            }
        }
    }
}
