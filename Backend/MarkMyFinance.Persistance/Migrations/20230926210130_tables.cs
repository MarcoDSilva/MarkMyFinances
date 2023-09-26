using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkMyFinance.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InitialBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateOfBudget = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExpectedReturn = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(424), "UNKOWN", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(549) },
                    { 2, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(559), "Income", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(561) },
                    { 3, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(564), "Home", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(565) },
                    { 4, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(568), "Technology", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(570) },
                    { 5, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(572), "Entertainment", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(574) },
                    { 6, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(578), "Utilities", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(580) },
                    { 7, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(582), "Transportation", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(584) },
                    { 8, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(586), "Pets", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(588) },
                    { 9, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(591), "Health", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(593) },
                    { 10, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(596), "Everyday", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(598) }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(650), "UNKNOWN", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(653) },
                    { 2, 2, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(657), "Wages", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(659) },
                    { 3, 2, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(662), "Other", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(664) },
                    { 4, 3, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(666), "Rent", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(668) },
                    { 5, 6, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(670), "Electricity", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(672) },
                    { 6, 6, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(675), "Gas", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(677) },
                    { 7, 6, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(679), "Water", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(681) },
                    { 8, 6, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(683), "Internet", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(685) },
                    { 9, 9, new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(688), "Food", new DateTime(2023, 9, 26, 22, 1, 29, 892, DateTimeKind.Local).AddTicks(689) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "SubCategories");
        }
    }
}
