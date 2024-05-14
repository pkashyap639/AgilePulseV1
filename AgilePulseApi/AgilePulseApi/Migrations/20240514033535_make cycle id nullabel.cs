using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilePulseApi.Migrations
{
    /// <inheritdoc />
    public partial class makecycleidnullabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Cycle_cycleId",
                table: "Issue");

            migrationBuilder.AlterColumn<Guid>(
                name: "cycleId",
                table: "Issue",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Cycle_cycleId",
                table: "Issue",
                column: "cycleId",
                principalTable: "Cycle",
                principalColumn: "CycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Cycle_cycleId",
                table: "Issue");

            migrationBuilder.AlterColumn<Guid>(
                name: "cycleId",
                table: "Issue",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Cycle_cycleId",
                table: "Issue",
                column: "cycleId",
                principalTable: "Cycle",
                principalColumn: "CycleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
