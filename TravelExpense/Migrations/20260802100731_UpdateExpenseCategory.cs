using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelExpense.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExpenseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_ExpenseCategory_CategoryId",
                table: "ExpenseClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_Users_EmployeeId",
                table: "ExpenseClaims");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseClaims_CategoryId",
                table: "ExpenseClaims");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseClaims_EmployeeId",
                table: "ExpenseClaims");

            migrationBuilder.DropColumn(
                name: "ReceiptPath",
                table: "ExpenseClaims");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "ExpenseClaims",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "ExpenseClaims",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "ExpenseClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ExpenseClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptPath",
                table: "ExpenseClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseClaims_CategoryId",
                table: "ExpenseClaims",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseClaims_EmployeeId",
                table: "ExpenseClaims",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseClaims_ExpenseCategory_CategoryId",
                table: "ExpenseClaims",
                column: "CategoryId",
                principalTable: "ExpenseCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseClaims_Users_EmployeeId",
                table: "ExpenseClaims",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
