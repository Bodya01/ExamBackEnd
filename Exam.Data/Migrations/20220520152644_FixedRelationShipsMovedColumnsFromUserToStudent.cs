using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Data.Migrations
{
    public partial class FixedRelationShipsMovedColumnsFromUserToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Teacher_TeacherId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Student_UserId",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_TeacherId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Exam_TeacherId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "UserSubjectId",
                table: "Mark");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "BankAccout",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasSchoolarship",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsExpulsed",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Mark",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_UserId",
                table: "Mark",
                newName: "IX_Mark_StudentId");

            migrationBuilder.AddColumn<string>(
                name: "BankAccout",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasSchoolarship",
                table: "Student",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpulsed",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Group",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupId",
                table: "Student",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_TeacherId",
                table: "Group",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Teacher_TeacherId",
                table: "Group",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_Student_StudentId",
                table: "Mark",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Teacher_TeacherId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Student_StudentId",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Student_GroupId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Group_TeacherId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "BankAccout",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "HasSchoolarship",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IsExpulsed",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Group");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Mark",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_StudentId",
                table: "Mark",
                newName: "IX_Mark_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserSubjectId",
                table: "Mark",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Exam",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccout",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasSchoolarship",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpulsed",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_TeacherId",
                table: "Exam",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Teacher_TeacherId",
                table: "Exam",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_Student_UserId",
                table: "Mark",
                column: "UserId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
