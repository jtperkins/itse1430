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
                
            }
        }

        private void BindList()
        {
            // clear all items in ListBox
            _listContacts.Items.Clear();
            _listMessages.Text = "";

            //if (_messages.Any())
            //{
            //    foreach (var item in _messages)
            //    {
            //        _sender.Send(item);
            //    }
            //}

            // display the name of the Character
            _listContacts.DisplayMember = nameof(Contact.Name);


            //_listMessages.DisplayMember = nameof(Message.Subject);
            //_listMessages.DisplayMember = nameof(Message.Body);
            

            // sort
            var items = _contacts.GetAll();
            items = items.OrderBy(GetName);

            var messages = _sender.GetAll();

            // add all Contacts to ListBox
            _listContacts.Items.AddRange(items.ToArray());

            foreach (var item in messages)
            {
                _listMessages.Text += "To: " + item.Contact.Email + "\r\n";
                _listMessages.Text += "Subject: " + item.Subject + "\r\n";
                _listMessages.Text += "Body: " + item.Body + "\r\n\r\n";
            }
            
            //_listMessages.Items.AddRange(messages.ToArray());
            //_listMessages.Items.AddRange(_messages.ToArray());
        }

        private string GetName(Contact contact)
        {
            return contact.Name;
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private IContactDatabase _contacts = new FileContactDatabase("contacts.dat");
        private List<Message> _messages = new List<Message>();
        private MessageService _sender = new MessageService();
        

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
                    //UpdateGame(game, form.Game);            
                    _contacts.Update(contact.Id, form.Contact);
                    break;
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                };
            };

            BindList();
        }

        private Contact GetSelectedContact()
        {
            //var value = _listContacts.SelectedItem;

            //C-style cast - don't do this
            //var game = (Game)value;

            //Preferred - null if not valid
            //var game = value as Contact;

            //Type check
            //var game2 = (value is Contact) ? (Contact)value : null;

            return _listContacts.SelectedItem as Contact;
        }

        private Contact OnContactSelected(object sender, EventArgs e)
        {
            return null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            };
            base.OnFormClosing(e);
        }

        protected override void OnLoad( EventArgs e )
        {
            //base.OnLoad(e);
            BindList();
        }

        private void OnContactDelete( object sender, EventArgs e )
        {
            var selected = GetSelectedContact();
            if (selected == null)
                return;

            if (MessageBox.Show(this, $"Are your sure you want to delete {selected.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            
            try
            {
                _contacts.Delete(selected.Id);
            } catch (Exception ex)
            {
                DisplayError(ex);
            };
            BindList();
        }


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
                    //Anything in here that raises an exception will
                    //be sent to the catch block
                    //OnSafeAddMessage(form);
                    _sender.Send(form.Message);
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

        private void OnContactDoubleClicked(object sender, EventArgs e)
        {

            var lb = sender as ListBox;


            if (lb.SelectedItem != null)
            {
                OnContactEdit(sender, e);
            }
        }
    }
}
