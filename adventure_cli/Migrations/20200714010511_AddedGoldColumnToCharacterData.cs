using Microsoft.EntityFrameworkCore.Migrations;

namespace adventure_cli.Migrations
{
    public partial class AddedGoldColumnToCharacterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Character_Tbl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Character_Tbl",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gold",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Character_Tbl",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gold",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Character_Tbl",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gold",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Character_Tbl",
                keyColumn: "Id",
                keyValue: 999,
                column: "Gold",
                value: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Character_Tbl");
        }
    }
}
