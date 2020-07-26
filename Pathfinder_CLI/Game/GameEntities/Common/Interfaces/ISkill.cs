namespace Pathfinder_CLI.Game.GameEntities.Common.Interfaces
{
    public interface ISkill
    {
        string ToString();
        string GetName();
        int GetValue();
        int GetModifier();
        void IncreaseValueBy(int value);
        
    }
}