using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddBorrowOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_borrow_records_BorrowOrder_BorrowOrderId",
                table: "borrow_records");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowOrder_users_UserId",
                table: "BorrowOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowOrder",
                table: "BorrowOrder");

            migrationBuilder.RenameTable(
                name: "BorrowOrder",
                newName: "borrow_orders");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "borrow_orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "borrow_orders",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TotalFine",
                table: "borrow_orders",
                newName: "total_fine");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "borrow_orders",
                newName: "due_date");

            migrationBuilder.RenameColumn(
                name: "BorrowDate",
                table: "borrow_orders",
                newName: "borrow_date");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowOrder_UserId",
                table: "borrow_orders",
                newName: "IX_borrow_orders_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_borrow_orders",
                table: "borrow_orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrow_orders_users_user_id",
                table: "borrow_orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_borrow_records_borrow_orders_BorrowOrderId",
                table: "borrow_records",
                column: "BorrowOrderId",
                principalTable: "borrow_orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_borrow_orders_users_user_id",
                table: "borrow_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_borrow_records_borrow_orders_BorrowOrderId",
                table: "borrow_records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_borrow_orders",
                table: "borrow_orders");

            migrationBuilder.RenameTable(
                name: "borrow_orders",
                newName: "BorrowOrder");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "BorrowOrder",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "BorrowOrder",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "total_fine",
                table: "BorrowOrder",
                newName: "TotalFine");

            migrationBuilder.RenameColumn(
                name: "due_date",
                table: "BorrowOrder",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "borrow_date",
                table: "BorrowOrder",
                newName: "BorrowDate");

            migrationBuilder.RenameIndex(
                name: "IX_borrow_orders_user_id",
                table: "BorrowOrder",
                newName: "IX_BorrowOrder_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowOrder",
                table: "BorrowOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrow_records_BorrowOrder_BorrowOrderId",
                table: "borrow_records",
                column: "BorrowOrderId",
                principalTable: "BorrowOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowOrder_users_UserId",
                table: "BorrowOrder",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
