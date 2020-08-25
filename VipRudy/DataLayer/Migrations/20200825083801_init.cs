using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    ClientCategory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ClientId", x => x.ClientNumber);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "ReservationInfo",
                columns: table => new
                {
                    ReservationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false),
                    StartLocation = table.Column<int>(nullable: false),
                    EndLocation = table.Column<int>(nullable: false),
                    Arrangement = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Address_AddressId = table.Column<int>(nullable: true),
                    Address_Streetname = table.Column<string>(nullable: true),
                    Address_HouseNumber = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationInfo", x => x.ReservationInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceRate = table.Column<decimal>(nullable: true),
                    Arrangement = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_Prices_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ClientNumber = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    Streetname = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ClientNumber);
                    table.ForeignKey(
                        name: "FK_Addresses_Clients_ClientNumber",
                        column: x => x.ClientNumber,
                        principalTable: "Clients",
                        principalColumn: "ClientNumber",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNumber = table.Column<int>(nullable: true),
                    CarId = table.Column<int>(nullable: true),
                    DiscountId = table.Column<int>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    ReservationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientNumber",
                        column: x => x.ClientNumber,
                        principalTable: "Clients",
                        principalColumn: "ClientNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationInfo_ReservationInfoId",
                        column: x => x.ReservationInfoId,
                        principalTable: "ReservationInfo",
                        principalColumn: "ReservationInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CarId",
                table: "Prices",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientNumber",
                table: "Reservations",
                column: "ClientNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DiscountId",
                table: "Reservations",
                column: "DiscountId");

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
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Staffel");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ReservationInfo");

            migrationBuilder.DropTable(
                name: "Discount");
        }
    }
}
