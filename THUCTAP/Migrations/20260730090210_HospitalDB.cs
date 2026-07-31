using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THUCTAP.Migrations
{
    /// <inheritdoc />
    public partial class HospitalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormFields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entityname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colspan = table.Column<int>(type: "int", nullable: false),
                    options = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tabname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isdetail = table.Column<bool>(type: "bit", nullable: false),
                    sortorder = table.Column<int>(type: "int", nullable: false),
                    optionlabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    optionvalue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subfield = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tagfield = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentid = table.Column<int>(type: "int", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_parentid",
                        column: x => x.parentid,
                        principalTable: "Menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usercode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuid = table.Column<int>(type: "int", nullable: false),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Actions_Menus_menuid",
                        column: x => x.menuid,
                        principalTable: "Menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group_Menus",
                columns: table => new
                {
                    groupsid = table.Column<int>(type: "int", nullable: false),
                    menusid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Menus", x => new { x.groupsid, x.menusid });
                    table.ForeignKey(
                        name: "FK_Group_Menus_Groups_groupsid",
                        column: x => x.groupsid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Menus_Menus_menusid",
                        column: x => x.menusid,
                        principalTable: "Menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Groups",
                columns: table => new
                {
                    groupsid = table.Column<int>(type: "int", nullable: false),
                    usersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Groups", x => new { x.groupsid, x.usersid });
                    table.ForeignKey(
                        name: "FK_User_Groups_Groups_groupsid",
                        column: x => x.groupsid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Groups_Users_usersid",
                        column: x => x.usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group_Actions",
                columns: table => new
                {
                    actionsid = table.Column<int>(type: "int", nullable: false),
                    groupsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Actions", x => new { x.actionsid, x.groupsid });
                    table.ForeignKey(
                        name: "FK_Group_Actions_Actions_actionsid",
                        column: x => x.actionsid,
                        principalTable: "Actions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Actions_Groups_groupsid",
                        column: x => x.groupsid,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormFields",
                columns: new[] { "id", "colspan", "createdat", "entityname", "field", "isdetail", "label", "optionlabel", "options", "optionvalue", "sortorder", "subfield", "tabname", "tagfield", "type", "updatedat" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4736), "User", "username", false, "Tên đăng nhập", null, "", null, 1, "", "", "", "text", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4737) },
                    { 2, 6, new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4742), "User", "department", false, "Phòng ban", null, "", null, 2, "", "", "", "select", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4743) }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "id", "code", "createdat", "description", "name", "updatedat" },
                values: new object[,]
                {
                    { 1, "ADMIN", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4660), "Full quyền", "Quản trị hệ thống", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4660) },
                    { 2, "DOCTOR", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4665), "Quyền khám chữa bệnh", "Bác sĩ", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4665) }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "id", "createdat", "icon", "label", "parentid", "to", "updatedat" },
                values: new object[] { 1, new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4714), "settings", "Hệ thống", null, "/system", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4714) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "createdat", "department", "email", "password", "updatedat", "usercode", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4538), "Ban Giám Đốc", "admin@test.com", "123", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4540), "NV001", "admin" },
                    { 2, new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4545), "Khoa Nội", "bs@test.com", "123", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4545), "BS001", "bacsi01" }
                });

            migrationBuilder.InsertData(
                table: "Group_Menus",
                columns: new[] { "groupsid", "menusid" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "id", "createdat", "icon", "label", "parentid", "to", "updatedat" },
                values: new object[] { 2, new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4718), "users", "Quản lý Người dùng", 1, "/system/users", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4718) });

            migrationBuilder.InsertData(
                table: "User_Groups",
                columns: new[] { "groupsid", "usersid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "id", "code", "createdat", "endpoint", "label", "menuid", "method", "updatedat" },
                values: new object[,]
                {
                    { 1, "USER_VIEW_LIST", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4685), "/api/users", "Danh sách ", 2, "GET", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4686) },
                    { 2, "USER_VIEW_DETAIL", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4691), "/api/users/{id}", "Chi tiết ", 2, "GET", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4691) },
                    { 3, "USER_ADD", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4693), "/api/users", "Thêm mới ", 2, "POST", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4693) },
                    { 4, "USER_EDIT", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4694), "/api/users/{id}", "Cập nhật ", 2, "PUT", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4694) },
                    { 5, "USER_DEL", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4695), "/api/users/{id}", "Xóa ", 2, "DELETE", new DateTime(2026, 7, 30, 9, 2, 10, 293, DateTimeKind.Utc).AddTicks(4696) }
                });

            migrationBuilder.InsertData(
                table: "Group_Menus",
                columns: new[] { "groupsid", "menusid" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Group_Actions",
                columns: new[] { "actionsid", "groupsid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_menuid",
                table: "Actions",
                column: "menuid");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Actions_groupsid",
                table: "Group_Actions",
                column: "groupsid");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Menus_menusid",
                table: "Group_Menus",
                column: "menusid");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_code",
                table: "Groups",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_name",
                table: "Groups",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_parentid",
                table: "Menus",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_User_Groups_usersid",
                table: "User_Groups",
                column: "usersid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_usercode",
                table: "Users",
                column: "usercode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormFields");

            migrationBuilder.DropTable(
                name: "Group_Actions");

            migrationBuilder.DropTable(
                name: "Group_Menus");

            migrationBuilder.DropTable(
                name: "User_Groups");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
