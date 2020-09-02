using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.DAL.Migrations
{
    public partial class roominsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "ExtraBedPriceRatio", "RoomPrice", "RoomType", "SingleRoomRatio", "WeekendPriceRatio" },
                values: new object[] { 1, 20m, 100m, "Standart Oda", 30m, 30m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
