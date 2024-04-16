using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THWEB.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Dateread = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_books_publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books_author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books_author", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_author_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "AuthorId");
                    table.ForeignKey(
                        name: "FK_books_author_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "BookId");
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "AuthorId", "FullName" },
                values: new object[] { 1, "Akira Toriyama" });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "PublisherId", "Name" },
                values: new object[] { 1, "Kim Van Hoan" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "BookId", "CoverUrl", "DateAdded", "Dateread", "Description", "Genre", "IsRead", "PublisherId", "Rate", "Title" },
                values: new object[] { 1, "https://vn-test-11.slatic.net/p/0efaaf875db6cb29e98741f541540f79.jpg_1500x1500q80.jpg", new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), " là bộ truyện nổi tiếng và phổ biến rộng rãi bậc nhất trên toàn thế giới là một trong những bộ manga được tiêu thụ nhiều nhất mọi thời đại. Nó được bán ở hơn 40 quốc gia và anime được phát sóng ở hơn 80 quốc gia. 42 tập tankōbon được sưu tầm của manga đã bán được hơn 160 triệu bản ở Nhật Bản và 260 triệu bản được bán trên toàn thế giới tính đến năm 2019[7] Nó đã có tác động đáng kể đến văn hóa đại chúng toàn cầu , được tham khảo và truyền cảm hứng cho nhiều nghệ sĩ, vận động viên, người nổi tiếng, nhà làm phim, nhạc sĩ và nhà văn trên khắp thế giới.", 1, true, 1, 5, "Dragonball" });

            migrationBuilder.InsertData(
                table: "books_author",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_books_PublisherId",
                table: "books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_books_author_AuthorId",
                table: "books_author",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_author_BookId",
                table: "books_author",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books_author");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
