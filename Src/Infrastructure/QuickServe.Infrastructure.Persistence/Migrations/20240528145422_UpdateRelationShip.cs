using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickServe.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTemplates_Stores_StoreId",
                table: "ProductTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ProductTemplates_StoreId",
                table: "ProductTemplates");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ProductTemplates");

            migrationBuilder.AddColumn<long>(
                name: "ProductTemplateId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SessionId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTemplateId",
                table: "Products",
                column: "ProductTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SessionId",
                table: "Orders",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Account_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sessions_SessionId",
                table: "Orders",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTemplates_ProductTemplateId",
                table: "Products",
                column: "ProductTemplateId",
                principalTable: "ProductTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Account_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sessions_SessionId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTemplates_ProductTemplateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTemplateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SessionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductTemplateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "ProductTemplates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTemplates_StoreId",
                table: "ProductTemplates",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTemplates_Stores_StoreId",
                table: "ProductTemplates",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
