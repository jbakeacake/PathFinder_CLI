namespace adventure_cli._models.entities.items.equipable
{
    public abstract class Equipable : Entity
    {
        public int _goldValue { get; set; }
        public int _maxDurability { get; set; }
        public int _currentDurability { get; set; }
        public Equipable(int Id, string name, int goldValue, int maxDurability) : base(Id, name, true)
        {
            _goldValue = goldValue;
            _maxDurability = maxDurability;
            _currentDurability = _currentDurability;
        }
        public void DecreaseDurability()
        {
            _currentDurability -= 1;
        }

        public void FullRepair()
        {
            _currentDurability = _maxDurability;
        }

        /**
        NullifyValue(void) -> void

        This method sets the gold value and any other attributes to zero, nullifying any effects
        that this equipable could have.

        */
        public abstract void NullifyValue();

    }
}