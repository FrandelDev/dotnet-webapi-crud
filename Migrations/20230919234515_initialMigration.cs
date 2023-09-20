using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiProject.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrioridadTarea = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Task_Category_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Category",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre" },
                values: new object[] { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), null, "Cat1" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TareaId", "Apellido", "CategoriaId", "Descripcion", "FechaCreacion", "Nombre", "PrioridadTarea" },
                values: new object[] { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"), "Corporan", new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), "Testing EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frandel", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Task_CategoriaId",
                table: "Task",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
