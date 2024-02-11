using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_booking_hotel.Migrations
{
    /// <inheritdoc />
    public partial class Add_tbUtility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtilityCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilityCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utility_UtilityCategory_UtilityCategoryId",
                        column: x => x.UtilityCategoryId,
                        principalTable: "UtilityCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelUtility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    UtilityId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelUtility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelUtility_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelUtility_Utility_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "Utility",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelUtility_HotelId",
                table: "HotelUtility",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelUtility_UtilityId",
                table: "HotelUtility",
                column: "UtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Utility_UtilityCategoryId",
                table: "Utility",
                column: "UtilityCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelUtility");

            migrationBuilder.DropTable(
                name: "Utility");

            migrationBuilder.DropTable(
                name: "UtilityCategory");
        }
    }
}
