using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBookShelf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_copies_bookshelves",
                table: "book_copies");

            migrationBuilder.DropTable(
                name: "bookshelves");

            migrationBuilder.DropIndex(
                name: "IX_book_copies_bookshelf_id",
                table: "book_copies");

            migrationBuilder.DropColumn(
                name: "bookshelf_id",
                table: "book_copies");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_of_birth",
                table: "users",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentCode",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "role_name",
                table: "roles",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "return_date",
                table: "borrow_records",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "due_date",
                table: "borrow_records",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "borrow_date",
                table: "borrow_records",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "ExtensionDateCount",
                table: "borrow_records",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentCode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ExtensionDateCount",
                table: "borrow_records");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_birth",
                table: "users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "role_name",
                table: "roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "return_date",
                table: "borrow_records",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "due_date",
                table: "borrow_records",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "borrow_date",
                table: "borrow_records",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "bookshelf_id",
                table: "book_copies",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bookshelves",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    current_count = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rack = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    shelf_number = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bookshel__3213E83F254924B2", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_copies_bookshelf_id",
                table: "book_copies",
                column: "bookshelf_id");

            migrationBuilder.CreateIndex(
                name: "UQ_bookshelves_rack_shelf",
                table: "bookshelves",
                columns: new[] { "rack", "shelf_number" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_book_copies_bookshelves",
                table: "book_copies",
                column: "bookshelf_id",
                principalTable: "bookshelves",
                principalColumn: "id");
        }
    }
}
