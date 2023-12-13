using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initdnb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccountUserTransoction",
                columns: table => new
                {
                    UserAccountsId = table.Column<int>(type: "integer", nullable: false),
                    UserTransoctionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountUserTransoction", x => new { x.UserAccountsId, x.UserTransoctionsId });
                    table.ForeignKey(
                        name: "FK_UserAccountUserTransoction_Transactions_UserTransoctionsId",
                        column: x => x.UserTransoctionsId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccountUserTransoction_Users_UserAccountsId",
                        column: x => x.UserAccountsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountUserTransoction_UserTransoctionsId",
                table: "UserAccountUserTransoction",
                column: "UserTransoctionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccountUserTransoction");
        }
    }
}
