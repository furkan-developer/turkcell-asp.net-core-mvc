using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class init_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Book" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Electronic" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImgUrl", "Name", "Price" },
                values: new object[] { 1, "/images/1.jpg", "Computer", 17000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImgUrl", "Name", "Price" },
                values: new object[] { 2, "/images/2.jpg", "Keyboard", 1000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImgUrl", "Name", "Price" },
                values: new object[] { 3, "/images/3.jpg", "Mouse", 500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImgUrl", "Name", "Price" },
                values: new object[] { 4, "/images/4.jpg", "Monitor", 7000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImgUrl", "Name", "Price" },
                values: new object[] { 5, "", "Deck", 1500m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
