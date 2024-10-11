using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDeProductosYServicios.Migrations
{
    /// <inheritdoc />
    public partial class CreatedShipmentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    shipments_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    shipments_weight_kg = table.Column<double>(type: "double", nullable: false),
                    shipments_price_usa = table.Column<double>(type: "double", nullable: false),
                    shipment_order_date = table.Column<DateOnly>(type: "date", nullable: true),
                    shipment_arrival_date = table.Column<DateOnly>(type: "date", nullable: true),
                    carrier_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.shipments_id);
                    table.ForeignKey(
                        name: "FK_Shipments_Carriers_carrier_id",
                        column: x => x.carrier_id,
                        principalTable: "Carriers",
                        principalColumn: "carrier_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_carrier_id",
                table: "Shipments",
                column: "carrier_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
