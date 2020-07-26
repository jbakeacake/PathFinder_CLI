using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items.Spells
{
    public class SpellScroll : Equipable
    {
        public SpellScroll(string name, int goldValue, int currentDurability, int maxDurability) : base(name, goldValue, currentDurability, maxDurability)
        {
        }

        public override void NullifyValue()
        {
            throw new System.NotImplementedException();
        }
    }
}