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
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8024), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8024) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8027), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8029), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8031) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8032), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8032) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8178), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8181), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8001), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8002) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8004), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8004) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8052), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8052) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8055), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8055) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8057), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8057) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8059), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8061), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8061) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8063), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8064), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8066), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8067), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8067) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8068), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8148), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8149), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(8149) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(7907), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(7917), new DateTime(2026, 7, 31, 6, 36, 13, 536, DateTimeKind.Utc).AddTicks(7917) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9818), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9822), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9823), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9824), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9826), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9826) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9930), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9930) });

            migrationBuilder.UpdateData(
                table: "FormFields",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9934), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9792), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9792) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9795), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9796) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9843), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9847), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9849), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9849) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9850), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9851) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9852), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9854), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9854) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9855), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9855) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9857), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9857) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9858), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9858) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9885), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9885) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9887), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9902), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9902) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9903), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9903) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9905), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9690), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9693) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdat", "updatedat" },
                values: new object[] { new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9697), new DateTime(2026, 7, 31, 6, 35, 40, 959, DateTimeKind.Utc).AddTicks(9697) });
        }
    }
}
