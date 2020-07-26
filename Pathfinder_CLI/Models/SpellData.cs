using System.ComponentModel.DataAnnotations;

namespace Pathfinder_CLI.Models
{
    public class SpellData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Damage, Utility, or Debuff
        public int Damage { get; set; } // Can be 0 or Null
        public string SkillToDebuff { get; set; } // Can be 0 or Null
        public string UtilityType { get; set; } // Can be 0 or Null
    }
}