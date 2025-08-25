﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllInOne.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class RemoveIformFormProduct : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropColumn(
              name: "Image",
              table: "Product");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.AddColumn<byte[]>(
              name: "Image",
              table: "Product",
              type: "varbinary(max)",
              nullable: true);
      }
  }
