using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddPendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BorrowOrderId",
                table: "borrow_records",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BorrowOrder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalFine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowOrder_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_borrow_records_BorrowOrderId",
                table: "borrow_records",
                column: "BorrowOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowOrder_UserId",
                table: "BorrowOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_borrow_records_BorrowOrder_BorrowOrderId",
                table: "borrow_records",
                column: "BorrowOrderId",
                principalTable: "BorrowOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_borrow_records_BorrowOrder_BorrowOrderId",
                table: "borrow_records");

            migrationBuilder.DropTable(
                name: "BorrowOrder");

            migrationBuilder.DropIndex(
                name: "IX_borrow_records_BorrowOrderId",
                table: "borrow_records");

            migrationBuilder.DropColumn(
                name: "BorrowOrderId",
                table: "borrow_records");
        }
    }
}
