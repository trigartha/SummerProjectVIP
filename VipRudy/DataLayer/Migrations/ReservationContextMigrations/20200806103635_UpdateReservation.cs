using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.ReservationContextMigrations
{
    public partial class UpdateReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationInfo_Cars_CarId",
                table: "ReservationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationInfo_Discount_DiscountId",
                table: "ReservationInfo");

            migrationBuilder.DropTable(
                name: "Staffel");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropIndex(
                name: "IX_ReservationInfo_CarId",
                table: "ReservationInfo");

            migrationBuilder.DropIndex(
                name: "IX_ReservationInfo_DiscountId",
                table: "ReservationInfo");

            migrationBuilder.DropColumn(
                name: "AmountNightHours",
                table: "ReservationInfo");

            migrationBuilder.DropColumn(
                name: "AmountNormalHours",
                table: "ReservationInfo");

            migrationBuilder.DropColumn(
                name: "AmountOverTimeHours",
                table: "ReservationInfo");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "ReservationInfo");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "ReservationInfo");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarId",
                table: "Reservations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "AmountNightHours",
                table: "ReservationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountNormalHours",
                table: "ReservationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOverTimeHours",
                table: "ReservationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "ReservationInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "ReservationInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Staffel",
                columns: table => new
                {
                    StaffelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffel", x => x.StaffelId);
                    table.ForeignKey(
                        name: "FK_Staffel_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_CarId",
                table: "ReservationInfo",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_DiscountId",
                table: "ReservationInfo",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffel_DiscountId",
                table: "Staffel",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationInfo_Cars_CarId",
                table: "ReservationInfo",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationInfo_Discount_DiscountId",
                table: "ReservationInfo",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
