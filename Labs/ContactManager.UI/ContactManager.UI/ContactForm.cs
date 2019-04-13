/**********************************************************
 * 
 * Taylor Perkins
 * ITSE 1430
 * 4/13/2019
 * 
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class ContactForm : Form
    {
        public Contact Contact { get; set; }

        public ContactForm()
        {
            InitializeComponent();
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;


            var contact = SaveData();

            try
            {
                ObjectValidator.Validate(contact);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(this, "Email not valid", "Error", MessageBoxButtons.OK);
                return;
            }

            Contact = contact;
            DialogResult = DialogResult.OK;
            Close();

        }

        private Contact SaveData()
        {
            var contact = new Contact();

            contact.Name = _txtName.Text;
            contact.Email = _txtEmail.Text;

            return contact;
        }

        private void LoadData(Contact contact)
        {
            _txtName.Text = contact.Name;
            _txtEmail.Text = contact.Email;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Contact != null)
                LoadData(Contact);
        }

        private void OnValidateName(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Name is required");
            }
            else
                _error.SetError(tb, "");
        }

        private void OnValidateEmail(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Email is required");
            }
            else
            {
                if (IsValidEmail(tb.Text))
                    _error.SetError(tb, "");
                else
                    _error.SetError(tb, "Invalid email format");
            }
                
        }

        private bool IsValidEmail(string source)
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            }
            catch
            { };

            return false;
        }

    }
}
