using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.ReservationContextMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Streetname = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstHourPrice = table.Column<decimal>(nullable: true),
                    NightLifePrice = table.Column<decimal>(nullable: true),
                    WeddingPrice = table.Column<decimal>(nullable: true),
                    WellnessPrice = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    ClientCategory = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ClientId", x => x.ClientNumber);
                    table.ForeignKey(
                        name: "FK_Clients_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffel",
                columns: table => new
                {
                    StaffelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    DiscountId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    PriceId = table.Column<int>(nullable: true),
                    Availability = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Price_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationInfo",
                columns: table => new
                {
                    ReservationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartLocation = table.Column<int>(nullable: false),
                    EndLocation = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: true),
                    Arrangement = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    AmountNormalHours = table.Column<int>(nullable: false),
                    AmountNightHours = table.Column<int>(nullable: false),
                    AmountOverTimeHours = table.Column<int>(nullable: false),
                    DiscountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationInfo", x => x.ReservationInfoId);
                    table.ForeignKey(
                        name: "FK_ReservationInfo_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationInfo_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNumber = table.Column<int>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    ReservationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientNumber",
                        column: x => x.ClientNumber,
                        principalTable: "Clients",
                        principalColumn: "ClientNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationInfo_ReservationInfoId",
                        column: x => x.ReservationInfoId,
                        principalTable: "ReservationInfo",
                        principalColumn: "ReservationInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceId",
                table: "Cars",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_CarId",
                table: "ReservationInfo",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInfo_DiscountId",
                table: "ReservationInfo",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientNumber",
                table: "Reservations",
                column: "ClientNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationInfoId",
                table: "Reservations",
                column: "ReservationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffel_DiscountId",
                table: "Staffel",
                column: "DiscountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Staffel");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ReservationInfo");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Price");
        }
    }
}
