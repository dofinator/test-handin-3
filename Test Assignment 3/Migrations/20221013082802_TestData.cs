using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Assignment_3.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "Birthday", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2022, 10, 13, 8, 28, 1, 876, DateTimeKind.Utc).AddTicks(5186), "SD", "DS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
