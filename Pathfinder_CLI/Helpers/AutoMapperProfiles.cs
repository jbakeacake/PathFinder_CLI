using AutoMapper;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PotionData, Potion>();
            CreateMap<WeaponData, Weapon>();
            CreateMap<ArmorData, Armor>();
        }
    }
}