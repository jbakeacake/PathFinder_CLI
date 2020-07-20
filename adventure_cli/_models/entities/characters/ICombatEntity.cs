using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public interface ICombatEntity
    {
        void AttackOther(ICombatEntity other, Weapon weapon);
        void Defend(Armor armor);
        Stats GetStats();
        string GetName();
        void TakeDamage(int damage);
        bool isHitDodged(ICombatEntity other);
        void ApplyDebuff(string skillToDebuff, int reductionValue);
        bool isDead();
    }
}