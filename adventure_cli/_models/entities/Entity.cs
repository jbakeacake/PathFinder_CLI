using System;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities
{
    public abstract class Entity
    {
        public int _Id { get; }
        public string _name { get; set; }
        public Entity(int Id, string name)
        {
            _Id = Id;
            _name = name;
        }
    }
}