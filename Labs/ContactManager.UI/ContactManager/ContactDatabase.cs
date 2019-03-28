using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactDatabase : IContactDatabase
    {
        public Contact Add( Contact contact )
        {
            // validate input
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            // Character must be valid
            ObjectValidator.Validate(contact);

            // Character must be valid
            //if (!character.Validate(character))
            //    throw new Exception("Character is invalid.");

            // Character names must be unique
            var existing = FindByName(contact.Name);
            if (existing != null)
                throw new Exception("Character must be unique.");

            // give unique identifier and add to List
            contact.Id = ++_nextId;
            _items.Add(contact);

            return contact;
        }

        public void Delete( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            var index = GetIndex(id);
            if (index >= 0)
                _items[index] = null;
        }

        public Contact Get( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            var index = GetIndex(id);
            if (index >= 0)
                return Clone(_items[index]);

            return null;
        }

        public IEnumerable<Contact> GetAll()
        {
            foreach (var item in _items)
                yield return Clone(item);
        }

        public Contact Update( int id, Contact contact )
        {
            var index = GetIndex(id);

            contact.Id = id;
            var existing = _items[index];
            Clone(existing, contact);

            return contact;
        }

        private Contact Clone( Contact contact )
        {
            var newContact = new Contact();
            Clone(newContact, contact);

            return newContact;
        }

        private void Clone( Contact target, Contact source )
        {
            target.Name = source.Name;
            target.Email = source.Email;
        }

        private int GetIndex( int id )
        {
            for (var index = 0; index < _items.Count; ++index)
                if (_items[index]?.Id == id)
                    return index;

            return -1;
        }

        protected Contact FindByName( string name )
        {
            foreach (var contact in GetAll())
            {
                if (String.Compare(contact.Name, name, true) == 0)
                    return contact;
            };

            return null;
        }

        private readonly List<Contact> _items = new List<Contact>();
        private int _nextId = 0;
    }
}
