using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mns_games_web_app.Data.Migrations
{
    public partial class AddedCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Germany" },
                    { 2, "Austria" },
                    { 3, "Belgium" },
                    { 4, "Bulgaria" },
                    { 5, "Cyprus" },
                    { 6, "Croatia" },
                    { 7, "Danemark" },
                    { 8, "Spain" },
                    { 9, "Estonia" },
                    { 10, "Finland" },
                    { 11, "France" },
                    { 12, "Greece" },
                    { 13, "Hungaria" },
                    { 14, "Ireland" },
                    { 15, "Italia" },
                    { 16, "Lettony" },
                    { 17, "Lituania" },
                    { 18, "Luxemburg" },
                    { 19, "Malta" },
                    { 20, "Netherlands" },
                    { 21, "Poland" },
                    { 22, "Portugal" },
                    { 23, "Czech Republic" },
                    { 24, "Romania" },
                    { 25, "Slovakia" },
                    { 26, "Slovenia" },
                    { 27, "Sweden" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}
