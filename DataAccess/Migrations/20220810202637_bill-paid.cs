using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class billpaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PaymentTypes_PaymentTypeId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PaymentTypeId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymetTypeId",
                table: "Bills");

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymetTypeId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PaymentTypeId",
                table: "Bills",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PaymentTypes_PaymentTypeId",
                table: "Bills",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
