using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class ComplexDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 2042);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 2021);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 3141);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 4022);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 4041);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignment", x => new { x.CourseID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Department_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignment", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_OfficeAssignment_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignment_InstructorID",
                table: "CourseAssignment",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_InstructorID",
                table: "Department",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_DepartmentID",
                table: "Course",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_DepartmentID",
                table: "Course");

            migrationBuilder.DropTable(
                name: "CourseAssignment");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "OfficeAssignment");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Credits", "Title" },
                values: new object[,]
                {
                    { 1045, 4, "Calculus" },
                    { 1050, 3, "Chemistry" },
                    { 2021, 3, "Composition" },
                    { 2042, 4, "Literature" },
                    { 3141, 4, "Trigonometry" },
                    { 4022, 3, "Microeconomics" },
                    { 4041, 3, "Macroeconomics" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentID", "EnrollmentDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carson", "Alexander" },
                    { 2, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meredith", "Alonso" },
                    { 3, new DateTime(2003, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arturo", "Anand" },
                    { 4, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gytis", "Barzdukas" },
                    { 5, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yan", "Li" },
                    { 6, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peggy", "Justice" },
                    { 7, new DateTime(2003, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Norman" },
                    { 8, new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nino", "Olivetto" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "EnrollmentID", "CourseID", "Grade", "StudentID" },
                values: new object[,]
                {
                    { 1, 1050, 0, 1 },
                    { 2, 4022, 2, 1 },
                    { 3, 4041, 1, 1 },
                    { 4, 1045, 1, 2 },
                    { 5, 3141, 4, 2 },
                    { 6, 2021, 4, 2 },
                    { 7, 1050, null, 3 },
                    { 8, 1050, null, 4 },
                    { 9, 4022, 4, 4 },
                    { 10, 4041, 2, 5 },
                    { 11, 1045, null, 6 },
                    { 12, 3141, 0, 7 }
                });
        }
    }
}
