using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoCodesProcessor.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promo_Codes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount_Type = table.Column<int>(type: "int", nullable: false),
                    Discount_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shipping_Free = table.Column<bool>(type: "bit", nullable: false),
                    Minimum_Order = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Multiple_Use = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo_Codes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redeems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Promos_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redeems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promo_Product_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Promo_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo_Product_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promo_Product_Categories_Promo_Codes_Promo_CodesId",
                        column: x => x.Promo_Id,
                        principalTable: "Promo_Codes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Promo_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Promo_Id = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promo_Users_Promo_Codes_Promo_CodesId",
                        column: x => x.Promo_Id,
                        principalTable: "Promo_Codes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promo_Codes_Name",
                table: "Promo_Codes",
                column: "Name",
                unique: true);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Promo_Product_Categories");

            migrationBuilder.DropTable(
                name: "Promo_Users");

            migrationBuilder.DropTable(
                name: "Redeems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Promo_Codes");
        }
    }
}
