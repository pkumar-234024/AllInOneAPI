using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllInOne.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class UpdateIntialDb : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropPrimaryKey(
              name: "PK_Product",
              table: "Product");

          migrationBuilder.RenameTable(
              name: "Product",
              newName: "Products");

          migrationBuilder.AddColumn<string>(
              name: "Delivery",
              table: "Products",
              type: "nvarchar(max)",
              nullable: false,
              defaultValue: "");

          migrationBuilder.AddColumn<string>(
              name: "DesignSupport",
              table: "Products",
              type: "nvarchar(max)",
              nullable: false,
              defaultValue: "");

          migrationBuilder.AddColumn<string>(
              name: "ImageName",
              table: "Products",
              type: "nvarchar(max)",
              nullable: false,
              defaultValue: "");

          migrationBuilder.AddColumn<bool>(
              name: "InStock",
              table: "Products",
              type: "bit",
              nullable: false,
              defaultValue: false);

          migrationBuilder.AddPrimaryKey(
              name: "PK_Products",
              table: "Products",
              column: "Id");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropPrimaryKey(
              name: "PK_Products",
              table: "Products");

          migrationBuilder.DropColumn(
              name: "Delivery",
              table: "Products");

          migrationBuilder.DropColumn(
              name: "DesignSupport",
              table: "Products");

          migrationBuilder.DropColumn(
              name: "ImageName",
              table: "Products");

          migrationBuilder.DropColumn(
              name: "InStock",
              table: "Products");

          migrationBuilder.RenameTable(
              name: "Products",
              newName: "Product");

          migrationBuilder.AddPrimaryKey(
              name: "PK_Product",
              table: "Product",
              column: "Id");
      }
  }
