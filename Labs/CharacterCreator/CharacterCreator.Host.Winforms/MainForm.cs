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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {
            var form = new AboutBox();
            form.ShowDialog();
        }

        private void f(object sender, KeyPressEventArgs e)
        {
            var form = new AboutBox();
            form.ShowDialog();
        }

        private void OnCharacterNew(object sender, EventArgs e)
        {
            // display UI
            var form = new CharacterForm();

            // modeless
            // form.Show();

            // modal
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            // if ok then add to system
            //_character = form.Character;
        }
    }
}
