using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllInOne.Infrastructure.Data.Migrations;

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
                  Id = table.Column<int>(type: "INTEGER", nullable: false)
                      .Annotation("Sqlite:Autoincrement", true),
                  Name = table.Column<string>(type: "TEXT", nullable: false),
                  Description = table.Column<string>(type: "TEXT", nullable: false),
                  Image = table.Column<byte[]>(type: "BLOB", nullable: true),
                  ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                  ToolUrl = table.Column<string>(type: "TEXT", nullable: false),
                  CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                  UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                  CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                  UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_AiToolModels", x => x.Id);
              });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "AiToolModels");
      }
  }
