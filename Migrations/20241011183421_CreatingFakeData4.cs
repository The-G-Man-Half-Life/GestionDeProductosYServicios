using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionDeProductosYServicios.Migrations
{
    /// <inheritdoc />
    public partial class CreatingFakeData4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    carrier_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    carrier_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    carrier_description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.carrier_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    client_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    client_address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    client_contact = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.client_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_price = table.Column<double>(type: "double", nullable: false),
                    product_description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_creation_date = table.Column<DateOnly>(type: "date", nullable: true),
                    order_delivery_date = table.Column<DateOnly>(type: "date", nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    carrier_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Carriers_carrier_id",
                        column: x => x.carrier_id,
                        principalTable: "Carriers",
                        principalColumn: "carrier_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shipments_Products",
                columns: table => new
                {
                    Shipment_Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_amount = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    shipment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments_Products", x => x.Shipment_Product_id);
                    table.ForeignKey(
                        name: "FK_Shipments_Products_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_Products_Shipments_shipment_id",
                        column: x => x.shipment_id,
                        principalTable: "Shipments",
                        principalColumn: "shipments_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products_orders",
                columns: table => new
                {
                    product_order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_orders", x => x.product_order_id);
                    table.ForeignKey(
                        name: "FK_Products_orders_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_orders_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "carrier_id", "carrier_description", "carrier_name" },
                values: new object[,]
                {
                    { 1, "Soluta voluptas exercitationem.", "Maegan" },
                    { 2, "Aut enim earum.", "Oswald" },
                    { 3, "Iste sequi ipsam et porro ducimus minus.", "Keaton" },
                    { 4, "Distinctio pariatur aut fugiat debitis.", "Reese" },
                    { 5, "Rerum eum quis nemo eum inventore et qui facere sit.", "Alena" },
                    { 6, "Rerum repudiandae esse doloremque officia dolor.", "Brandi" },
                    { 7, "Animi nihil magnam qui natus quis non impedit.", "Claudie" },
                    { 8, "Veniam ducimus culpa quae odit fuga ratione eos.", "Betty" },
                    { 9, "Ut asperiores aliquid nostrum mollitia.", "Floy" },
                    { 10, "Atque illo neque odit quis reprehenderit aut excepturi facere.", "Aileen" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_description", "category_name" },
                values: new object[,]
                {
                    { 1, "Ipsa voluptates est officia corporis aut.", "Jewelery" },
                    { 2, "Qui incidunt similique cum voluptate deleniti.", "Games" },
                    { 3, "Sequi et at aliquam aut eum aperiam unde non perferendis.", "Computers" },
                    { 4, "Quam consectetur et id ipsam.", "Tools" },
                    { 5, "Placeat similique ut voluptatem.", "Electronics" },
                    { 6, "Voluptas sequi unde nihil est.", "Outdoors" },
                    { 7, "Commodi quia neque aut.", "Clothing" },
                    { 8, "Nobis officia quas alias dolorem sint.", "Health" },
                    { 9, "Dolores vero perferendis et ut eligendi assumenda.", "Baby" },
                    { 10, "Eum delectus suscipit modi et aut nulla.", "Garden" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "client_id", "client_address", "client_contact", "client_name" },
                values: new object[,]
                {
                    { 1, "8201 Kemmer Squares, New Anastaciotown, French Guiana", "1-637-567-0570", "Jared Labadie" },
                    { 2, "40792 Armstrong Circles, Maybellborough, Lao People's Democratic Republic", "1-222-454-5771 x8047", "Freddie Lowe" },
                    { 3, "658 Joyce Crescent, Lake Marquiseside, Bahrain", "1-942-834-7627 x94474", "Guadalupe Von" },
                    { 4, "610 Eliza Plaza, Kesslerside, Nepal", "790-838-9011", "Leilani Zieme" },
                    { 5, "884 Tromp Groves, East Elise, Togo", "1-286-856-1700", "Johnathan Hickle" },
                    { 6, "9871 Kelli Hills, Lake Rossville, Somalia", "209.764.7554 x61962", "Buford Schiller" },
                    { 7, "644 Osinski Pines, Konopelskibury, Cocos (Keeling) Islands", "1-477-449-9315 x497", "Dwight Hyatt" },
                    { 8, "830 Tremblay Ports, New Sallieburgh, Portugal", "1-259-859-0370 x28205", "John Tromp" },
                    { 9, "45887 Gleason Lakes, South Luis, Lebanon", "(436) 835-9841 x353", "Heaven Barton" },
                    { 10, "819 Kerluke Shoals, East Libby, Afghanistan", "316-897-4002 x8407", "Thea Kunze" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "order_id", "carrier_id", "client_id", "order_creation_date", "order_delivery_date" },
                values: new object[,]
                {
                    { 1, 3, 3, new DateOnly(2024, 8, 12), new DateOnly(2025, 8, 28) },
                    { 2, 5, 10, new DateOnly(2023, 12, 5), new DateOnly(2025, 7, 8) },
                    { 3, 1, 9, new DateOnly(2024, 7, 23), new DateOnly(2025, 6, 8) },
                    { 4, 1, 5, new DateOnly(2024, 8, 4), new DateOnly(2025, 9, 25) },
                    { 5, 9, 7, new DateOnly(2023, 11, 5), new DateOnly(2025, 8, 9) },
                    { 6, 6, 6, new DateOnly(2024, 4, 4), new DateOnly(2025, 9, 24) },
                    { 7, 7, 1, new DateOnly(2024, 3, 13), new DateOnly(2024, 11, 7) },
                    { 8, 8, 3, new DateOnly(2024, 7, 7), new DateOnly(2025, 6, 2) },
                    { 9, 6, 5, new DateOnly(2023, 10, 20), new DateOnly(2025, 4, 9) },
                    { 10, 8, 1, new DateOnly(2024, 10, 4), new DateOnly(2025, 6, 23) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "product_id", "category_id", "product_description", "product_name", "product_price" },
                values: new object[,]
                {
                    { 1, 1, "Corrupti nisi labore voluptas nostrum atque ut iure provident eum.", "Tasty Plastic Keyboard", 409.5720323223282 },
                    { 2, 2, "Ut ut odio et ipsa voluptates autem non nihil tempore.", "Sleek Granite Pants", 573.89677136887735 },
                    { 3, 3, "Rem accusantium laudantium dolores earum enim eos eos dignissimos qui.", "Generic Steel Table", 140.55605132023553 },
                    { 4, 5, "Excepturi quis autem sed totam vel expedita excepturi iusto beatae.", "Handcrafted Rubber Hat", 969.82605508244501 },
                    { 5, 10, "Sit dolores facere aut veritatis harum sit et magnam aspernatur.", "Handmade Rubber Cheese", 972.44700596112591 },
                    { 6, 2, "Eos nostrum quisquam delectus enim similique rerum cupiditate quas quis.", "Unbranded Wooden Shoes", 871.02646594924954 },
                    { 7, 7, "Qui ex quis qui sunt itaque voluptate doloremque eius non.", "Small Granite Chair", 676.49630082857027 },
                    { 8, 9, "Ea praesentium doloribus aut illum quae dignissimos consectetur animi aspernatur.", "Gorgeous Soft Soap", 898.02884981224224 },
                    { 9, 9, "Aliquid similique et reiciendis delectus a tempora maiores libero qui.", "Gorgeous Soft Keyboard", 880.18874235449789 },
                    { 10, 3, "Et perspiciatis culpa fugiat corrupti iusto quia libero deleniti error.", "Tasty Plastic Shoes", 285.7534639812763 }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "shipments_id", "carrier_id", "shipment_arrival_date", "shipment_order_date", "shipments_price_usa", "shipments_weight_kg" },
                values: new object[,]
                {
                    { 1, 3, new DateOnly(2024, 6, 15), new DateOnly(2024, 2, 17), 485.74970141600613, 12.844849072067436 },
                    { 2, 8, new DateOnly(2024, 1, 5), new DateOnly(2024, 9, 9), 180.95674926761703, 55.063571212502907 },
                    { 3, 5, new DateOnly(2024, 8, 30), new DateOnly(2024, 10, 10), 25.220947322356988, 38.895700999402699 },
                    { 4, 6, new DateOnly(2024, 4, 2), new DateOnly(2024, 9, 29), 283.31120829789887, 4.4869762026088509 },
                    { 5, 2, new DateOnly(2024, 2, 18), new DateOnly(2024, 5, 1), 209.20116698286904, 18.309228480485441 },
                    { 6, 6, new DateOnly(2024, 3, 8), new DateOnly(2024, 4, 14), 118.3841736941496, 82.424162793112401 },
                    { 7, 10, new DateOnly(2024, 3, 23), new DateOnly(2024, 2, 24), 493.44786560371443, 61.32309211454421 },
                    { 8, 10, new DateOnly(2024, 8, 9), new DateOnly(2024, 3, 8), 110.59536197434291, 63.252616687683052 },
                    { 9, 1, new DateOnly(2024, 9, 27), new DateOnly(2024, 6, 3), 50.749999914438462, 24.272440556880568 },
                    { 10, 3, new DateOnly(2024, 10, 7), new DateOnly(2024, 9, 27), 100.40527171637493, 11.683610219677531 }
                });

            migrationBuilder.InsertData(
                table: "Products_orders",
                columns: new[] { "product_order_id", "order_id", "product_id", "product_quantity" },
                values: new object[,]
                {
                    { 1, 8, 8, 2 },
                    { 2, 7, 2, 3 },
                    { 3, 2, 3, 8 },
                    { 4, 8, 5, 3 },
                    { 5, 9, 7, 2 },
                    { 6, 9, 1, 8 },
                    { 7, 7, 2, 8 },
                    { 8, 6, 4, 3 },
                    { 9, 10, 2, 2 },
                    { 10, 10, 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "Shipments_Products",
                columns: new[] { "Shipment_Product_id", "product_amount", "product_id", "shipment_id" },
                values: new object[,]
                {
                    { 1, 64, 5, 6 },
                    { 2, 49, 1, 4 },
                    { 3, 31, 8, 7 },
                    { 4, 8, 9, 8 },
                    { 5, 61, 1, 1 },
                    { 6, 100, 9, 4 },
                    { 7, 83, 5, 9 },
                    { 8, 45, 10, 5 },
                    { 9, 38, 10, 2 },
                    { 10, 56, 9, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_carrier_id",
                table: "Orders",
                column: "carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_client_id",
                table: "Orders",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_orders_order_id",
                table: "Products_orders",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_orders_product_id",
                table: "Products_orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_carrier_id",
                table: "Shipments",
                column: "carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_Products_product_id",
                table: "Shipments_Products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_Products_shipment_id",
                table: "Shipments_Products",
                column: "shipment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_orders");

            migrationBuilder.DropTable(
                name: "Shipments_Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Carriers");
        }
    }
}
