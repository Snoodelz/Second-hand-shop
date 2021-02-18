using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHandWebShop.Migrations
{
    public partial class Stockbalanceadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockBalance",
                table: "Clothing",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockBalance",
                table: "Clothing");
        }
    }
}
