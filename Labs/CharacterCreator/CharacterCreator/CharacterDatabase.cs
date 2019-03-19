using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterDatabase
    {
        public CharacterDatabase()
        {

            // test seed data
            //var character = new Character();
            //character.Name = "DOOM";
            //character.Description = "Space Marine";
            //Add(character);

            //character = new Character();
            //character.Name = "Oblivion";
            //character.Description = "Medieval";
            //Add(character);

            //character = new Character();
            //character.Name = "Fallout 76";
            //character.Description = "Failed MMO";
            //Add(character);
        }

        /// <summary>
        /// adds Character to the "Database" after successful validation
        /// </summary>
        public Character Add(Character character)
        {
            // validate input
            if (character == null)
                throw new ArgumentNullException(nameof(character));

            // Character must be valid
            if (!character.Validate(character))
                throw new Exception("Game is invalid.");

            // Character names must be unique
            var existing = GetIndex(character.Id);
            if (existing >= 0)
                throw new Exception("Game must be unique.");

            for (var index = 0; index < _items.Length; ++index)
            {
                if (_items[index] == null)
                {
                    character.Id = ++_nextId;
                    _items[index] = Clone(character);
                    break;
                };
            };

            return character;
        }

        /// <summary>
        /// deletes the appropriate Character by Id
        /// </summary>
        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            var index = GetIndex(id);
            if (index >= 0)
                _items[index] = null;
        }

        /// <summary>
        /// grabs the appropriate Character by Id
        /// </summary>
        /// <returns>Character</returns>
        public Character Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            var index = GetIndex(id);
            if (index >= 0)
                return Clone(_items[index]);

            return null;
        }

        /// <summary>
        /// gets all the Characters in "Database"
        /// </summary>
        /// <returns>Character array</returns>
        public Character[] GetAll()
        {
            //How many Characters?
            int count = 0;
            foreach (var item in _items)
                if (item != null)
                    ++count;

            var tempIndex = 0;
            var temp = new Character[count];
            for (var index = 0; index < _items.Length; ++index)
                if (_items[index] != null)
                    temp[tempIndex++] = Clone(_items[index]);

            return temp;
        }

        /// <summary>
        /// updates the appropriate Character
        /// </summary>
        /// <returns>updated Character</returns>
        public Character Update(int id, Character character)
        {
            // validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            if (character == null)
                throw new ArgumentNullException(nameof(character));
            if (!character.Validate(character))
                throw new Exception("Game is invalid.");

            var index = GetIndex(id);
            if (index < 0)
                throw new Exception("Game does not exist.");

            // Character names must be unique            
            var existingIndex = GetIndex(character.Name);
            if (existingIndex >= 0 && existingIndex != index)
                throw new Exception("Game must be unique.");

            character.Id = id;
            var existing = _items[index];
            Clone(existing, character);

            return character;
        }

        /// <summary>
        /// clones a given Character
        /// </summary>
        /// <returns>Cloned Character</returns>
        private Character Clone(Character character)
        {
            var newCharacter = new Character();
            Clone(newCharacter, character);

            return newCharacter;
        }

        /// <summary>
        /// takes the given Character and copies over each property
        /// </summary>
        private void Clone(Character target, Character source)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Race = source.Race;
            target.Profession = source.Profession;
            target.Strength = source.Strength;
            target.Intellect = source.Intellect;
            target.Agility = source.Agility;
            target.Constitution = source.Constitution;
            target.Charisma = source.Charisma;
            target.Description = source.Description;
        }

        /// <summary>
        /// get the index of the given Character by Id
        /// </summary>
        private int GetIndex(int id)
        {
            for (var index = 0; index < _items.Length; ++index)
                if (_items[index]?.Id == id)
                    return index;

            return -1;
        }

        /// <summary>
        /// get the index of the given Character by Name
        /// </summary>
        private int GetIndex(string name)
        {
            for (var index = 0; index < _items.Length; ++index)
                if (String.Compare(_items[index]?.Name, name, true) == 0)
                    return index;

            return -1;
        }

        private readonly Character[] _items = new Character[100];
        private int _nextId = 0;
    }
}
