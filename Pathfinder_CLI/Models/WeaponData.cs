using Pathfinder_CLI.Models.Interfaces;

namespace Pathfinder_CLI.Models
{
    public class WeaponData : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoldValue { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int CurrentDurability { get; set; }
        public int MaxDurability { get; set; }
        public int GetId()
        {
            return Id;
        }
    }
}