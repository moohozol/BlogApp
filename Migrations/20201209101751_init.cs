using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 500, nullable: false, defaultValueSql: "(N'')"),
                    Abstract = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "(N'')"),
                    PublicationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Author = table.Column<string>(maxLength: 500, nullable: true, defaultValueSql: "(N'')"),
                    IsPublished = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    Body = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(maxLength: 1000, nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Keywords = table.Column<string>(maxLength: 1000, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
