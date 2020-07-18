using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities.items.equipable.weapon
{
    public class Weapon : Equipable
    {
        public int _minDamage { get; set; }
        public int _maxDamage { get; set; }
        public Weapon(int Id, string name, int goldValue, int maxDurability, int minDamage, int maxDamage) : base(Id, name, goldValue, maxDurability)
        {
            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }
        /**
        NullifyValue(void) -> void

        This method sets the gold value and armor rating to zero, nullifying any effects
        that this armor could have.
        
        */
        public override void NullifyValue()
        {
            if (_currentDurability > 0) return;
            _goldValue = 0;
            _minDamage = 0;
            _maxDamage = 0;
        }

        public override string ToString()
        {
            return $"> {_name} | {_goldValue}gp | DMG: {_minDamage} - {_maxDamage} | Durability: {_currentDurability} / {_maxDurability}";
        }
    }
}