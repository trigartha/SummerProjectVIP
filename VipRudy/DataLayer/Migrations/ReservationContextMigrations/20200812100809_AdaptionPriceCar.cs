using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.ReservationContextMigrations
{
    public partial class AdaptionPriceCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Price_PriceId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PriceId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FirstHourPrice",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "NightLifePrice",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "WeddingPrice",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "WellnessPrice",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ReservationInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Arrangement",
                table: "Price",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceRate",
                table: "Price",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_AddressId",
                table: "ReservationInfo",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_CarId",
                table: "Price",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Cars_CarId",
                table: "Price",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationInfo_Address_AddressId",
                table: "ReservationInfo",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Cars_CarId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationInfo_Address_AddressId",
                table: "ReservationInfo");

            migrationBuilder.DropIndex(
                name: "IX_ReservationInfo_AddressId",
                table: "ReservationInfo");

            migrationBuilder.DropIndex(
                name: "IX_Price_CarId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ReservationInfo");

            migrationBuilder.DropColumn(
                name: "Arrangement",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "PriceRate",
                table: "Price");

            migrationBuilder.AddColumn<decimal>(
                name: "FirstHourPrice",
                table: "Price",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NightLifePrice",
                table: "Price",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeddingPrice",
                table: "Price",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WellnessPrice",
                table: "Price",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceId",
                table: "Cars",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Price_PriceId",
                table: "Cars",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
