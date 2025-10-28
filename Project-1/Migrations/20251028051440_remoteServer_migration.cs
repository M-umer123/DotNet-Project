using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_1.Migrations
{
    /// <inheritdoc />
    public partial class remoteServer_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "about_tbl",
                columns: table => new
                {
                    about_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    about_title = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    about_desc = table.Column<string>(type: "text", nullable: false),
                    about_btn_text = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_about_tbl", x => x.about_id);
                });

            migrationBuilder.CreateTable(
                name: "admin_table",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    admin_phone = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    admin_email = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    admin_password = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_table", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "booking_tbl",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booker_name = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    booker_phone = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    booker_email = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    booker_total_persons = table.Column<int>(type: "int", nullable: true),
                    booker_booking_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_tbl", x => x.book_id);
                });

            migrationBuilder.CreateTable(
                name: "home_tbl",
                columns: table => new
                {
                    home_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    home_title = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    home_desc = table.Column<string>(type: "text", nullable: true),
                    home_bg_img = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_home_tbl", x => x.home_id);
                });

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    menu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_img_1 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    item_img_2 = table.Column<string>(type: "text", nullable: true),
                    item_img_3 = table.Column<string>(type: "text", nullable: true),
                    item_img_4 = table.Column<string>(type: "text", nullable: true),
                    item_img_5 = table.Column<string>(type: "text", nullable: true),
                    item_img_6 = table.Column<string>(type: "text", nullable: true),
                    item_img_7 = table.Column<string>(type: "text", nullable: true),
                    item_img_8 = table.Column<string>(type: "text", nullable: true),
                    item_img_9 = table.Column<string>(type: "text", nullable: true),
                    item_title_1 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_2 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_3 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_4 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_5 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_6 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_7 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_8 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_title_9 = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    item_desc_1 = table.Column<string>(type: "text", nullable: true),
                    item_desc_2 = table.Column<string>(type: "text", nullable: true),
                    item_desc_3 = table.Column<string>(type: "text", nullable: true),
                    item_desc_4 = table.Column<string>(type: "text", nullable: true),
                    item_desc_5 = table.Column<string>(type: "text", nullable: true),
                    item_desc_6 = table.Column<string>(type: "text", nullable: true),
                    item_desc_7 = table.Column<string>(type: "text", nullable: true),
                    item_desc_8 = table.Column<string>(type: "text", nullable: true),
                    item_desc_9 = table.Column<string>(type: "text", nullable: true),
                    item_1_price = table.Column<int>(type: "int", nullable: true),
                    item_2_price = table.Column<int>(type: "int", nullable: true),
                    item_3_price = table.Column<int>(type: "int", nullable: true),
                    item_4_price = table.Column<int>(type: "int", nullable: true),
                    item_5_price = table.Column<int>(type: "int", nullable: true),
                    item_6_price = table.Column<int>(type: "int", nullable: true),
                    item_7_price = table.Column<int>(type: "int", nullable: true),
                    item_8_price = table.Column<int>(type: "int", nullable: true),
                    item_9_price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.menu_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "about_tbl");

            migrationBuilder.DropTable(
                name: "admin_table");

            migrationBuilder.DropTable(
                name: "booking_tbl");

            migrationBuilder.DropTable(
                name: "home_tbl");

            migrationBuilder.DropTable(
                name: "menu");
        }
    }
}
