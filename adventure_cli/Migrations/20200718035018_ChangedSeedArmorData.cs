using Microsoft.EntityFrameworkCore.Migrations;

namespace adventure_cli.Migrations
{
    public partial class ChangedSeedArmorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Armor_Tbl",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Leather Buckler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Armor_Tbl",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Leather Armor");
        }
    }
}
