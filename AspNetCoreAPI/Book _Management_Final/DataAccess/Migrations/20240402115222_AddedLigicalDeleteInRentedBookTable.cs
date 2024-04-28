using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book__Management_Final.Migrations
{
    /// <inheritdoc />
    public partial class AddedLigicalDeleteInRentedBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BorrowedBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BorrowedBooks");
        }
    }
}
