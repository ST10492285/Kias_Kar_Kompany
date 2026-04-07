using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kias_Kar_Kompany.Migrations
{
    /// <inheritdoc />
    public partial class Mick : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ManufacturerId",
                table: "Vehicle",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Manufacturer_ManufacturerId",
                table: "Vehicle",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Manufacturer_ManufacturerId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ManufacturerId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Vehicle");
        }
    }
}
