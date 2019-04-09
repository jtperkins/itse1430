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
        public Contact Contact { get; set; }

        private string _subject = "";
        public string Subject
        {
            get { return _subject ?? ""; }
            set { _subject = value ?? ""; }
        }

        private string _body = "";
        public string Body
        {
            get { return _body ?? ""; }
            set { _body = value ?? ""; }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var items = new List<ValidationResult>();

            if (Contact == null)
                items.Add(new ValidationResult("Contact recipient is required.", new[] { nameof(Contact.Name) }));

            if (String.IsNullOrEmpty(Subject))
                items.Add(new ValidationResult("Subject is required.", new[] { nameof(Subject) }));

            //if (String.IsNullOrEmpty(Body))
                //items.Add(new ValidationResult("Body is required.", new[] { nameof(Body) }));

            return items;
        }
    }
}
