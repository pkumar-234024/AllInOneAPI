using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllInOne.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class UpdateProductsTable : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.AddColumn<string>(
              name: "CommaSeperatedProductFeatures",
              table: "Products",
              type: "nvarchar(max)",
              nullable: true);
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropColumn(
              name: "CommaSeperatedProductFeatures",
              table: "Products");
      }
  }
