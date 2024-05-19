using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickServe.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ConfirmationToken = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 255, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
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
                    Payment_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('0')"),
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
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Ingredient_Id = table.Column<long>(type: "bigint", nullable: false),
                    Order_Id = table.Column<long>(type: "bigint", nullable: false),
                    Store_Id = table.Column<long>(type: "bigint", nullable: false),
                    Start_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    End_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Is_Delete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('0')"),
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
                name: "FeedBack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_Id = table.Column<long>(type: "bigint", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBack", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FeedBack__Accoun__06CD04F7",
                        column: x => x.Account_Id,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_Id = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
                    LastModified = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "news_account_id_foreign",
                        column: x => x.Account_Id,
                        principalTable: "Account",
                        principalColumn: "Id");
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
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_method_id = table.Column<long>(type: "bigint", nullable: false),
                    Account_id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Total_price = table.Column<double>(type: "float", nullable: false),
                    Store_id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "order_account_id_foreign",
                        column: x => x.Account_id,
                        principalTable: "Account",
                        principalColumn: "Id");
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
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Store_id = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vitamin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HealthValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nutrition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: true),
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
                name: "IngredientProduct",
                columns: table => new
                {
                    Product_id = table.Column<long>(type: "bigint", nullable: false),
                    Ingredient_id = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ingredie__F080A71ADF39F2B5", x => new { x.Ingredient_id, x.Product_id });
                    table.ForeignKey(
                        name: "FK__Ingredien__Ingre__5EBF139D",
                        column: x => x.Ingredient_id,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ingredien__Produ__5FB337D6",
                        column: x => x.Product_id,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderPro__08D097C182F2AEC7", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK__OrderProd__Order__2A164134",
                        column: x => x.OrderID,
                        principalTable: "Order",
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
                name: "IX_FeedBack_Account_Id",
                table: "FeedBack",
                column: "Account_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientType_id",
                table: "Ingredient",
                column: "IngredientType_id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientProduct_Product_id",
                table: "IngredientProduct",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSession_Ingredient_Id",
                table: "IngredientSession",
                column: "Ingredient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientType_TemplateStep_TemplateStep_Id",
                table: "IngredientType_TemplateStep",
                column: "TemplateStep_Id");

            migrationBuilder.CreateIndex(
                name: "IX_News_Account_Id",
                table: "News",
                column: "Account_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Nutritio__C90398E29135F4A4",
                table: "Nutrition",
                column: "Ingredient_id",
                unique: true,
                filter: "[Ingredient_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Account_id",
                table: "Order",
                column: "Account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Payment_method_id",
                table: "Order",
                column: "Payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Store_id",
                table: "Order",
                column: "Store_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

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
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "IngredientProduct");

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
                name: "Session");

            migrationBuilder.DropTable(
                name: "TemplateStep");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "IngredientType");

            migrationBuilder.DropTable(
                name: "Account");

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
