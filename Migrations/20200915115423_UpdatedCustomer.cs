using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingAPI.Migrations
{
    public partial class UpdatedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<string>(nullable: false),
                    CustomerLabel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<string>(nullable: false),
                    AccountLabel = table.Column<string>(nullable: false),
                    AccountAmount = table.Column<int>(nullable: false),
                    AccountDate = table.Column<string>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    CustomerID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_Customer_CustomerID1",
                        column: x => x.CustomerID1,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerID1",
                table: "Account",
                column: "CustomerID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
