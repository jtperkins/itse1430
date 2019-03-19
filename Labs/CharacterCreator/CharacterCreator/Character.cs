using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public int Id { get; set; }

        private string _name = "";
        /// <summary>
        /// respresents an RPG character
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value ?? ""; }
        }

        private string _race = "";
        /// <summary>
        /// 
        /// </summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value ?? ""; }
        }

        private string _profession = "";
        /// <summary>
        /// 
        /// </summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value ?? ""; }
        }
        //private bool _professionBool = false;
        //public bool professionBool
        //    {
        //        get { return _professionBool; }
        //        set { _professionBool = value; }
        //    }



        //private bool _raceBool = false;
        //public bool raceBool
        //{
        //    get { return _raceBool; }
        //    set { _raceBool = value; }
        //}

        private int _strength = 50;
        /// <summary> gets and sets the strength attributes from user </summary>
        public int Strength
        {
            get { return _strength; }
            set { if (value > 0 && value < 100)
                    _strength = value;
            }
        }

        private int _intellect = 50;
        /// <summary> gets and sets the intellect attributes from user </summary>
        public int Intellect
        {
            get { return _intellect; }
            set
            {
                if (value > 0 && value < 100)
                    _intellect = value;
            }
        }

        private int _agility = 50;
        /// <summary> gets and sets the agility attributes from user </summary>
        public int Agility
        {
            get { return _agility; }
            set
            {
                if (value > 0 && value < 100)
                    _agility = value;
            }
        }

        private int _constitution = 50;
        /// <summary> gets and sets the constitution attributes from user </summary>
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                if (value > 0 && value < 100)
                    _constitution = value;
            }
        }

        private int _charisma = 50;
        /// <summary> gets and sets the charisma attributes from user </summary>
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                if (value > 0 && value < 100)
                    _charisma = value;
            }
        }

        private string _description = "";
        /// <summary>  gets and sets the optional biogrphical description  </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value ?? ""; }
        }

        /// <summary> Validates the object. </summary>
        /// <returns> true if valid or false otherwise </returns>
        public bool Validate( /*Game This */ )
        {
            if (String.IsNullOrEmpty(Name))
                return false;

            if (String.IsNullOrEmpty(Race))
                return false;

            if (String.IsNullOrEmpty(Profession))
                return false;

            if (Strength + Intellect + Agility + Constitution + Charisma > 300)
                return false;
            //TODO: need to implement validation on professions and race, after making the enums

            return true;
        }
    }
}
