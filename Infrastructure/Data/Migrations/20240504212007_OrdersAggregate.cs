using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrdersAggregate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryTime = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<long>(type: "INTEGER", nullable: false),
                    ShippedToAddress_FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_LastName = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_City = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_State = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_Street = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_Building = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_Appartment = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_ZIPCode = table.Column<string>(type: "TEXT", nullable: true),
                    ShippedToAddress_Mark = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryMethodId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentIntentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    SubTotal = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductOrderItem_ProductItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductOrderItem_ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductOrderItem_ProductPictureURL = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");
        }
    }
}
