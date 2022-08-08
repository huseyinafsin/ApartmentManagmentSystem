using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UserMessagemessageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "UserMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_MessageId",
                table: "UserMessages",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_Messages_MessageId",
                table: "UserMessages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_Messages_MessageId",
                table: "UserMessages");

            migrationBuilder.DropIndex(
                name: "IX_UserMessages_MessageId",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "UserMessages");
        }
    }
}
