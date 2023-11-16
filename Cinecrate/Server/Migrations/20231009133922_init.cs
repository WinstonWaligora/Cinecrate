using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SE641Databases.Server.Migrations
{
	/// <inheritdoc />
	public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieID = table.Column<Guid>(name: "Movie ID", type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Poster = table.Column<byte[]>(type: "varbinary(MAX)", nullable: true),
                    Rating = table.Column<string>(type: "char(1)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(name: "Release Date", type: "datetime", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<Guid>(name: "Tag ID", type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "Movie Tag",
                columns: table => new
                {
                    MovieID = table.Column<Guid>(name: "Movie ID", type: "uniqueidentifier", nullable: false),
                    TagID = table.Column<Guid>(name: "Tag ID", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie Tag", x => new { x.MovieID, x.TagID });
                    table.ForeignKey(
                        name: "FK_Movie Tag_Movie_Movie ID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "Movie ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie Tag_Tag_Tag ID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "Tag ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie Tag_Tag ID",
                table: "Movie Tag",
                column: "Tag ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie Tag");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
