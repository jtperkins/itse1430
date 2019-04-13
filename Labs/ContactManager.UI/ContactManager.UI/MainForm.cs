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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactManager.FileSystem;

namespace ContactManager.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// closes the program
        /// </summary>
        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Opens the AboutBox
        /// </summary>
        private void OnHelpAbout(object sender, EventArgs e)
        {
            var form = new AboutBox();

            form.ShowDialog();
        }

        /// <summary>
        /// opens the ContactForm asking for user input
        /// </summary>
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
                catch (Exception ex)
                {
                    //Recover from errors
                    DisplayError(ex);
                };
            };

            BindList();
        }


        /// <summary>
        /// safely add the Contact to the database
        /// </summary>
        /// <param name="form"></param>
        private void OnSafeAdd(ContactForm form)
        {
            try
            {
                // adds Character from Character form
                _contacts.Add(form.Contact);
            }
            catch (Exception e)
            {
                //recover
                DisplayError(e);
            };
        }

        /// <summary>
        /// safely send the Message
        /// </summary>
        private void OnSafeSend( MessageForm form )
        {
            // i think you wanted us to do the way where we do 
            MessageService sender = new MessageService();

            try
            {
                // "send message"
                sender.Send(form.Message);
            } catch (ArgumentNullException e)
            {
                //recover
                DisplayError(e);
            }
        }

        /// <summary>
        /// Binds the Messages and Contacts to the UI, clearing each time and adding them all back
        /// </summary>
        private void BindList()
        {
            // clear all items in ListBox and TextBox
            _listContacts.Items.Clear();
            _listMessages.Text = "";

            // display the name of the Contact
            _listContacts.DisplayMember = nameof(Contact.Name);

            // sort
            var items = _contacts.GetAll();
            items = items.OrderBy(GetName);

            var messages = _sender.GetAll();

            // add all Contacts to ListBox
            _listContacts.Items.AddRange(items.ToArray());

            // add all Messages to TextBox
            foreach (var item in messages)
            {
                _listMessages.Text += "To: " + item.Contact.Email + "\r\n";
                _listMessages.Text += "Subject: " + item.Subject + "\r\n";
                _listMessages.Text += "Body: " + item.Body + "\r\n\r\n";
            }
            
        }

        /// <summary>
        /// returns the name of the Contact
        /// </summary>
        private string GetName(Contact contact)
        {
            return contact.Name;
        }

        /// <summary>
        /// Displays and given errors Message
        /// </summary>
        /// <param name="ex"></param>
        private void DisplayError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// gets selected contact to be edited and opens ContactForm
        /// </summary>
        private void OnContactEdit(object sender, EventArgs e)
        {
            var form = new ContactForm();
            form.Text = "Edit Contact";
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            // Contact to edit
            form.Contact = contact;

            while (true)
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {            
                    _contacts.Update(contact.Id, form.Contact);
                    break;
                }
                catch (Exception ex)
                {
                    //recover
                    DisplayError(ex);
                };
            };
            BindList();
        }

        /// <summary>
        /// returns the selected contact from ListBox
        /// </summary>
        private Contact GetSelectedContact()
        {
            return _listContacts.SelectedItem as Contact;
        }

        /// <summary>
        /// make sure the user meant to leave the form
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            };
            base.OnFormClosing(e);
        }

        /// <summary>
        /// load the Contacts from file database OnLoad
        /// </summary>
        protected override void OnLoad( EventArgs e )
        {
            BindList();
        }

        /// <summary>
        /// gets the selected contact and deletes it
        /// </summary>
        private void OnContactDelete( object sender, EventArgs e )
        {
            var selected = GetSelectedContact();
            if (selected == null)
                return;

            // make sure user meant to delete the Contact
            if (MessageBox.Show(this, $"Are your sure you want to delete {selected.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            
            // safely delete by id
            try
            {
                _contacts.Delete(selected.Id);
            } catch (Exception ex)
            {
                //recover
                DisplayError(ex);
            };
            BindList();
        }

        /// <summary>
        /// Button control to open the MessageForm
        /// </summary>
        private void OnSendMessage( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)      
                return;
                
            var form = new MessageForm();

            form.Contact = contact;

            while (true)
            {
                //Modal
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                //Add
                try
                {
                    // "send" the message. I dont think im doing this how yoou intended
                    _sender.Send(form.Message);
                    break;
                }
                catch (Exception ex)
                {
                    //Recover from errors
                    DisplayError(ex);
                };
            };
            BindList();
        }

        /// <summary>
        /// edit the contact information on double click
        /// </summary>
        private void OnContactDoubleClicked(object sender, EventArgs e)
        {
            var lb = sender as ListBox;

            if (lb.SelectedItem != null)
            {
                // send the click event to the menu event
                OnContactEdit(sender, e);
            }
        }

        private IContactDatabase _contacts = new FileContactDatabase("contacts.dat");
        private List<Message> _messages = new List<Message>();
        private MessageService _sender = new MessageService();
    }
}
