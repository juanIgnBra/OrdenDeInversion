using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdenesDeinversion.Migrations
{
    /// <inheritdoc />
    public partial class Primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ordenesDeInversion",
                columns: table => new
                {
                    IdDeLaOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDeLaCuenta = table.Column<int>(type: "int", nullable: false),
                    NombreDelActivo = table.Column<string>(type: "varchar(32)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operacion = table.Column<string>(type: "char(2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenesDeInversion", x => x.IdDeLaOrden);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordenesDeInversion");
        }
    }
}
