using Microsoft.EntityFrameworkCore.Migrations;

namespace adventure_cli.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armor_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    GoldValue = table.Column<int>(nullable: false),
                    ArmorRating = table.Column<int>(nullable: false),
                    CurrentDurability = table.Column<int>(nullable: false),
                    MaxDurability = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Max_HP = table.Column<int>(nullable: false),
                    HP = table.Column<int>(nullable: false),
                    XP = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Potion_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    GoldValue = table.Column<int>(nullable: false),
                    HealValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potion_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    GoldValue = table.Column<int>(nullable: false),
                    MinDamage = table.Column<int>(nullable: false),
                    MaxDamage = table.Column<int>(nullable: false),
                    CurrentDurability = table.Column<int>(nullable: false),
                    MaxDurability = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(nullable: false),
                    CharacterDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Tbl_Character_Tbl_CharacterDataId",
                        column: x => x.CharacterDataId,
                        principalTable: "Character_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Armor_Tbl",
                columns: new[] { "Id", "ArmorRating", "CurrentDurability", "GoldValue", "MaxDurability", "Name" },
                values: new object[] { 1, 2, 5, 10, 5, "Leather Armor" });

            migrationBuilder.InsertData(
                table: "Armor_Tbl",
                columns: new[] { "Id", "ArmorRating", "CurrentDurability", "GoldValue", "MaxDurability", "Name" },
                values: new object[] { 2, 2, 5, 10, 5, "Leather Armor 1" });

            migrationBuilder.InsertData(
                table: "Armor_Tbl",
                columns: new[] { "Id", "ArmorRating", "CurrentDurability", "GoldValue", "MaxDurability", "Name" },
                values: new object[] { 3, 2, 5, 10, 5, "Leather Armor 2" });

            migrationBuilder.InsertData(
                table: "Armor_Tbl",
                columns: new[] { "Id", "ArmorRating", "CurrentDurability", "GoldValue", "MaxDurability", "Name" },
                values: new object[] { 4, 2, 5, 10, 5, "Leather Armor 3" });

            migrationBuilder.InsertData(
                table: "Armor_Tbl",
                columns: new[] { "Id", "ArmorRating", "CurrentDurability", "GoldValue", "MaxDurability", "Name" },
                values: new object[] { 5, 2, 5, 10, 5, "Leather Armor 4" });

            migrationBuilder.InsertData(
                table: "Character_Tbl",
                columns: new[] { "Id", "Dexterity", "HP", "Intelligence", "Level", "Max_HP", "Name", "Strength", "Type", "XP" },
                values: new object[] { 1, 2, 10, 2, 0, 10, "Enemy 1", 2, "Enemy", 20 });

            migrationBuilder.InsertData(
                table: "Character_Tbl",
                columns: new[] { "Id", "Dexterity", "HP", "Intelligence", "Level", "Max_HP", "Name", "Strength", "Type", "XP" },
                values: new object[] { 2, 2, 10, 2, 0, 10, "Enemy 2", 2, "Enemy", 20 });

            migrationBuilder.InsertData(
                table: "Character_Tbl",
                columns: new[] { "Id", "Dexterity", "HP", "Intelligence", "Level", "Max_HP", "Name", "Strength", "Type", "XP" },
                values: new object[] { 3, 2, 10, 2, 0, 10, "Enemy 3", 2, "Enemy", 20 });

            migrationBuilder.InsertData(
                table: "WeaponData",
                columns: new[] { "Id", "CurrentDurability", "GoldValue", "MaxDamage", "MaxDurability", "MinDamage", "Name" },
                values: new object[] { 1, 5, 15, 4, 5, 2, "Longsword" });

            migrationBuilder.InsertData(
                table: "WeaponData",
                columns: new[] { "Id", "CurrentDurability", "GoldValue", "MaxDamage", "MaxDurability", "MinDamage", "Name" },
                values: new object[] { 2, 3, 2, 2, 3, 1, "Fat Stick" });

            migrationBuilder.InsertData(
                table: "WeaponData",
                columns: new[] { "Id", "CurrentDurability", "GoldValue", "MaxDamage", "MaxDurability", "MinDamage", "Name" },
                values: new object[] { 3, 5, 8, 3, 5, 1, "Dagger" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Tbl_CharacterDataId",
                table: "Inventory_Tbl",
                column: "CharacterDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armor_Tbl");

            migrationBuilder.DropTable(
                name: "Inventory_Tbl");

            migrationBuilder.DropTable(
                name: "Potion_Tbl");

            migrationBuilder.DropTable(
                name: "WeaponData");

            migrationBuilder.DropTable(
                name: "Character_Tbl");
        }
    }
}
