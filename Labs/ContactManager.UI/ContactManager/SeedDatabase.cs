using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public static class SeedDatabase
    {
        public static void Seed ( this IContactDatabase source )
        {
            // Collection initializer
            var games = new[]
            {
                new Contact() { Name = "John Miller", Email = "something@something.com" }
            };
        }
    }
}
