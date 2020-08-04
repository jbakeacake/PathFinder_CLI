using Pathfinder_CLI.Models.Interfaces;

namespace Pathfinder_CLI.Models
{
    public class PotionData : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoldValue { get; set; }
        public int HealValue { get; set; }
        public int GetId()
        {
            return Id;
        }
    }
}