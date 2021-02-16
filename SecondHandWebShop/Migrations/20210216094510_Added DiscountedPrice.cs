using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHandWebShop.Migrations
{
    public partial class AddedDiscountedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "Clothing",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "Clothing");
        }
    }
}
