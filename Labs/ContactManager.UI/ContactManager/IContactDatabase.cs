using System.Collections.Generic;

namespace ContactManager
{
    public interface IContactDatabase
    {
        Contact Add( Contact contact );
        void Delete( int id );
        Contact Get( int id );
        IEnumerable<Contact> GetAll();
        Contact Update( int id, Contact contact );
    }
}