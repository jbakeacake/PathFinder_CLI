using System.ComponentModel.DataAnnotations;
using Pathfinder_CLI.Models.Interfaces;

namespace Pathfinder_CLI.Models
{
    public class SpellData : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Damage, Utility, or Debuff
        public int Damage { get; set; } // Can be 0 or Null
        public string SkillToDebuff { get; set; } // Can be 0 or Null
        public string UtilityType { get; set; } // Can be 0 or Null
        public int GetId()
        {
            return Id;
        }
    }
}