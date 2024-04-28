using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book__Management_Final.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactColumnForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Contact",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Users");
        }
    }
}
