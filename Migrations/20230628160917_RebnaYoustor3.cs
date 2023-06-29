using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExaminationAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class RebnaYoustor3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_StudentId",
                table: "Exams");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "312844e1-075a-4fe8-b4c3-fd87991ef9fa");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f82136ed-5f12-4f60-9300-8e92bc0299b3");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Exams");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e549a8b-601a-4e8c-a0e4-b466b5f9a028", null, "student", null },
                    { "931d806c-8e5c-430f-9966-0ecd1e778e77", null, "instructor", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0e549a8b-601a-4e8c-a0e4-b466b5f9a028");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "931d806c-8e5c-430f-9966-0ecd1e778e77");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "312844e1-075a-4fe8-b4c3-fd87991ef9fa", null, "student", null },
                    { "f82136ed-5f12-4f60-9300-8e92bc0299b3", null, "instructor", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudentId",
                table: "Exams",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Students_StudentId",
                table: "Exams",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
