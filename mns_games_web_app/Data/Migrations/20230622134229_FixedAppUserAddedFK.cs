using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mns_games_web_app.Data.Migrations
{
    public partial class FixedAppUserAddedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb",
                column: "ConcurrencyStamp",
                value: "4af2acd4-2c25-490a-9cb4-716d11998ec2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb",
                column: "ConcurrencyStamp",
                value: "69138bf9-4776-463b-b3bb-315a6d57fe4a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd0dbf03-58a0-4e14-ba0c-32b992791085", "AQAAAAEAACcQAAAAEChu6uLt+seWF1ahyo3RX45IIisw6uEmPl3ibssieMv7uCvi/aqlk+RvTxmBZ6Hjew==", "117ee715-70fc-4810-8185-126dbee48b59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40df79cc-c203-472b-ac45-53d7b01be4ab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8842db24-c759-4a0c-80bd-8071d32e5cb5", "AQAAAAEAACcQAAAAEJvVVADOySWzAsf24Ir4xciiaaF3BSMMupPTnxMhppAsi32l/zM4tvdxXTkGgYppmg==", "bd3aeba6-48f8-4d52-8f54-9fa8ba5faddb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d2b4dd-bc5f-4fcc-baed-e8290805f4cb",
                column: "ConcurrencyStamp",
                value: "261eb689-9b1b-4373-8889-f88c720ac154");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d2f4de-bc3f-4fdc-eaed-e8231005f4bb",
                column: "ConcurrencyStamp",
                value: "64fd08f6-2bbc-4c95-9635-4af485bd9b76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23d0f9de-bc4f-1fdc-eaed-e9312905f4bb",
                columns: new[] { "ConcurrencyStamp", "IsAdmin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82c04cae-2a39-4b96-92e0-e636faba38cc", true, "AQAAAAEAACcQAAAAEI6MCMa9RlWrcEASVEOO2E8LMXyzrmxIt47zjI7ojy3L3iSCC14Pc5D+TMQywifO+w==", "15b60cd8-61fa-4e2d-a766-a69bcb05e972" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40df79cc-c203-472b-ac45-53d7b01be4ab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d73c222-a621-4fef-894b-062e3c6c01d5", "AQAAAAEAACcQAAAAEF9VPpwhtHKPWVIQaHSDTfB2ayVYoyK8TZjJiQjL1+B1mSDTJyw5DRM9JOTAY8rl0w==", "1583780d-a4b8-40f9-a237-d4bdd69164d6" });
        }
    }
}
