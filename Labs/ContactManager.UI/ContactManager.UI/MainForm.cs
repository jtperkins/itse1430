using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
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

        private void OnContactCreate(object sender, EventArgs e)
        {
            // display UI
            var form = new ContactForm();

            // modal
            while (true)
            {
                //Modal
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                //Add
                try
                {
                    //Anything in here that raises an exception will
                    //be sent to the catch block
                    OnSafeAdd(form);
                    break;
                }
                //catch (InvalidOperationException)
                //{
                //    MessageBox.Show(this, "Choose a better game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                catch (Exception ex)
                {
                    //Recover from errors
                    DisplayError(ex);
                };
            };

            BindList();
        }



        private void OnSafeAdd(ContactForm form)
        {
            try
            {
                // adds Character from Character form
                _contacts.Add(form.Contact);
            }
            catch (NotImplementedException e)
            {
                //Rewriting an exception
                throw new Exception("Not implemented yet", e);
            }
            catch (Exception e)
            {
                //Log a message 

                //Rethrow exception - wrong way
                //throw e;
                throw;
            };
        }

        private void BindList()
        {
            // clear all items in ListBox
            _listContacts.Items.Clear();

            // display the name of the Character
            _listContacts.DisplayMember = nameof(Contact.Name);

            // sort
            var items = _contacts.GetAll();
            items = items.OrderBy(GetName);

            // add all Contacts to ListBox
            _listContacts.Items.AddRange(items.ToArray());
        }

        private string GetName(Contact contact)
        {
            return contact.Name;
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private ContactDatabase _contacts = new ContactDatabase();

    }
}
