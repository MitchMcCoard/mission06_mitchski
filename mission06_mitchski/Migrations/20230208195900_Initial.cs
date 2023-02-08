using Microsoft.EntityFrameworkCore.Migrations;

namespace mission06_mitchski.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Edited = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action/Adventure", "Bryan Singer", false, "PG-13", "X-Men", 2000 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Rating", "Title", "Year" },
                values: new object[] { 2, "Action/Adventure", "Richard Marquand", false, "PG", "Star Wars Episode VI: Return of the Jedi", 1983 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Rating", "Title", "Year" },
                values: new object[] { 3, "Comedy", "Robert Zemeckis", false, "PG", "Back to the Future", 1985 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
