using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApi.Core.Migrations
{
    public partial class thirdMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailItems_OrderItems_OrderId",
                table: "OrderDetailItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersItems",
                table: "UsersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailItems",
                table: "OrderDetailItems");

            migrationBuilder.RenameTable(
                name: "UsersItems",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderDetailItems",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailItems_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UsersItems");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetailItems");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetailItems",
                newName: "IX_OrderDetailItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersItems",
                table: "UsersItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailItems",
                table: "OrderDetailItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailItems_OrderItems_OrderId",
                table: "OrderDetailItems",
                column: "OrderId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
