using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items.equipable.armor;

namespace adventure_cli._models.actions._options
{
    public class Defend : Option
    {
        public Armor _armor { get; set; }
        public EnemyEntity _enemy { get; set; }
        public Defend(int index, string name, Armor armor, EnemyEntity enemy) : base(index, name)
        {
            _armor = armor;
            _enemy = enemy;
        }

        public override void doAction(PlayerEntity player)
        {
            player._tempStats._armorClass += _armor._armorRating; // Upon using a defensive item, give the player additional armor until his next turn
        }
    }
}