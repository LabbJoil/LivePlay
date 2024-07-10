using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivePlay.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LivePlayDb_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "News",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "News");
        }
    }
}
