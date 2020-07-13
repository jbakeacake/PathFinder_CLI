
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
        public int ItemId { get; set; }
        public int CharacterDataId { get; set; }
        public CharacterData Character { get; set; }
    }
}