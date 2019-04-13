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
    public partial class MessageForm : Form
    {
        /// <summary>
        /// Contact the Message is to be sent to
        /// </summary>
        public Contact Contact { get; set; }
        /// <summary>
        /// Message to be sent
        /// </summary>
        public Message Message { get; set; }

        public MessageForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// saves the data in the form
        /// </summary>
        /// <returns>the Message thats created from user input</returns>
        private Message SaveData()
        {
            var message = new Message();

            /// grab the info from form
            message.Contact = Contact;
            message.Subject = _txtSubject.Text;
            message.Body = _txtBody.Text;

            return message;
        }

        /// <summary>
        /// load contact to be edited in appropriate fields
        /// </summary>
        private void LoadData( Contact contact )
        {
            _txtContact.Text = contact.Name;
            _txtEmail.Text = contact.Email;
        }

        /// <summary>
        /// load the Contact information into appropirate field on Form load
        /// </summary>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if (Contact != null)
                LoadData(Contact);
        }

        /// <summary>
        /// EventHandler for Save button
        /// </summary>
        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var message = SaveData();

            // validation
            try
            {
                ObjectValidator.Validate(message);
            } catch (ValidationException ex)
            {
                // recover
                DisplayError(ex);
                return;
            }

            Message = message;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// EventHandler for cancel button. closes form without validation
        /// </summary>
        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // diaplsy any given Exceptions Error to user
        private void DisplayError( Exception ex )
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// proper ErrorProvider validation warning
        /// </summary>
        private void OnValidateSubject(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var tb = sender as TextBox;

            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Subject is required.");
                e.Cancel = true;
            }
            else
                _error.SetError(tb, "");
        }
    }
}
