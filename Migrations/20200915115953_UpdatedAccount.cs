using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingAPI.Migrations
{
    public partial class UpdatedAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerID1",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_CustomerID1",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CustomerID1",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Account",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerID",
                table: "Account",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerID",
                table: "Account",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerID",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_CustomerID",
                table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Account",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CustomerID1",
                table: "Account",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerID1",
                table: "Account",
                column: "CustomerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerID1",
                table: "Account",
                column: "CustomerID1",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
