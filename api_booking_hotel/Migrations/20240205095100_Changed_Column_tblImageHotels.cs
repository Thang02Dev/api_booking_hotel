using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_booking_hotel.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Column_tblImageHotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_ImageHotels_ImageHotelId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_ImageHotelId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ImageHotelId",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "ImageHotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageHotels_HotelId",
                table: "ImageHotels",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageHotels_Hotels_HotelId",
                table: "ImageHotels",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageHotels_Hotels_HotelId",
                table: "ImageHotels");

            migrationBuilder.DropIndex(
                name: "IX_ImageHotels_HotelId",
                table: "ImageHotels");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "ImageHotels");

            migrationBuilder.AddColumn<int>(
                name: "ImageHotelId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_ImageHotelId",
                table: "Hotels",
                column: "ImageHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_ImageHotels_ImageHotelId",
                table: "Hotels",
                column: "ImageHotelId",
                principalTable: "ImageHotels",
                principalColumn: "Id");
        }
    }
}
