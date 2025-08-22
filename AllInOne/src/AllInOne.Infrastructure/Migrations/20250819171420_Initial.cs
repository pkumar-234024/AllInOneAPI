using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllInOne.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class Initial : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "AiToolModels",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                  ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  ToolUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_AiToolModels", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "Contributors",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                  Status = table.Column<int>(type: "int", nullable: false),
                  PhoneNumber_CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  PhoneNumber_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  PhoneNumber_Extension = table.Column<string>(type: "nvarchar(max)", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Contributors", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "Product",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                  Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                  CategoryId = table.Column<int>(type: "int", nullable: true),
                  ProductRating = table.Column<int>(type: "int", nullable: false),
                  NumberOfReviews = table.Column<int>(type: "int", nullable: false),
                  ProductFeatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  PrintType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  PaperQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  TurnaroudnTime = table.Column<int>(type: "int", nullable: false),
                  MinimumOrderQuantity = table.Column<int>(type: "int", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Product", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "ProductCategories",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_ProductCategories", x => x.Id);
              });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "AiToolModels");

          migrationBuilder.DropTable(
              name: "Contributors");

          migrationBuilder.DropTable(
              name: "Product");

          migrationBuilder.DropTable(
              name: "ProductCategories");
      }
  }
