/**********************************************************
 * 
 * Taylor Perkins
 * ITSE 1430
 * 4/13/2019
 * 
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.FileSystem
{
    public class FileContactDatabase : IContactDatabase
    {
        /// <summary>
        /// takes a string representing the name of a file to write to. this represents a "database" via external file.
        /// </summary>
        /// <param name="fileName">the name of the file to write to</param>
        public FileContactDatabase( string fileName )
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (fileName == "")
                throw new ArgumentException("File Name can't be empty.", nameof(fileName));

            _fileName = fileName;
        }

        /// <summary>
        /// adds a Contact to the file "database"
        /// </summary>
        /// <param name="contact">Contact to be added</param>
        public Contact Add( Contact contact )
        {
            var contacts = GetAll().ToList();

            // find the largest id and increment by 1
            if (contacts.Any())
                contact.Id = contacts.Max(x => x.Id) + 1;
            else
                contact.Id = 1;

            contacts.Add(contact);

            SaveContacts(contacts);

            return contact;
        }

        /// <summary>
        /// deletes the Contact by id
        /// </summary>
        /// <param name="id">id of the Contact to be deleted</param>
        public void Delete( int id )
        {
            var contacts = GetAll().ToList();

            var contact = contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                SaveContacts(contacts);
            }

        }

        /// <summary>
        /// returns a Contact in the database via id
        /// </summary>
        /// <param name="id">id of the contact to get</param>
        public Contact Get( int id )
        {
            if (!File.Exists(_fileName))
                return null;

            using (StreamReader reader = File.OpenText(_fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var contact = LoadContact(line);
                    if (contact.Id == id)
                        return contact;
                }

                return null;
            }
        }

        /// <summary>
        /// returns an IEnumerable of Contacts in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetAll()
        {
            if (File.Exists(_fileName))
            {
                // read all at once
                foreach (var line in File.ReadAllLines(_fileName))
                {
                    var contact = LoadContact(line);
                    if (contact != null)
                        yield return contact;
                };
            }
        }

        /// <summary>
        /// loads the contacts from the file "database"
        /// </summary>
        private Contact LoadContact( string line )
        {
            if (String.IsNullOrEmpty(line))
                return null;

            var fields = line.Split(',');
            if (fields.Length != 3)
                return null;

            return new Contact
            {
                Id = Int32.Parse(fields[0]),
                Name = fields[1],
                Email = fields[2]
            };
        }

        /// <summary>
        /// writes the Contact information in the file "database"
        /// </summary>
        /// <param name="contact">Contact to be written to file</param>
        /// <returns></returns>
        private string SaveContact(Contact contact)
        {
            return String.Join(",", contact.Id, contact.Name, contact.Email);
        }

        /// <summary>
        /// writes all the contacts to the file "database"
        /// </summary>
        private void SaveContacts ( IEnumerable<Contact> contacts)
        {
            var lines = from contact in contacts
                        select SaveContact(contact);
            File.WriteAllLines(_fileName, lines);
        }

        /// <summary>
        /// Takes a Contact and id of the contact and updates its properties. Returns updated Contact
        /// </summary>
        public Contact Update( int id, Contact contact )
        {
            var contacts = GetAll().ToList();

            var existing = contacts.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                contacts.Remove(existing);
                contact.Id = id;
                contacts.Add(contact);

                SaveContacts(contacts);
            }

            return contact;
        }

        /// <summary>
        /// the name of the file. dont want to accidentally change it
        /// </summary>
        private readonly string _fileName;
    }
}
