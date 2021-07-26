using Microsoft.EntityFrameworkCore.Migrations;

namespace RetireBefore30.Migrations
{
    public partial class AddTransactionParameteres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Transactions");
        }
    }
}
