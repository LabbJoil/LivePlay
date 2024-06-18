using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivePlay.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LivePlayDb_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Hotel_HotelEntityModelId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_HotelEntityModelId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HotelEntityModelId",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelEntityModelId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_HotelEntityModelId",
                table: "User",
                column: "HotelEntityModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Hotel_HotelEntityModelId",
                table: "User",
                column: "HotelEntityModelId",
                principalTable: "Hotel",
                principalColumn: "Id");
        }
    }
}
