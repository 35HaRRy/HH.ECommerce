using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HH.ECommerce.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    CustomerType = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    IsRatePercentage = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", maxLength: 25, nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsGroceries = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "TEXT", maxLength: 30, nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", maxLength: 30, nullable: false),
                    DerivedProductCost = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    TotalDerivedCost = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerType", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 1, "3008 North Bend River Road", "Customer", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer1@email.com", "Sheldon", "Cooper", "Lee", "123456789" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerType", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 2, "4592 Chapel Street", "Customer", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer2@email.com", "Leonard", "Hoffsteder", "Lee", "12345678910" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerType", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 3, "2306 Bird Street", "Affiliate", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer3@email.com", "Penny", "Jackson", "L.", "123456789" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerType", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 4, "3229 Counts Lane", "Employee", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer4@email.com", "Amy", "Fowler", null, "123456789" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerType", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 5, "1608 Ashton Lane", "Employee", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer5@email.com", "Raj", "Koothrappali", null, "123456789" });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 1, true, "Affiliate Discount", 10m, "Affiliate" });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 2, true, "Employee Discount", 30m, "Employee" });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 3, true, "Loyal Customer Discount", 5m, "Customer" });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[] { 4, false, "Price Discount", 5m, "Price" });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "InvoiceId", "CustomerId", "DateCreated", "InvoiceNumber", "OrderId", "OrderTotal", "Total" },
                values: new object[] { 1, 1, new DateTime(2023, 1, 2, 10, 52, 16, 822, DateTimeKind.Local).AddTicks(1179), "SRU001", 1, 0m, 500m });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "InvoiceId", "CustomerId", "DateCreated", "InvoiceNumber", "OrderId", "OrderTotal", "Total" },
                values: new object[] { 2, 2, new DateTime(2023, 1, 2, 10, 52, 16, 822, DateTimeKind.Local).AddTicks(2907), "SRU002", 2, 0m, 1500m });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "InvoiceId", "CustomerId", "DateCreated", "InvoiceNumber", "OrderId", "OrderTotal", "Total" },
                values: new object[] { 3, 3, new DateTime(2023, 1, 2, 10, 52, 16, 822, DateTimeKind.Local).AddTicks(2912), "SRU003", 3, 0m, 990m });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "InvoiceId", "CustomerId", "DateCreated", "InvoiceNumber", "OrderId", "OrderTotal", "Total" },
                values: new object[] { 4, 4, new DateTime(2023, 1, 2, 10, 52, 16, 822, DateTimeKind.Local).AddTicks(2913), "SRU004", 4, 0m, 920m });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DerivedProductCost", "DiscountPrice", "InvoiceId", "IsGroceries", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[] { 1, 40m, 2m, 1, false, 2, "Item 2", 20m, 2, 38m });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DerivedProductCost", "DiscountPrice", "InvoiceId", "IsGroceries", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[] { 2, 482m, 20m, 1, false, 4, "Item 4", 482m, 1, 462m });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DerivedProductCost", "DiscountPrice", "InvoiceId", "IsGroceries", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[] { 3, 250m, 0m, 2, false, 40, "Item 40", 50m, 5, 250m });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DerivedProductCost", "DiscountPrice", "InvoiceId", "IsGroceries", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[] { 4, 250m, 25m, 3, false, 3, "Item 3", 50m, 5, 225m });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DerivedProductCost", "DiscountPrice", "InvoiceId", "IsGroceries", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[] { 5, 400m, 20m, 3, false, 5, "Item 5", 400m, 1, 380m });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DerivedProductCost", "DiscountPrice", "InvoiceId", "IsGroceries", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[] { 6, 385m, 0m, 3, true, 15, "Item 15", 77m, 5, 385m });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "DerivedProductCost", "DiscountPrice", "InvoiceId", "IsGroceries", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[] { 7, 1000m, 80m, 4, false, 105, "Item 105", 200m, 5, 920m });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
