﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCatalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userID_Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Albums");
        }
    }
}
