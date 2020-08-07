using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.ReservationContextMigrations
{
    public partial class UpdateReservationInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ReservationInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ReservationInfo");
        }
    }
}
