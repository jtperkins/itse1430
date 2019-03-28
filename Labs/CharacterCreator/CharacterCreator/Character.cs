using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator
{
    public class Character : IValidatableObject
    {

        /// <summary>
        /// CharacterDatabase unique identifier
        /// </summary>
        public int Id { get; set; }

        private string _name = "";
        /// <summary>
        /// respresents name of an RPG Character
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value ?? ""; }
        }

        private string _race = "";
        /// <summary>
        /// represents the race of RPG Character
        /// </summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value ?? ""; }
        }

        private string _profession = "";
        /// <summary>
        /// represents the profession of RPG Character
        /// </summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value ?? ""; }
        }

        private int _strength = 50;
        /// <summary> 
        /// represents Strength attribute of RPG Character
        /// </summary>
        public int Strength
        {
            get { return _strength; }
            set { if (value >= 0 && value <= 100)
                    _strength = value;
            }
        }

        private int _intellect = 50;
        /// <summary>
        /// represents Intellect attribute of RPG Character
        /// </summary>
        public int Intellect
        {
            get { return _intellect; }
            set
            {
                if (value >= 0 && value <= 100)
                    _intellect = value;
            }
        }

        private int _agility = 50;
        /// <summary>  
        /// represents Agility attribute of RPG Character
        /// </summary>
        public int Agility
        {
            get { return _agility; }
            set
            {
                if (value >= 0 && value <= 100)
                    _agility = value;
            }
        }

        private int _constitution = 50;
        /// <summary>
        /// represents Constitution attribute of RPG Character
        /// </summary>
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                if (value >= 0 && value <= 100)
                    _constitution = value;
            }
        }

        private int _charisma = 50;
        /// <summary> 
        /// represents Charisma attributes of RPG Character
        /// </summary>
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                if (value >= 0 && value <= 100)
                    _charisma = value;
            }
        }

        private string _description = "";
        /// <summary>  
        /// represents the optional biographical description of RPG Character
        /// </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value ?? ""; }
        }

        /// <summary> Validates the object. </summary>
        /// <returns> true if valid or false otherwise </returns>
        //public bool Validate(Character c)
        //{
        //    if (String.IsNullOrEmpty(c.Name))
        //        return false;

        //    if (String.IsNullOrEmpty(c.Race))
        //        return false;

        //    if (String.IsNullOrEmpty(c.Profession))
        //        return false;

        //    if (c.Strength + c.Intellect + c.Agility + c.Constitution + c.Charisma > 300)
        //    {
        //        throw new Exception("You only have 300 points to spend");
        //    }
        //    return true;
        //}

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var items = new List<ValidationResult>();

            // Name is required
            if (String.IsNullOrEmpty(Name))
                items.Add(new ValidationResult("Name is required.", new[] { nameof(Name) }));

            // Race is required
            if (String.IsNullOrEmpty(Race))
                items.Add(new ValidationResult("Race is required.", new[] { nameof(Race) }));

            if (String.IsNullOrEmpty(Profession))
                items.Add(new ValidationResult("Profession is required.", new[] { nameof(Profession) }));

            if (Strength + Intellect + Agility + Constitution + Charisma > 300)
                items.Add(new ValidationResult("You only have 300 points to spend."));

                return items;
        }
    }
}
