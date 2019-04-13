/**********************************************************
 * 
 * Taylor Perkins
 * ITSE 1430
 * 4/13/2019
 * 
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Contact : IValidatableObject
    {
        /// <summary>
        /// Contact database unique identifier
        /// </summary>
        public int Id { get; set; }

        public Contact()
        {

        }
        public Contact(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        /// <summary>
        /// represents the name of the Contact
        /// </summary>
        private string _name = "";
        public string Name
        {
            //get { return _name ?? ""; }
            get => _name ?? "";
            //set { _name = value ?? ""; }
            set => _name = value ?? "";
        }

        /// <summary>
        /// represents the email address of Contact
        /// </summary>
        private string _email = "";
        public string Email
        {
            get { return _email ?? ""; }
            set { _email = value ?? ""; }
        }

        private bool IsValidEmail( string source )
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            } catch
            { };

            return false;
        }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var items = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Name))
                items.Add(new ValidationResult("Name is required.", new[] { nameof(Name) }));

            if (!IsValidEmail(Email))
                items.Add(new ValidationResult("invalid Email.", new[] { nameof(Email) }));

            //char[] chars = Email.ToCharArray();
            //foreach (var character in chars)
            //{
            //    //if (!character.Equals('@'))
            //    //{
            //    //    items.Add(new ValidationResult("Improper email format.", new[] { nameof(Email) }));
            //    //}
            //}

            return items;
        }
    }
}
