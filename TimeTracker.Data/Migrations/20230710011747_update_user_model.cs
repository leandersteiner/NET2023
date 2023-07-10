using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_user_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Tasks_TaskId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_TaskId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "WorkItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskId",
                table: "Tasks",
                newName: "IX_Tasks_WorkItemId");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Records",
                newName: "WorkItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Records_TaskId",
                table: "Records",
                newName: "IX_Records_WorkItemId");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Tasks_WorkItemId",
                table: "Records",
                column: "WorkItemId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_WorkItemId",
                table: "Tasks",
                column: "WorkItemId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Tasks_WorkItemId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_WorkItemId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "WorkItemId",
                table: "Tasks",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_WorkItemId",
                table: "Tasks",
                newName: "IX_Tasks_TaskId");

            migrationBuilder.RenameColumn(
                name: "WorkItemId",
                table: "Records",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Records_WorkItemId",
                table: "Records",
                newName: "IX_Records_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Tasks_TaskId",
                table: "Records",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_TaskId",
                table: "Tasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
