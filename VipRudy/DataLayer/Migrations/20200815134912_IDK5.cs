using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class IDK5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ClientNumber",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientNumber",
                table: "Reservations",
                column: "ClientNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientNumber",
                table: "Reservations",
                column: "ClientNumber",
                principalTable: "Clients",
                principalColumn: "ClientNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientNumber",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientNumber",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
