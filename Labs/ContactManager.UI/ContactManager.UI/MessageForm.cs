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
        public Contact Contact { get; set; }
        public Message Message { get; set; }
        public MessageForm()
        {
            InitializeComponent();
        }

        private Message SaveData()
        {
            var message = new Message();

            message.Contact = Contact;
            message.Subject = _txtSubject.Text;
            message.Body = _txtBody.Text;

            return message;
        }

        private void LoadData( Contact contact )
        {
            _txtContact.Text = contact.Name;
            _txtEmail.Text = contact.Email;
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if (Contact != null)
                LoadData(Contact);
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;


            var message = SaveData();

            try
            {
                ObjectValidator.Validate(message);
            } catch (ValidationException ex)
            {
                DisplayError(ex);
                return;
            }

            Message = message;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DisplayError( Exception ex )
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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

        private void OnValidateBody(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var tb = sender as TextBox;

            if (tb.Text.Length == 0)
            {
                _error.SetError(tb, "Body is required.");
                e.Cancel = true;
            }
            else
                _error.SetError(tb, "");
        }

    }
}
