using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mns_games_web_app.Data.Migrations
{
    public partial class FixedDefaultUsersAndRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb",
                column: "ConcurrencyStamp",
                value: "fb30d889-513a-4b1c-90f7-0a1e82e56d0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb",
                column: "ConcurrencyStamp",
                value: "e8c7f1c3-e9da-40c2-95cc-8be3ca935d09");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "679761f7-55f2-4fde-8d5e-26b7a75ccf0c", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEIEdxbxiBthPIFxBBPjQc5kcuULDBLRxHNsTsbYFiS6uIJ3gxUqEFnvnfBZoz1Dd2Q==", "90329d0d-d35b-4814-a248-12c8fc912d86", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40df79cc-c203-472b-ac45-53d7b01be4ab",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "73671f14-44f9-47c9-8e58-7eeca11a8434", true, "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEBLn73vRLLYQmYECuPDINBtzAtH6lBB5QJB1TOHk6A4bVi7q173ty3DEwkbxjx3jjQ==", "4b42d1ba-c6b6-4389-8cd1-5c52d344ef60", "user@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb",
                column: "ConcurrencyStamp",
                value: "89d34a29-2f13-4bc3-a5fe-8faabbc633e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb",
                column: "ConcurrencyStamp",
                value: "d2b1fa1b-55ac-4eb7-94ba-fb193b711df8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c617bf21-0da9-46e1-b0cd-f64f82309f83", false, null, "AQAAAAEAACcQAAAAEOjB18bLyBLHXi4xaE1ktOSJEPomgGFAwL5x/ePZrEYCr2TLdMCicsFLkRwtkRCTIg==", "b9ea1d12-3af5-4d3f-b670-57d695dc217b", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40df79cc-c203-472b-ac45-53d7b01be4ab",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6aa2ba9a-a275-45a0-9bc3-c5858e772b67", false, null, "AQAAAAEAACcQAAAAEGDNMX2LFDID/A2G9fACxNlT4himF+MRw7jCDiN64fACfcbfuCIeyiKX7fXqctq1fQ==", "8e594fdc-27a5-4252-9b6f-625d4eb3815b", null });
        }
    }
}
