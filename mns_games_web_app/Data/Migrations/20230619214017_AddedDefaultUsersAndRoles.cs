using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mns_games_web_app.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb", "89d34a29-2f13-4bc3-a5fe-8faabbc633e5", "User", "USER" },
                    { "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb", "d2b1fa1b-55ac-4eb7-94ba-fb193b711df8", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "CountryId", "DateJoined", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "Nickname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetName", "StreetNumber", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[,]
                {
                    { "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb", 0, null, "c617bf21-0da9-46e1-b0cd-f64f82309f83", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", true, "Admin", false, null, "Master", "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEOjB18bLyBLHXi4xaE1ktOSJEPomgGFAwL5x/ePZrEYCr2TLdMCicsFLkRwtkRCTIg==", null, false, "b9ea1d12-3af5-4d3f-b670-57d695dc217b", null, null, false, null, null },
                    { "40df79cc-c203-472b-ac45-53d7b01be4ab", 0, null, "6aa2ba9a-a275-45a0-9bc3-c5858e772b67", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", false, "User", false, null, "Peon", "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEGDNMX2LFDID/A2G9fACxNlT4himF+MRw7jCDiN64fACfcbfuCIeyiKX7fXqctq1fQ==", null, false, "8e594fdc-27a5-4252-9b6f-625d4eb3815b", null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb", "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb", "40df79cc-c203-472b-ac45-53d7b01be4ab" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb", "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb", "40df79cc-c203-472b-ac45-53d7b01be4ab" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40df79cc-c203-472b-ac45-53d7b01be4ab");
        }
    }
}
