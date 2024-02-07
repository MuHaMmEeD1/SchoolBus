using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShcoolBusDataAccess.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Capacity", "CarNumber", "Marka", "Model" },
                values: new object[,]
                {
                    { 1, 20, "01-MN-001", "BWE", "BWE12" },
                    { 2, 22, "02-WY-245", "KIA", "KIA12" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Class_1" },
                    { 2, "Class_2" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Parent_1", "Parent_1", "050-234-56-87" },
                    { 2, "Parent_2", "Parent_2", "055-837-17-54" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CarId", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, 1, "Driver_1", "Driver_1", "055-234-45-87" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CarId", "FirstName", "LastName", "Phone" },
                values: new object[] { 2, 2, "Driver_2", "Driver_2", "070-345-26-76" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
