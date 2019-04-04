using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAppCore.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserActionLogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionLogs_ApplicationUserId",
                table: "UserActionLogs",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActionLogs_AspNetUsers_ApplicationUserId",
                table: "UserActionLogs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActionLogs_AspNetUsers_ApplicationUserId",
                table: "UserActionLogs");

            migrationBuilder.DropIndex(
                name: "IX_UserActionLogs_ApplicationUserId",
                table: "UserActionLogs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserActionLogs");
        }
    }
}
