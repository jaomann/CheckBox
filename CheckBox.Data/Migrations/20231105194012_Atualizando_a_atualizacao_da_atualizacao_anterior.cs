using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckBox.Data.Migrations
{
    /// <inheritdoc />
    public partial class Atualizandoaatualizacaodaatualizacaoanterior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NoteId",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "users");
        }
    }
}
