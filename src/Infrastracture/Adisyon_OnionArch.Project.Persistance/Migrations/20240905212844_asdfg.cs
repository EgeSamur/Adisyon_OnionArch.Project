using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adisyon_OnionArch.Project.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class asdfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PaswordHashByte",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaswordHashByte",
                table: "AspNetUsers");
        }
    }
}
