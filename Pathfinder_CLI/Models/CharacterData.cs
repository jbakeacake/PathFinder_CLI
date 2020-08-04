using System.Collections.Generic;
using Pathfinder_CLI.Models.Interfaces;

namespace Pathfinder_CLI.Models
{
    public class CharacterData : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Max_HP { get; set; }
        public int HP { get; set; }
        public int XP { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public ICollection<EquipmentData> Equipment { get; set; }
        public ICollection<ItemData> Inventory { get; set; }
        public int GetId()
        {
            return Id;
        }
    }
}