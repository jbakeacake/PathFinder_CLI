using Pathfinder_CLI.Models.Interfaces;

namespace Pathfinder_CLI.Models
{
    public class ArmorData : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoldValue { get; set; }
        public int ArmorRating { get; set; }
        public int CurrentDurability { get; set; }
        public int MaxDurability { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}