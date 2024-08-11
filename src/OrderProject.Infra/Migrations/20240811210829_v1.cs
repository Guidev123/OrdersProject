﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProject.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(254)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(254)", nullable: true),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Percentage = table.Column<decimal>(type: "MONEY", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "MONEY", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoucherUsed = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<decimal>(type: "MONEY", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "MONEY", nullable: false),
                    StatusOrder = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Number = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Complement = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Neighborhood = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    PostalCode = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    City = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    State = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitaryValue = table.Column<decimal>(type: "MONEY", nullable: false),
                    ProductImage = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItens_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItens_OrderId",
                table: "OrderItens",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VoucherId",
                table: "Orders",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
