using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Flats",
                newName: "ResidentId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Flats",
                newName: "FlatTypeId");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residents_UserId",
                table: "Residents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_ResidentId",
                table: "Flats",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillTypeId",
                table: "Bills",
                column: "BillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PaymentTypeId",
                table: "Bills",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ResidentId",
                table: "Bills",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_BillTypes_BillTypeId",
                table: "Bills",
                column: "BillTypeId",
                principalTable: "BillTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PaymentTypes_PaymentTypeId",
                table: "Bills",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Residents_ResidentId",
                table: "Bills",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId",
                principalTable: "FlatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Residents_ResidentId",
                table: "Flats",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Users_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_BillTypes_BillTypeId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PaymentTypes_PaymentTypeId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Residents_ResidentId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Residents_ResidentId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Users_UserId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_UserId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Managers_UserId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Flats_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_ResidentId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BillTypeId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PaymentTypeId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ResidentId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "Flats",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FlatTypeId",
                table: "Flats",
                newName: "TypeId");
        }
    }
}
