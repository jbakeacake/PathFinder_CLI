namespace adventure_cli._models.entities
{
    public abstract class Entity
    {
        public int _Id { get; }
        public string _name { get; set; }
        public bool _interactable { get; set; } // This means the user can perform actions on the entity -- any number of verbal commands are allowed to be made on this entity (attack, cast 'spell', open, close, equip, etc.)

        public Entity(int Id, string name, bool interactable)
        {
            _Id = Id;
            _name = name;
            _interactable = interactable;
        }
    }
}