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
    public class Message : IValidatableObject
    {
        /// <summary>
        /// The Contact the message is to be sent to. Required
        /// </summary>
        public Contact Contact { get; set; }

        private string _subject = "";
        /// <summary>
        /// the Subject of the Message
        /// </summary>
        public string Subject
        {
            get { return _subject ?? ""; }
            set { _subject = value ?? ""; }
        }

        private string _body = "";
        /// <summary>
        /// the body is the Message itself
        /// </summary>
        public string Body
        {
            get { return _body ?? ""; }
            set { _body = value ?? ""; }
        }

        /// <summary>
        /// Validation done by ObjectValidator
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var items = new List<ValidationResult>();

            if (Contact == null)
                items.Add(new ValidationResult("Contact recipient is required.", new[] { nameof(Contact.Name) }));

            if (String.IsNullOrEmpty(Subject))
                items.Add(new ValidationResult("Subject is required.", new[] { nameof(Subject) }));

            return items;
        }
    }
}
