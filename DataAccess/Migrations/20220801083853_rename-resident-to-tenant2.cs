using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class renameresidenttotenant2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Flats_ResidentId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ResidentId",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resident",
                table: "Resident");

            migrationBuilder.RenameTable(
                name: "Resident",
                newName: "Tenants");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "Flats",
                newName: "TenanttId");

            migrationBuilder.RenameIndex(
                name: "IX_Resident_UserId",
                table: "Tenants",
                newName: "IX_Tenants_UserId");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Flats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_TenantId",
                table: "Flats",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_TenantId",
                table: "Bills",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Tenants_TenantId",
                table: "Bills",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Tenants_TenantId",
                table: "Flats",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Bills_Tenants_TenantId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Tenants_TenantId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Users_UserId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Flats_TenantId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Bills_TenantId",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Bills");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Resident");

            migrationBuilder.RenameColumn(
                name: "TenanttId",
                table: "Flats",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_UserId",
                table: "Resident",
                newName: "IX_Resident_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resident",
                table: "Resident",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_ResidentId",
                table: "Flats",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ResidentId",
                table: "Bills",
                column: "ResidentId");

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
    }
}
