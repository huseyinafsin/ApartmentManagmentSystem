using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class renameresident1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Tenants_ResidentId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Tenants_ResidentId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Users_UserId",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Resident");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_UserId",
                table: "Resident",
                newName: "IX_Resident_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resident",
                table: "Resident",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Resident_ResidentId",
                table: "Bills",
                column: "ResidentId",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Resident_ResidentId",
                table: "Flats",
                column: "ResidentId",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Users_UserId",
                table: "Resident",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Resident_ResidentId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Resident_ResidentId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Users_UserId",
                table: "Resident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resident",
                table: "Resident");

            migrationBuilder.RenameTable(
                name: "Resident",
                newName: "Tenants");

            migrationBuilder.RenameIndex(
                name: "IX_Resident_UserId",
                table: "Tenants",
                newName: "IX_Tenants_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Tenants_ResidentId",
                table: "Bills",
                column: "ResidentId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Tenants_ResidentId",
                table: "Flats",
                column: "ResidentId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Users_UserId",
                table: "Tenants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
