
namespace adventure_cli._models.characterData
{
    /**
    ItemData

    ItemData serves a sort of intermediary between several different tables. Since
    a CharacterEntity's inventory is full of items that are of several different types, this
    class acts as a link to several different tables that contain data for this types.
    */
    public class ItemData
    {
        public int Id { get; set; }
        public int WeaponPieceID { get; set; }
        public WeaponData WeaponPiece { get; set; }
        public int ArmorPieceId { get; set; } // Is NULL if item is not Armor
        public ArmorData ArmorPiece { get; set; }
        public int PotionId { get; set; }
        public PotionData Potion { get; set; }
    }
}