using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Assignment_3.Migrations
{
    public partial class MigrationWithPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_Employeeid",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2022, 10, 13, 15, 9, 17, 142, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Employees_Employeeid",
                table: "Bookings",
                column: "Employeeid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Employees_Employeeid",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2022, 10, 13, 8, 28, 1, 876, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_Employeeid",
                table: "Bookings",
                column: "Employeeid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
