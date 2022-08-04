using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class UpdateDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_cartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_feedBackUsers_AspNetUsers_userId",
                table: "feedBackUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_feedBackUsers_Products_productId",
                table: "feedBackUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_Carts_cartId",
                table: "ProductCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCarts_Products_productId",
                table: "ProductCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_productOrders_Orders_OrderId",
                table: "productOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_productOrders_Products_ProductId",
                table: "productOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_categories_categoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productOrders",
                table: "productOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCarts",
                table: "ProductCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_feedBackUsers",
                table: "feedBackUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "productOrders",
                newName: "ProductOrder");

            migrationBuilder.RenameTable(
                name: "ProductCarts",
                newName: "ProductCart");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "feedBackUsers",
                newName: "FeedBackUser");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryId",
                table: "Product",
                newName: "IX_Product_categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_productOrders_ProductId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productOrders_OrderId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCarts_productId",
                table: "ProductCart",
                newName: "IX_ProductCart_productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCarts_cartId",
                table: "ProductCart",
                newName: "IX_ProductCart_cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userId",
                table: "Order",
                newName: "IX_Order_userId");

            migrationBuilder.RenameIndex(
                name: "IX_feedBackUsers_userId",
                table: "FeedBackUser",
                newName: "IX_FeedBackUser_userId");

            migrationBuilder.RenameIndex(
                name: "IX_feedBackUsers_productId",
                table: "FeedBackUser",
                newName: "IX_FeedBackUser_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBackUser",
                table: "FeedBackUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cart_cartId",
                table: "AspNetUsers",
                column: "cartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBackUser_AspNetUsers_userId",
                table: "FeedBackUser",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBackUser_Product_productId",
                table: "FeedBackUser",
                column: "productId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_userId",
                table: "Order",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Cart_cartId",
                table: "ProductCart",
                column: "cartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Product_productId",
                table: "ProductCart",
                column: "productId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Order_OrderId",
                table: "ProductOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Product_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cart_cartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBackUser_AspNetUsers_userId",
                table: "FeedBackUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBackUser_Product_productId",
                table: "FeedBackUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_userId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Cart_cartId",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Product_productId",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Order_OrderId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Product_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBackUser",
                table: "FeedBackUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "ProductOrder",
                newName: "productOrders");

            migrationBuilder.RenameTable(
                name: "ProductCart",
                newName: "ProductCarts");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "FeedBackUser",
                newName: "feedBackUsers");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_ProductId",
                table: "productOrders",
                newName: "IX_productOrders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_OrderId",
                table: "productOrders",
                newName: "IX_productOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCart_productId",
                table: "ProductCarts",
                newName: "IX_ProductCarts_productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCart_cartId",
                table: "ProductCarts",
                newName: "IX_ProductCarts_cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_categoryId",
                table: "Products",
                newName: "IX_Products_categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_userId",
                table: "Orders",
                newName: "IX_Orders_userId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBackUser_userId",
                table: "feedBackUsers",
                newName: "IX_feedBackUsers_userId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBackUser_productId",
                table: "feedBackUsers",
                newName: "IX_feedBackUsers_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productOrders",
                table: "productOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCarts",
                table: "ProductCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedBackUsers",
                table: "feedBackUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_cartId",
                table: "AspNetUsers",
                column: "cartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_feedBackUsers_AspNetUsers_userId",
                table: "feedBackUsers",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_feedBackUsers_Products_productId",
                table: "feedBackUsers",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_Carts_cartId",
                table: "ProductCarts",
                column: "cartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCarts_Products_productId",
                table: "ProductCarts",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productOrders_Orders_OrderId",
                table: "productOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productOrders_Products_ProductId",
                table: "productOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_categories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
