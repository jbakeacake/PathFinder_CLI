using adventure_cli._models.characterData;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items.consumable;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;
using AutoMapper;

namespace adventure_cli.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ArmorData, Armor>();
            CreateMap<WeaponData, Weapon>();
            CreateMap<PotionData, Potion>();
        }
    }
}