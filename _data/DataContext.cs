using adventure_cli._models.characterData;
using adventure_cli._models.entities.characters.attributes.stat_types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace adventure_cli._data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
            builder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }
        public DbSet<CharacterData> Character_Tbl { get; set; }
        public DbSet<PotionData> Potion_Tbl { get; set; }
        public DbSet<ArmorData> Armor_Tbl { get; set; }
        public DbSet<ItemData> Inventory_Tbl { get; set; }
    }
}