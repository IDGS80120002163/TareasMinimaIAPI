﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasMinimaIAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaPesoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Categoria");
        }
    }
}
