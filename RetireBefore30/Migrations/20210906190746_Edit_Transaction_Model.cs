using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetireBefore30.Migrations
{
    public partial class Edit_Transaction_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Transactions");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MoneyState",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StrategyInstanceId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StrategyInstanceId",
                table: "Transactions",
                column: "StrategyInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_StrategyInstances_StrategyInstanceId",
                table: "Transactions",
                column: "StrategyInstanceId",
                principalTable: "StrategyInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_StrategyInstances_StrategyInstanceId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StrategyInstanceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "MoneyState",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StrategyInstanceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
