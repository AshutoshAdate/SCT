﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCT.Migrations
{
    /// <inheritdoc />
    public partial class addedprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "users",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "users");
        }
    }
}
