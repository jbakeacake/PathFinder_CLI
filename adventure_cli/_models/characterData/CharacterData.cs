using System.Collections.Generic;
using adventure_cli._models.entities.items;

namespace adventure_cli._models.characterData
{
    public class CharacterData
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
    }
}