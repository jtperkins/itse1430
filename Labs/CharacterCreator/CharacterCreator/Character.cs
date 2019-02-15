using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {


        private string _name = "";
        /// <summary>
        /// respresents an RPG character
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value ?? ""; }
        }

        //private bool _nameBool = false;
        //public bool nameBool
        //{
        //    get { return _nameBool; }
        //    set { _nameBool = value; }
        //}


        public enum Profession
        {
            Herbalism = 0,
            Mining = 1,
            Skinning = 2,
            Alchemy = 3,
            Blacksmithing = 4,
            Enchanting = 5,
            Engineering = 6,
            Inscription = 7,
            Jewelcrafting = 8,
            Leatherworking = 9,
            Tailoring = 10
        }

        //private bool _professionBool = false;
        //public bool professionBool
        //    {
        //        get { return _professionBool; }
        //        set { _professionBool = value; }
        //    }

        public enum Race
        {
            Human = 0,
            Dwarf = 1,
            Gnome = 2,
            NightElf = 3,
            Orc = 4,
            Troll = 5,
            Undead = 6,
            Tauren = 7,
            BloodElf = 8,
            Draenei = 9,
            Goblin = 10,
            Worgen = 11,
            Pandaren = 12
        }

        //private bool _raceBool = false;
        //public bool raceBool
        //{
        //    get { return _raceBool; }
        //    set { _raceBool = value; }
        //}

        private int _strength = 30;
        /// <summary> gets and sets the strength attributes from user </summary>
        public int Strength
        {
            get { return _strength; }
            set { if (value > 0 && value < 100)
                    _strength = value;
            }
        }

        private int _intellect = 30;
        /// <summary> gets and sets the intellect attributes from user </summary>
        public int Inteleect
        {
            get { return _intellect; }
            set
            {
                if (value > 0 && value < 100)
                    _intellect = value;
            }
        }

        private int _agility = 30;
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

        private int _constitution = 30;
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

        private int _charisma = 30;
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
            get { return _name ?? ""; }
            set { _name = value ?? ""; }
        }

        /// <summary> Validates the object. </summary>
        /// <returns> true if valid or false otherwise </returns>
        public bool Validate( /*Game This */ )
        {
            if (String.IsNullOrEmpty(Name))
                return false;

            //TODO: need to implement validation on professions and race, after making the enums

            return true;
        }
    }
}
