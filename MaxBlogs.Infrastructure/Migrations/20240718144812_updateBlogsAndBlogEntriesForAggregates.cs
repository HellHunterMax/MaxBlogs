using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxBlogs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateBlogsAndBlogEntriesForAggregates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsEntries_Blogs_BlogId",
                table: "BlogsEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsEntries_Users_UserId",
                table: "BlogsEntries");

            migrationBuilder.DropIndex(
                name: "IX_BlogsEntries_BlogId",
                table: "BlogsEntries");

            migrationBuilder.DropIndex(
                name: "IX_BlogsEntries_UserId",
                table: "BlogsEntries");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BlogsEntries",
                newName: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "BlogsEntries",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsEntries_BlogId",
                table: "BlogsEntries",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsEntries_UserId",
                table: "BlogsEntries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsEntries_Blogs_BlogId",
                table: "BlogsEntries",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsEntries_Users_UserId",
                table: "BlogsEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
