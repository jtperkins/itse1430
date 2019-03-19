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
            //var character = new Character();
            //character.Name = "DOOM";
            //character.Description = "Space Marine";
            ////character.Price = 49.99M;
            //Add(character);

            //character = new Character();
            //character.Name = "Oblivion";
            //character.Description = "Medieval";
            ////character.Price = 89.99M;
            //Add(character);

            //character = new Character();
            //character.Name = "Fallout 76";
            //character.Description = "Failed MMO";
            ////character.Price = 0.01M;
            //Add(character);
        }

        // TODO: not sure where, but somewhere the name of the character is being changed to the profession, also the race is. maybe somewhere in saveData or in database?

        public Character Add(Character character)
        {
            //Validate input
            if (character == null)
                throw new ArgumentNullException(nameof(character));

            //Game must be valid
            if (!character.Validate())
                throw new Exception("Game is invalid.");

            //Game names must be unique
            var existing = GetIndex(character.Id);
            if (existing >= 0)
                throw new Exception("Game must be unique.");

            //Playing around with different exceptions
            //if (String.Compare(character.Name, "Anthem", true) == 0)
            //    throw new InvalidOperationException("Only good games are allowed here.");
            //if (character.Price > 1000)
            //    throw new NotImplementedException();

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

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            var index = GetIndex(id);
            if (index >= 0)
                _items[index] = null;
        }

        public Character Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            var index = GetIndex(id);
            if (index >= 0)
                return Clone(_items[index]);

            return null;
        }

        public Character[] GetAll()
        {
            //How many games?
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

        public Character Update(int id, Character character)
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            if (character == null)
                throw new ArgumentNullException(nameof(character));
            if (!character.Validate())
                throw new Exception("Game is invalid.");

            var index = GetIndex(id);
            if (index < 0)
                throw new Exception("Game does not exist.");

            //Game names must be unique            
            var existingIndex = GetIndex(character.Name);
            if (existingIndex >= 0 && existingIndex != index)
                throw new Exception("Game must be unique.");

            character.Id = id;
            var existing = _items[index];
            Clone(existing, character);

            return character;
        }

        private Character Clone(Character character)
        {
            var newCharacter = new Character();
            Clone(newCharacter, character);

            return newCharacter;
        }

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

        private int GetIndex(int id)
        {
            for (var index = 0; index < _items.Length; ++index)
                if (_items[index]?.Id == id)
                    return index;

            return -1;
        }

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
