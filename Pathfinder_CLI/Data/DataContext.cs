using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base() {}
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
            builder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<CharacterData> Character_Tbl { get; set; }
        public DbSet<EquipmentData> Equipment_Tbl { get; set; }
        public DbSet<ItemData> Item_Tbl { get; set; }
        public DbSet<WeaponData> Weapon_Tbl { get; set; }
        public DbSet<ArmorData> Armor_Tbl { get; set; }
        public DbSet<PotionData> Potion_Tbl { get; set; }
        // public DbSet<SpellData> Spell_Tbl { get; set; }
        
    }
}