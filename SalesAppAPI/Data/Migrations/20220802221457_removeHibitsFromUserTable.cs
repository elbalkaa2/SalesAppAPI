using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesAppAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeHibitsFromUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserHibiltes_HibitesId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserHibiltes");

            migrationBuilder.DropIndex(
                name: "IX_Users_HibitesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HibitesId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HibitesId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserHibiltes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHibiltes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_HibitesId",
                table: "Users",
                column: "HibitesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserHibiltes_HibitesId",
                table: "Users",
                column: "HibitesId",
                principalTable: "UserHibiltes",
                principalColumn: "Id");
        }
    }
}
