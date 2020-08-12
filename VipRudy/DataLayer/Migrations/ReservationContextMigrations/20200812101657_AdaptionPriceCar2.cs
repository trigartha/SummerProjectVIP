using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.ReservationContextMigrations
{
    public partial class AdaptionPriceCar2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Arrangement",
                table: "Price",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Arrangement",
                table: "Price",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
