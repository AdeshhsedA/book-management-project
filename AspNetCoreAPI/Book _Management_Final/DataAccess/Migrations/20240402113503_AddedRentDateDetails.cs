using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book__Management_Final.Migrations
{
    /// <inheritdoc />
    public partial class AddedRentDateDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RentedDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnedDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedReturnDate",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "RentedDate",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "BorrowedBooks");
        }
    }
}
