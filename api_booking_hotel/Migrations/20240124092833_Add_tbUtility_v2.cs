using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_booking_hotel.Migrations
{
    /// <inheritdoc />
    public partial class Add_tbUtility_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelUtility_Hotels_HotelId",
                table: "HotelUtility");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelUtility_Utility_UtilityId",
                table: "HotelUtility");

            migrationBuilder.DropForeignKey(
                name: "FK_Utility_UtilityCategory_UtilityCategoryId",
                table: "Utility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilityCategory",
                table: "UtilityCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utility",
                table: "Utility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelUtility",
                table: "HotelUtility");

            migrationBuilder.RenameTable(
                name: "UtilityCategory",
                newName: "UtilityCategories");

            migrationBuilder.RenameTable(
                name: "Utility",
                newName: "Utilities");

            migrationBuilder.RenameTable(
                name: "HotelUtility",
                newName: "HotelUtilities");

            migrationBuilder.RenameIndex(
                name: "IX_Utility_UtilityCategoryId",
                table: "Utilities",
                newName: "IX_Utilities_UtilityCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelUtility_UtilityId",
                table: "HotelUtilities",
                newName: "IX_HotelUtilities_UtilityId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelUtility_HotelId",
                table: "HotelUtilities",
                newName: "IX_HotelUtilities_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilityCategories",
                table: "UtilityCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelUtilities",
                table: "HotelUtilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelUtilities_Hotels_HotelId",
                table: "HotelUtilities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelUtilities_Utilities_UtilityId",
                table: "HotelUtilities",
                column: "UtilityId",
                principalTable: "Utilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilities_UtilityCategories_UtilityCategoryId",
                table: "Utilities",
                column: "UtilityCategoryId",
                principalTable: "UtilityCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelUtilities_Hotels_HotelId",
                table: "HotelUtilities");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelUtilities_Utilities_UtilityId",
                table: "HotelUtilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilities_UtilityCategories_UtilityCategoryId",
                table: "Utilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilityCategories",
                table: "UtilityCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelUtilities",
                table: "HotelUtilities");

            migrationBuilder.RenameTable(
                name: "UtilityCategories",
                newName: "UtilityCategory");

            migrationBuilder.RenameTable(
                name: "Utilities",
                newName: "Utility");

            migrationBuilder.RenameTable(
                name: "HotelUtilities",
                newName: "HotelUtility");

            migrationBuilder.RenameIndex(
                name: "IX_Utilities_UtilityCategoryId",
                table: "Utility",
                newName: "IX_Utility_UtilityCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelUtilities_UtilityId",
                table: "HotelUtility",
                newName: "IX_HotelUtility_UtilityId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelUtilities_HotelId",
                table: "HotelUtility",
                newName: "IX_HotelUtility_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilityCategory",
                table: "UtilityCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utility",
                table: "Utility",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelUtility",
                table: "HotelUtility",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelUtility_Hotels_HotelId",
                table: "HotelUtility",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelUtility_Utility_UtilityId",
                table: "HotelUtility",
                column: "UtilityId",
                principalTable: "Utility",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Utility_UtilityCategory_UtilityCategoryId",
                table: "Utility",
                column: "UtilityCategoryId",
                principalTable: "UtilityCategory",
                principalColumn: "Id");
        }
    }
}
