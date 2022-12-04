using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Data.Migrations
{
    public partial class RemovedUnnecessaryRelationBetweenUserAndStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Student_StudentId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_UserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Exam_StudentId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Exam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Student",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Exam",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudentId",
                table: "Exam",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Student_StudentId",
                table: "Exam",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
