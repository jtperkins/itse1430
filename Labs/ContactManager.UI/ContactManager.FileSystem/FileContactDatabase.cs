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
        public FileContactDatabase( string fileName )
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (fileName == "")
                throw new ArgumentException("File Name can't be empty.", nameof(fileName));

            _fileName = fileName;
        }

        private readonly string _fileName;
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

        private string SaveContact(Contact contact)
        {
            return String.Join(",", contact.Id, contact.Name, contact.Email);
        }

        private void SaveContacts ( IEnumerable<Contact> contacts)
        {
            // use LINQ Lukle
            var lines = from contact in contacts
                        select SaveContact(contact);
            File.WriteAllLines(_fileName, lines);
        }

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
    }
}
