using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilePulseApi.Migrations
{
    /// <inheritdoc />
    public partial class setupDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cycle",
                columns: table => new
                {
                    CycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CycleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycle", x => x.CycleId);
                });

            migrationBuilder.CreateTable(
                name: "ScumUser",
                columns: table => new
                {
                    ScrumUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScrumUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScumUser", x => x.ScrumUserId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Projects_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_Projects_ScumUser_LeadId",
                        column: x => x.LeadId,
                        principalTable: "ScumUser",
                        principalColumn: "ScrumUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    scrumUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    projectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_Issue_Cycle_cycleId",
                        column: x => x.cycleId,
                        principalTable: "Cycle",
                        principalColumn: "CycleId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Issue_Projects_projectId",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issue_ScumUser_scrumUserId",
                        column: x => x.scrumUserId,
                        principalTable: "ScumUser",
                        principalColumn: "ScrumUserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScrumUserProject",
                columns: table => new
                {
                    ScrumUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrumUserProject", x => new { x.ScrumUserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ScrumUserProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrumUserProject_ScumUser_ScrumUserId",
                        column: x => x.ScrumUserId,
                        principalTable: "ScumUser",
                        principalColumn: "ScrumUserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issue_cycleId",
                table: "Issue",
                column: "cycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_projectId",
                table: "Issue",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_scrumUserId",
                table: "Issue",
                column: "scrumUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LeadId",
                table: "Projects",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectId1",
                table: "Projects",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_ScrumUserProject_ProjectId",
                table: "ScrumUserProject",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "ScrumUserProject");

            migrationBuilder.DropTable(
                name: "Cycle");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ScumUser");
        }
    }
}
