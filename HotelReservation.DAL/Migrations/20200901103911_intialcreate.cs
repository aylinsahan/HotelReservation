using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.DAL.Migrations
{
    public partial class intialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntyDate = table.Column<DateTime>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    NumberOfNight = table.Column<int>(nullable: false),
                    GuestCount = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(nullable: true),
                    RoomPrice = table.Column<decimal>(nullable: false),
                    ExtraBedPriceRatio = table.Column<decimal>(nullable: false),
                    WeekendPriceRatio = table.Column<decimal>(nullable: false),
                    SingleRoomRatio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntyDate = table.Column<DateTime>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    NumberOfNight = table.Column<int>(nullable: false),
                    WeekendCount = table.Column<int>(nullable: false),
                    WeekdaysCount = table.Column<int>(nullable: false),
                    GuestCount = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true),
                    RoomPrice = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    ExtraBedPrice = table.Column<decimal>(nullable: false),
                    WeekendPrice = table.Column<decimal>(nullable: false),
                    SinglePrice = table.Column<decimal>(nullable: false),
                    StandardRoom = table.Column<int>(nullable: false),
                    SingleRoom = table.Column<int>(nullable: false),
                    ExtraBedRoom = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempRoom", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "TempRoom");
        }
    }
}
