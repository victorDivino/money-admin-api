using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyAdmin.Infra.Data.Migrations
{
    public partial class mssqlCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    IncomeCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incomes_Category_IncomeCategoryId",
                        column: x => x.IncomeCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpensePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PayDay = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ExpenseId = table.Column<Guid>(nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensePayments_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpensePayments_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PayDay = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IncomeId = table.Column<Guid>(nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomePayments_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomePayments_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpensePayments_BankAccountId",
                table: "ExpensePayments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensePayments_ExpenseId",
                table: "ExpensePayments",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BankAccountId",
                table: "Expenses",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomePayments_BankAccountId",
                table: "IncomePayments",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomePayments_IncomeId",
                table: "IncomePayments",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_BankAccountId",
                table: "Incomes",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_IncomeCategoryId",
                table: "Incomes",
                column: "IncomeCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpensePayments");

            migrationBuilder.DropTable(
                name: "IncomePayments");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
