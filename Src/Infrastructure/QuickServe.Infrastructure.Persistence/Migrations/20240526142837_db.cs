using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickServe.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 40, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 40, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Payment_type = table.Column<int>(type: "int", unicode: false, maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Ingredient_Id = table.Column<long>(type: "bigint", nullable: false),
                    Order_Id = table.Column<long>(type: "bigint", nullable: false),
                    Store_Id = table.Column<long>(type: "bigint", nullable: false),
                    Start_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    End_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Calo = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image_Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IngredientType_id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "ingredient_ingredienttype_id_foreign",
                        column: x => x.IngredientType_id,
                        principalTable: "IngredientType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_method_id = table.Column<long>(type: "bigint", nullable: false),
                    Customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Store_id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "order_payment_method_id_foreign",
                        column: x => x.Payment_method_id,
                        principalTable: "Payment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "order_store_id_foreign",
                        column: x => x.Store_id,
                        principalTable: "Store",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Store_id = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "producttemplate_categoryid_foreign",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "producttemplate_store_id_foreign",
                        column: x => x.Store_id,
                        principalTable: "Store",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientSession",
                columns: table => new
                {
                    Session_Id = table.Column<long>(type: "bigint", nullable: false),
                    Ingredient_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ingredie__455B9AFE7F7A4C49", x => new { x.Session_Id, x.Ingredient_Id });
                    table.ForeignKey(
                        name: "FK__Ingredien__Ingre__60A75C0F",
                        column: x => x.Ingredient_Id,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ingredien__Sessi__619B8048",
                        column: x => x.Session_Id,
                        principalTable: "Session",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nutrition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingredient_id = table.Column<long>(type: "bigint", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Vitamin = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    HealthValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nutrition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrition", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Nutrition__Nutri__03F0984C",
                        column: x => x.Ingredient_id,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductTemplate_Id = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTemplate_ID",
                        column: x => x.ProductTemplate_Id,
                        principalTable: "ProductTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateStep",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTemplate_Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateStep", x => x.Id);
                    table.ForeignKey(
                        name: "templatestep_proucttemplate_id_foreign",
                        column: x => x.ProductTemplate_Id,
                        principalTable: "ProductTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientProducts_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderProd__Order__2A164134",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderProd__Produ__2B0A656D",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientType_TemplateStep",
                columns: table => new
                {
                    IngredientType_Id = table.Column<long>(type: "bigint", nullable: false),
                    TemplateStep_Id = table.Column<long>(type: "bigint", nullable: false),
                    Quantity_Min = table.Column<int>(type: "int", nullable: false),
                    Quantity_Max = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ingredie__D37B8AD7132C9711", x => new { x.IngredientType_Id, x.TemplateStep_Id });
                    table.ForeignKey(
                        name: "IngredientType_templateStep_ingredienttype_id_foreign",
                        column: x => x.IngredientType_Id,
                        principalTable: "IngredientType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ingredienttype_templatestep_templatestep_id_foreign",
                        column: x => x.TemplateStep_Id,
                        principalTable: "TemplateStep",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientType_id",
                table: "Ingredient",
                column: "IngredientType_id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientProducts_IngredientId",
                table: "IngredientProducts",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientProducts_ProductId",
                table: "IngredientProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSession_Ingredient_Id",
                table: "IngredientSession",
                column: "Ingredient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientType_TemplateStep_TemplateStep_Id",
                table: "IngredientType_TemplateStep",
                column: "TemplateStep_Id");

            migrationBuilder.CreateIndex(
                name: "IX_News_AccountId",
                table: "News",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "UQ__Nutritio__C90398E29135F4A4",
                table: "Nutrition",
                column: "Ingredient_id",
                unique: true,
                filter: "[Ingredient_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderID",
                table: "OrderProduct",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Payment_method_id",
                table: "Orders",
                column: "Payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Store_id",
                table: "Orders",
                column: "Store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTemplate_Id",
                table: "Product",
                column: "ProductTemplate_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTemplate_Category_Id",
                table: "ProductTemplate",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTemplate_Store_id",
                table: "ProductTemplate",
                column: "Store_id");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateStep_ProductTemplate_Id",
                table: "TemplateStep",
                column: "ProductTemplate_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientProducts");

            migrationBuilder.DropTable(
                name: "IngredientSession");

            migrationBuilder.DropTable(
                name: "IngredientType_TemplateStep");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Nutrition");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "TemplateStep");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "IngredientType");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ProductTemplate");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
