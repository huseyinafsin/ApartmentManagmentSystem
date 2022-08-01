using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class renameresidenttotenant1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Residents_ResidentId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Residents_ResidentId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Users_UserId",
                table: "Residents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residents",
                table: "Residents");

            migrationBuilder.RenameTable(
                name: "Residents",
                newName: "Tenants");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_UserId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Residents");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_UserId",
                table: "Residents",
                newName: "IX_Residents_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residents",
                table: "Residents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Residents_ResidentId",
                table: "Bills",
                column: "ResidentId",
                principalTable: "Residents",
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
                name: "FK_Residents_Users_UserId",
                table: "Residents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
