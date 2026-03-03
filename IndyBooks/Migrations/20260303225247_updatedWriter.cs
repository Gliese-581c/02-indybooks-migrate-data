using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndyBooks.Migrations
{
    /// <inheritdoc />
    public partial class updatedWriter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddColumn<long>(
                name: "AuthorId",
                table: "Books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writers_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Writers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writers_AuthorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }
    }
}
