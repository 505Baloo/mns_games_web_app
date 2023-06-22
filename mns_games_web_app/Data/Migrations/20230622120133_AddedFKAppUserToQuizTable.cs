using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mns_games_web_app.Data.Migrations
{
    public partial class AddedFKAppUserToQuizTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Quizzes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82c04cae-2a39-4b96-92e0-e636faba38cc", "AQAAAAEAACcQAAAAEI6MCMa9RlWrcEASVEOO2E8LMXyzrmxIt47zjI7ojy3L3iSCC14Pc5D+TMQywifO+w==", "15b60cd8-61fa-4e2d-a766-a69bcb05e972" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40df79cc-c203-472b-ac45-53d7b01be4ab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d73c222-a621-4fef-894b-062e3c6c01d5", "AQAAAAEAACcQAAAAEF9VPpwhtHKPWVIQaHSDTfB2ayVYoyK8TZjJiQjL1+B1mSDTJyw5DRM9JOTAY8rl0w==", "1583780d-a4b8-40f9-a237-d4bdd69164d6" });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_AppUserId",
                table: "Quizzes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_AspNetUsers_AppUserId",
                table: "Quizzes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_AspNetUsers_AppUserId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_AppUserId",
                table: "Quizzes");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "679761f7-55f2-4fde-8d5e-26b7a75ccf0c", "AQAAAAEAACcQAAAAEIEdxbxiBthPIFxBBPjQc5kcuULDBLRxHNsTsbYFiS6uIJ3gxUqEFnvnfBZoz1Dd2Q==", "90329d0d-d35b-4814-a248-12c8fc912d86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40df79cc-c203-472b-ac45-53d7b01be4ab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73671f14-44f9-47c9-8e58-7eeca11a8434", "AQAAAAEAACcQAAAAEBLn73vRLLYQmYECuPDINBtzAtH6lBB5QJB1TOHk6A4bVi7q173ty3DEwkbxjx3jjQ==", "4b42d1ba-c6b6-4389-8cd1-5c52d344ef60" });
        }
    }
}
