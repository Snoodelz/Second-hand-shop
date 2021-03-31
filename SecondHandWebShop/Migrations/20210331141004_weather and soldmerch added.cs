using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHandWebShop.Migrations
{
    public partial class weatherandsoldmerchadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoldMerch",
                table: "Clothing",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Weather",
                table: "Clothing",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoldMerch",
                table: "Clothing");

            migrationBuilder.DropColumn(
                name: "Weather",
                table: "Clothing");
        }
    }
}
