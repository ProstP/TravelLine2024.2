﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordHashLen : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof( string ),
                oldType: "nvarchar(50)",
                oldMaxLength: 50 );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof( string ),
                oldType: "nvarchar(100)",
                oldMaxLength: 100 );
        }
    }
}
