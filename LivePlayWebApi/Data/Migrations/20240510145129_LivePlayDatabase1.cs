using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LivePlayWebApi.Migrations
{
    /// <inheritdoc />
    public partial class LivePlayDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoneQuest");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Quest");

            migrationBuilder.RenameColumn(
                name: "TitleView",
                table: "Quest",
                newName: "DescriptionMini");

            migrationBuilder.RenameColumn(
                name: "DescriptionView",
                table: "Quest",
                newName: "DescriptionFull");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinalDate",
                table: "Quest",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    Cost = table.Column<int>(type: "integer", nullable: false),
                    Coupon = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AwardUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AwardId = table.Column<int>(type: "integer", nullable: false),
                    GetDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardUser", x => x.Id);
                    table.ForeignKey(
                       "FK_user_awarduser", x => x.UserId,
                       principalTable: "User",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade,
                       onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                       "FK_award_awarduser", x => x.AwardId,
                       principalTable: "Award",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade,
                       onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    QuestId = table.Column<int>(type: "integer", nullable: false),
                    GetDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestUser", x => x.Id);
                    table.ForeignKey(
                       "FK_user_questuser", x => x.UserId,
                       principalTable: "User",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade,
                       onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_quest_questuser", x => x.QuestId,
                        principalTable: "Quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "AwardUser");

            migrationBuilder.DropTable(
                name: "QuestUser");

            migrationBuilder.DropColumn(
                name: "FinalDate",
                table: "Quest");

            migrationBuilder.RenameColumn(
                name: "DescriptionMini",
                table: "Quest",
                newName: "TitleView");

            migrationBuilder.RenameColumn(
                name: "DescriptionFull",
                table: "Quest",
                newName: "DescriptionView");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Quest",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DoneQuest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoneQuest", x => x.Id);
                });
        }
    }
}
