using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAppCore.Migrations
{
    public partial class last3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientSocialSecurityNumber",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "ClientSocialSecurityNumber",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientSocialSecurityNumber",
                table: "Accounts",
                column: "ClientSocialSecurityNumber",
                principalTable: "Clients",
                principalColumn: "SocialSecurityNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientSocialSecurityNumber",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "ClientSocialSecurityNumber",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientSocialSecurityNumber",
                table: "Accounts",
                column: "ClientSocialSecurityNumber",
                principalTable: "Clients",
                principalColumn: "SocialSecurityNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
