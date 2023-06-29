using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExaminationAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class RebnaYoustor4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0e549a8b-601a-4e8c-a0e4-b466b5f9a028");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "931d806c-8e5c-430f-9966-0ecd1e778e77");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8990571c-1894-48b7-9589-ee13ec5a8657", null, "student", null },
                    { "bc47e7f0-8c53-4548-b0f4-f2cbb332d7f6", null, "instructor", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8990571c-1894-48b7-9589-ee13ec5a8657");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bc47e7f0-8c53-4548-b0f4-f2cbb332d7f6");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e549a8b-601a-4e8c-a0e4-b466b5f9a028", null, "student", null },
                    { "931d806c-8e5c-430f-9966-0ecd1e778e77", null, "instructor", null }
                });
        }
    }
}
