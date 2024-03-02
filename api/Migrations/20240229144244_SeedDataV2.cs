using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagementService.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "GroupId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(355), 5, new DateTime(2024, 2, 29, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(341) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "GroupId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 2, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(362), 5, new DateTime(2024, 2, 14, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(362) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "GroupId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 6, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(365), 5, new DateTime(2024, 2, 26, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(364) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 7, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(367), new DateTime(2024, 2, 23, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(366) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 3, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(369), new DateTime(2024, 2, 28, 18, 42, 41, 974, DateTimeKind.Local).AddTicks(369) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "GroupId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 27, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4436), 3, new DateTime(2024, 2, 26, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4424) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "GroupId", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 28, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4445), 3, new DateTime(2024, 2, 11, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4445) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "GroupId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 3, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4448), 3, new DateTime(2024, 2, 23, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 4, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4450), new DateTime(2024, 2, 20, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4449) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 29, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4452), new DateTime(2024, 2, 25, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4451) });
        }
    }
}
