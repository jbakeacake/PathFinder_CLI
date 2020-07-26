namespace Pathfinder_CLI.Game.GameEntities.Items.Interfaces
{
    public interface IEquipable
    {
        void FullRepair();
        void DecreaseDurability(int points);
        bool isBroken();
        void NullifyValue();
    }
}