using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelExpense.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_ExpenseCategories_CategoryId",
                table: "ExpenseClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_Users_EmployeeId",
                table: "ExpenseClaims");

            migrationBuilder.DropTable(
                name: "ApprovalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories");

            migrationBuilder.RenameTable(
                name: "ExpenseCategories",
                newName: "ExpenseCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseCategory",
                table: "ExpenseCategory",
                column: "CategoryId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_ExpenseCategory_CategoryId",
                table: "ExpenseClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseClaims_Users_EmployeeId",
                table: "ExpenseClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseCategory",
                table: "ExpenseCategory");

            migrationBuilder.RenameTable(
                name: "ExpenseCategory",
                newName: "ExpenseCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "ApprovalHistories",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_ExpenseClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "ExpenseClaims",
                        principalColumn: "ClaimId");
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_Users_ActionBy",
                        column: x => x.ActionBy,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_ActionBy",
                table: "ApprovalHistories",
                column: "ActionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_ClaimId",
                table: "ApprovalHistories",
                column: "ClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseClaims_ExpenseCategories_CategoryId",
                table: "ExpenseClaims",
                column: "CategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseClaims_Users_EmployeeId",
                table: "ExpenseClaims",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
