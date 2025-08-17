using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllInOne.Infrastructure.Data.Migrations;

  /// <inheritdoc />
  public partial class AddedTableProducts : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "ProductCategories",
              columns: table => new
              {
                  Id = table.Column<int>(type: "INTEGER", nullable: false)
                      .Annotation("Sqlite:Autoincrement", true),
                  CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                  UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                  CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                  UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_ProductCategories", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "Product",
              columns: table => new
              {
                  Id = table.Column<int>(type: "INTEGER", nullable: false)
                      .Annotation("Sqlite:Autoincrement", true),
                  ProductName = table.Column<string>(type: "TEXT", nullable: false),
                  Price = table.Column<decimal>(type: "TEXT", nullable: false),
                  Description = table.Column<string>(type: "TEXT", nullable: false),
                  ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                  Image = table.Column<byte[]>(type: "BLOB", nullable: true),
                  CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                  ProductRating = table.Column<int>(type: "INTEGER", nullable: false),
                  NumberOfReviews = table.Column<int>(type: "INTEGER", nullable: false),
                  ProductFeatures = table.Column<string>(type: "TEXT", nullable: false),
                  PrintType = table.Column<string>(type: "TEXT", nullable: false),
                  PaperQuality = table.Column<string>(type: "TEXT", nullable: false),
                  TurnaroudnTime = table.Column<int>(type: "INTEGER", nullable: false),
                  MinimumOrderQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                  UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                  CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                  UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Product", x => x.Id);
                  table.ForeignKey(
                      name: "FK_Product_ProductCategories_CategoryId",
                      column: x => x.CategoryId,
                      principalTable: "ProductCategories",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
              });

          migrationBuilder.CreateIndex(
              name: "IX_Product_CategoryId",
              table: "Product",
              column: "CategoryId");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "Product");

          migrationBuilder.DropTable(
              name: "ProductCategories");
      }
  }
