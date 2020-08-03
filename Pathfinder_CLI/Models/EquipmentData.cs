namespace Pathfinder_CLI.Models
{
    public class EquipmentData
    {
        public int Id { get; set; }
        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public int CharacterDataId { get; set; }
        public CharacterData Character { get; set; }
    }
}