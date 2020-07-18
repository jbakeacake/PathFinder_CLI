namespace adventure_cli._models.entities.characters
{
    public interface ICombatEntity
    {
         void TakeDamage(int damage);
         void ApplyDebuff(string skillToDebuff, int reductionValue);
         bool isDead();
    }
}