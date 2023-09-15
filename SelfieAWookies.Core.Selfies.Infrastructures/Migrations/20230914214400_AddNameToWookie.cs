﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookies.Core.Selfies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToWookie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Wookie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Wookie");
        }
    }
}
