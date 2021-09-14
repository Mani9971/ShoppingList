using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Dal.Migrations
{
    public partial class addedNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_Product_ProductId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCart_ShoppingListId",
                table: "ShoppingCartProducts");

            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "ShoppingCartProducts",
                newName: "ShoppingCartsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingCartProducts",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProducts_ShoppingListId",
                table: "ShoppingCartProducts",
                newName: "IX_ShoppingCartProducts_ShoppingCartsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_Product_ProductsId",
                table: "ShoppingCartProducts",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCart_ShoppingCartsId",
                table: "ShoppingCartProducts",
                column: "ShoppingCartsId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_Product_ProductsId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCart_ShoppingCartsId",
                table: "ShoppingCartProducts");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartsId",
                table: "ShoppingCartProducts",
                newName: "ShoppingListId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ShoppingCartProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProducts_ShoppingCartsId",
                table: "ShoppingCartProducts",
                newName: "IX_ShoppingCartProducts_ShoppingListId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_Product_ProductId",
                table: "ShoppingCartProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_ShoppingCart_ShoppingListId",
                table: "ShoppingCartProducts",
                column: "ShoppingListId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
