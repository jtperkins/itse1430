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
    }
}
