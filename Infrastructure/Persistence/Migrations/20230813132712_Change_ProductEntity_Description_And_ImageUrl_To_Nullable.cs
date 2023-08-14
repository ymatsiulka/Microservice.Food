using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservice.Food.Migrations
{
    /// <inheritdoc />
    public partial class Change_ProductEntity_Description_And_ImageUrl_To_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_category_entity_product_entity_category_entity_categories_id",
                table: "category_entity_product_entity");

            migrationBuilder.DropForeignKey(
                name: "fk_category_entity_product_entity_product_entity_products_id",
                table: "category_entity_product_entity");

            migrationBuilder.DropForeignKey(
                name: "fk_order_product_product_entity_product_id",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "fk_product_category_product_entity_product_id",
                table: "ProductCategory");

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "Product",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Product",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "fk_category_entity_product_entity_categories_categories_id",
                table: "category_entity_product_entity",
                column: "categories_id",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_category_entity_product_entity_products_products_id",
                table: "category_entity_product_entity",
                column: "products_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_product_products_product_id",
                table: "OrderProduct",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_category_products_product_id",
                table: "ProductCategory",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_category_entity_product_entity_categories_categories_id",
                table: "category_entity_product_entity");

            migrationBuilder.DropForeignKey(
                name: "fk_category_entity_product_entity_products_products_id",
                table: "category_entity_product_entity");

            migrationBuilder.DropForeignKey(
                name: "fk_order_product_products_product_id",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "fk_product_category_products_product_id",
                table: "ProductCategory");

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_category_entity_product_entity_category_entity_categories_id",
                table: "category_entity_product_entity",
                column: "categories_id",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_category_entity_product_entity_product_entity_products_id",
                table: "category_entity_product_entity",
                column: "products_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_product_product_entity_product_id",
                table: "OrderProduct",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_category_product_entity_product_id",
                table: "ProductCategory",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
