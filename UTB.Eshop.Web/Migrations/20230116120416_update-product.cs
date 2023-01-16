using Microsoft.EntityFrameworkCore.Migrations;

namespace UTB.Eshop.Web.Migrations
{
    public partial class updateproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Product",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Product",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ImageAlt", "ImageSrc" },
                values: new object[] { "First slide", "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ImageAlt", "ImageSrc" },
                values: new object[] { "First slide", "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ImageAlt", "ImageSrc" },
                values: new object[] { "First slide", "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ImageAlt", "ImageSrc" },
                values: new object[] { "First slide", "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ImageAlt", "ImageSrc" },
                values: new object[] { "First slide", "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Product");
        }
    }
}
