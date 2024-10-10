using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionDeProductosYServicios.Migrations
{
    /// <inheritdoc />
    public partial class createdCategoryFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carriers",
                keyColumn: "carrier_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carriers",
                keyColumn: "carrier_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carriers",
                keyColumn: "carrier_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carriers",
                keyColumn: "carrier_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Carriers",
                keyColumn: "carrier_id",
                keyValue: 6);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category_description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "carrier_id", "carrier_description", "carrier_name" },
                values: new object[,]
                {
                    { 2, "Illum temporibus et ullam.", "Estel" },
                    { 3, "Modi inventore provident optio qui.", "Lilian" },
                    { 4, "Quas minus est eligendi aspernatur omnis nesciunt modi.", "Emilia" },
                    { 5, "Fugit aut aut.", "Oleta" },
                    { 6, "Facere exercitationem est aperiam.", "Abby" }
                });
        }
    }
}
