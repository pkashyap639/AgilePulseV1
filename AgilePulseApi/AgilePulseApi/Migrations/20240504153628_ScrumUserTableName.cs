using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilePulseApi.Migrations
{
    /// <inheritdoc />
    public partial class ScrumUserTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_ScumUser_scrumUserId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ScumUser_LeadId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ScrumUserProject_ScumUser_ScrumUserId",
                table: "ScrumUserProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScumUser",
                table: "ScumUser");

            migrationBuilder.RenameTable(
                name: "ScumUser",
                newName: "ScrumUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScrumUser",
                table: "ScrumUser",
                column: "ScrumUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_ScrumUser_scrumUserId",
                table: "Issue",
                column: "scrumUserId",
                principalTable: "ScrumUser",
                principalColumn: "ScrumUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ScrumUser_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "ScrumUser",
                principalColumn: "ScrumUserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ScrumUserProject_ScrumUser_ScrumUserId",
                table: "ScrumUserProject",
                column: "ScrumUserId",
                principalTable: "ScrumUser",
                principalColumn: "ScrumUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_ScrumUser_scrumUserId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ScrumUser_LeadId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ScrumUserProject_ScrumUser_ScrumUserId",
                table: "ScrumUserProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScrumUser",
                table: "ScrumUser");

            migrationBuilder.RenameTable(
                name: "ScrumUser",
                newName: "ScumUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScumUser",
                table: "ScumUser",
                column: "ScrumUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_ScumUser_scrumUserId",
                table: "Issue",
                column: "scrumUserId",
                principalTable: "ScumUser",
                principalColumn: "ScrumUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ScumUser_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "ScumUser",
                principalColumn: "ScrumUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScrumUserProject_ScumUser_ScrumUserId",
                table: "ScrumUserProject",
                column: "ScrumUserId",
                principalTable: "ScumUser",
                principalColumn: "ScrumUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
