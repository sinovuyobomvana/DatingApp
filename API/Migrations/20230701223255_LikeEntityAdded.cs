using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class LikeEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicID",
                table: "Photos",
                newName: "PublicId");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    SourceUserId = table.Column<int>(type: "int", nullable: false),
                    TargetUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.SourceUserId, x.TargetUserID });
                    table.ForeignKey(
                        name: "FK_Likes_Users_SourceUserId",
                        column: x => x.SourceUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_TargetUserID",
                        column: x => x.TargetUserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TargetUserID",
                table: "Likes",
                column: "TargetUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "Photos",
                newName: "PublicID");
        }
    }
}
