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

        private int _strength = 30;
        /// <summary> gets the strength attributes from user </summary>
        public int Strength
        {
            get { return _strength; }
            set { if (value > 0 || value < 100)
                    _strength = value;
            }

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
