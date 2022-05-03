using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPhoneBook.Dal.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Addresses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Addresses",
                newName: "AddressId");
        }
    }
}
