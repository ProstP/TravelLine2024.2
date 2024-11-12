﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFiledsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof( string ),
                oldType: "nvarchar(50)",
                oldMaxLength: 50 );

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Recipe",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof( string ),
                oldType: "nvarchar(100)",
                oldMaxLength: 100 );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof( string ),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true );

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Recipe",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof( string ),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true );
        }
    }
}
