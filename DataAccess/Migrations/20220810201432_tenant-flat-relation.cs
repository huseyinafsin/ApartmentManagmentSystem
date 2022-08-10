using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class tenantflatrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Tenants_TenantId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_TenantId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Flats");

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_FlatId",
                table: "Tenants",
                column: "FlatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Flats_FlatId",
                table: "Tenants",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Flats_FlatId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_FlatId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "Tenants");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Flats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flats_TenantId",
                table: "Flats",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Tenants_TenantId",
                table: "Flats",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
