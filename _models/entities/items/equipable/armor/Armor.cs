namespace adventure_cli._models.entities.items.equipable.armor
{
    public class Armor : Equipable
    {
        public int _armorRating { get; set; } // Base AC Rating
        public Armor(int Id, string name, int goldValue, int maxDurability) : base(Id, name, goldValue, maxDurability)
        {
        }


        /**
        NullifyValue(void) -> void

        This method sets the gold value and armor rating to zero, nullifying any effects
        that this armor could have.
        
        */
        public override void NullifyValue()
        {
            if(_currentDurability > 0) return;
            _goldValue = 0;
            _armorRating = 0;
        }
    }
}