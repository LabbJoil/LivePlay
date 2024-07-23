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
            migrationBuilder.RenameColumn(
                name: "Coupon",
                table: "Coupon",
                newName: "CouponData");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "CouponData",
                table: "Coupon",
                newName: "Coupon");
        }
    }
}
