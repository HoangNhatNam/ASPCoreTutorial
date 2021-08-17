using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPCoreTutorial.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_DepartmentID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Course_CourseID",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Instructor_InstructorID",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_Instructor_InstructorID",
                table: "OfficeAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Student",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Student",
                newName: "first_mid_name");

            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "Student",
                newName: "enrollment_date");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Student",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "OfficeAssignment",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "OfficeAssignment",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Instructor",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "HireDate",
                table: "Instructor",
                newName: "hire_date");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Instructor",
                newName: "first_mid_name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Instructor",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Enrollment",
                newName: "grade");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Enrollment",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Enrollment",
                newName: "course_id");

            migrationBuilder.RenameColumn(
                name: "EnrollmentID",
                table: "Enrollment",
                newName: "enrollment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                newName: "IX_Enrollment_student_id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                newName: "IX_Enrollment_course_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Department",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Department",
                newName: "budget");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Department",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Department",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Department",
                newName: "department_id");

            migrationBuilder.RenameIndex(
                name: "IX_Department_InstructorID",
                table: "Department",
                newName: "IX_Department_instructor_id");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "CourseAssignment",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseAssignment",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssignment_InstructorID",
                table: "CourseAssignment",
                newName: "IX_CourseAssignment_instructor_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Course",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Credits",
                table: "Course",
                newName: "credits");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Course",
                newName: "department_id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Course",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                newName: "IX_Course_department_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_department_id",
                table: "Course",
                column: "department_id",
                principalTable: "Department",
                principalColumn: "department_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Course_course_id",
                table: "CourseAssignment",
                column: "course_id",
                principalTable: "Course",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Instructor_instructor_id",
                table: "CourseAssignment",
                column: "instructor_id",
                principalTable: "Instructor",
                principalColumn: "instructor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_instructor_id",
                table: "Department",
                column: "instructor_id",
                principalTable: "Instructor",
                principalColumn: "instructor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_course_id",
                table: "Enrollment",
                column: "course_id",
                principalTable: "Course",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_student_id",
                table: "Enrollment",
                column: "student_id",
                principalTable: "Student",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Instructor_instructor_id",
                table: "OfficeAssignment",
                column: "instructor_id",
                principalTable: "Instructor",
                principalColumn: "instructor_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_department_id",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Course_course_id",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Instructor_instructor_id",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_instructor_id",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_course_id",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_student_id",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_Instructor_instructor_id",
                table: "OfficeAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Student",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_mid_name",
                table: "Student",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "enrollment_date",
                table: "Student",
                newName: "EnrollmentDate");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Student",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "OfficeAssignment",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "OfficeAssignment",
                newName: "InstructorID");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Instructor",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "hire_date",
                table: "Instructor",
                newName: "HireDate");

            migrationBuilder.RenameColumn(
                name: "first_mid_name",
                table: "Instructor",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "Instructor",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "grade",
                table: "Enrollment",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Enrollment",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Enrollment",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "enrollment_id",
                table: "Enrollment",
                newName: "EnrollmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_student_id",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_course_id",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Department",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "budget",
                table: "Department",
                newName: "Budget");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Department",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "Department",
                newName: "InstructorID");

            migrationBuilder.RenameColumn(
                name: "department_id",
                table: "Department",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Department_instructor_id",
                table: "Department",
                newName: "IX_Department_InstructorID");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "CourseAssignment",
                newName: "InstructorID");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "CourseAssignment",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssignment_instructor_id",
                table: "CourseAssignment",
                newName: "IX_CourseAssignment_InstructorID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Course",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "credits",
                table: "Course",
                newName: "Credits");

            migrationBuilder.RenameColumn(
                name: "department_id",
                table: "Course",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_department_id",
                table: "Course",
                newName: "IX_Course_DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment",
                columns: new[] { "CourseID", "InstructorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_DepartmentID",
                table: "Course",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Course_CourseID",
                table: "CourseAssignment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Instructor_InstructorID",
                table: "CourseAssignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Instructor_InstructorID",
                table: "OfficeAssignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
