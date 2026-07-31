using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2924), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2925) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2932), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2932) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2933), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2935), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2935) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2974), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2975) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2979), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2897), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2897) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2901), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2952), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2952) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2956), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2956) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2798), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2802) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2806), new DateTime(2026, 7, 30, 9, 2, 34, 54, DateTimeKind.Utc).AddTicks(2806) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4685), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4691), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4693), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4693) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4694), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4695), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4696) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4736), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4742), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4743) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4665), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4714), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4714) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4718), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4718) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4538), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4540) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4545), new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4545) });
        }
    }
}
