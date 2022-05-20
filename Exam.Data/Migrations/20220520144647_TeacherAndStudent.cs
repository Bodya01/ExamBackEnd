using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Data.Migrations
{
    public partial class TeacherAndStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_TeacherId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Group_GroupId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_AspNetUsers_StudentId",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Course_CourseId",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "ListUser");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CourseId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Mark_CourseId",
                table: "Mark");

            migrationBuilder.DropIndex(
                name: "IX_Exam_CourseId",
                table: "Exam");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Mark",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Mark",
                newName: "UserSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_StudentId",
                table: "Mark",
                newName: "IX_Mark_UserId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Exam",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_GroupId",
                table: "Exam",
                newName: "IX_Exam_SubjectId");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Mark",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Exam",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupSubject",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSubject", x => new { x.GroupsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_GroupSubject_Group_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListStudent",
                columns: table => new
                {
                    ListsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListStudent", x => new { x.ListsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ListStudent_List_ListsId",
                        column: x => x.ListsId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mark_SubjectId",
                table: "Mark",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudentId",
                table: "Exam",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSubject_SubjectsId",
                table: "GroupSubject",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListStudent_StudentsId",
                table: "ListStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Student_StudentId",
                table: "Exam",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Subject_SubjectId",
                table: "Exam",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Mark_Subject_SubjectId",
                table: "Mark",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Student_StudentId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Subject_SubjectId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Teacher_TeacherId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Student_UserId",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Subject_SubjectId",
                table: "Mark");

            migrationBuilder.DropTable(
                name: "GroupSubject");

            migrationBuilder.DropTable(
                name: "ListStudent");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Mark_SubjectId",
                table: "Mark");

            migrationBuilder.DropIndex(
                name: "IX_Exam_StudentId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Mark");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Exam");

            migrationBuilder.RenameColumn(
                name: "UserSubjectId",
                table: "Mark",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Mark",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_UserId",
                table: "Mark",
                newName: "IX_Mark_StudentId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Exam",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_SubjectId",
                table: "Exam",
                newName: "IX_Exam_GroupId");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListUser",
                columns: table => new
                {
                    ListsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListUser", x => new { x.ListsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ListUser_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListUser_List_ListsId",
                        column: x => x.ListsId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CourseId",
                table: "Subject",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_CourseId",
                table: "Mark",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CourseId",
                table: "Exam",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ListUser_StudentsId",
                table: "ListUser",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_TeacherId",
                table: "Exam",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Group_GroupId",
                table: "Exam",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_AspNetUsers_StudentId",
                table: "Mark",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_Course_CourseId",
                table: "Mark",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
