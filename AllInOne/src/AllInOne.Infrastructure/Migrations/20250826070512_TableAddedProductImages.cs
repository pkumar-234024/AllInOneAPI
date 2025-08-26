﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllInOne.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class TableAddedProductImages : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "ProductImage",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  ProductId = table.Column<int>(type: "int", nullable: false),
                  ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_ProductImage", x => x.Id);
              });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "ProductImage");
      }
  }
