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
                    Gold = table.Column<int>(nullable: false),
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
                name: "Weapon_Tbl",
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
                    table.PrimaryKey("PK_Weapon_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemType = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    CharacterDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentData_Character_Tbl_CharacterDataId",
                        column: x => x.CharacterDataId,
                        principalTable: "Character_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemType = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    CharacterDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Tbl_Character_Tbl_CharacterDataId",
                        column: x => x.CharacterDataId,
                        principalTable: "Character_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentData_CharacterDataId",
                table: "EquipmentData",
                column: "CharacterDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Tbl_CharacterDataId",
                table: "Item_Tbl",
                column: "CharacterDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armor_Tbl");

            migrationBuilder.DropTable(
                name: "EquipmentData");

            migrationBuilder.DropTable(
                name: "Item_Tbl");

            migrationBuilder.DropTable(
                name: "Potion_Tbl");

            migrationBuilder.DropTable(
                name: "Weapon_Tbl");

            migrationBuilder.DropTable(
                name: "Character_Tbl");
        }
    }
}
