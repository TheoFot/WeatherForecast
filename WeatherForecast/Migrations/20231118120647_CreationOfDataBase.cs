using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherForecast.Migrations
{
    /// <inheritdoc />
    public partial class CreationOfDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    TemperatureMin = table.Column<float>(type: "real", nullable: false),
                    Temperature_Max = table.Column<float>(type: "real", nullable: false),
                    Clouds = table.Column<int>(type: "int", nullable: false),
                    SunRise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SunSet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeedOfWind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_Cities_CitiId",
                        column: x => x.CitiId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_CitiId",
                table: "Weather",
                column: "CitiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
