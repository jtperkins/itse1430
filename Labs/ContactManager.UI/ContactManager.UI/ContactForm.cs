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
        /// <summary>
        /// Contact to be created or loaded into UI
        /// </summary>
        public Contact Contact { get; set; }

        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnSave when the user clicks the save button, create the Contact
        /// </summary>
        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            // actually grab the data and "save" it
            var contact = SaveData();

            // validation
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

        /// <summary>
        /// actually "saves" the data, creating and returning a new Contact
        /// </summary>
        /// <returns>reutnrs a new Contact based on the user input</returns>
        private Contact SaveData()
        {
            var contact = new Contact();

            contact.Name = _txtName.Text;
            contact.Email = _txtEmail.Text;

            return contact;
        }

        /// <summary>
        /// loads the contact information in the the appropriate fields
        /// </summary>
        private void LoadData(Contact contact)
        {
            _txtName.Text = contact.Name;
            _txtEmail.Text = contact.Email;
        }

        /// <summary>
        /// cancel button for the user to quit with no validation
        /// </summary>
        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// override of forms OnLoad, so we can load appropriate information OnEdit
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Contact != null)
                LoadData(Contact);
        }

        /// <summary>
        /// proper validation to set the ErrorProvider on leaving Name field
        /// </summary>
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

        /// <summary>
        /// proper validation to set the ErrorProvider on leaving Email field
        /// </summary>
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

        /// <summary>
        /// checks the validity of the email. not true validation, it seems to only check for an @ symbol
        /// </summary>
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
