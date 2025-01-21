using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrdenesDeinversion.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(type: "varchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(max)", nullable: false),
                    TipoActivo = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "activos",
                columns: new[] { "Id", "Nombre", "PrecioUnitario", "Ticker", "TipoActivo" },
                values: new object[,]
                {
                    { 1, "Apple", 177.97, "AAPL", 1 },
                    { 2, "Alphabet Inc", 138.21000000000001, "GOOGL", 1 },
                    { 3, "Microsoft", 329.04000000000002, "MSFT", 1 },
                    { 4, "Coca Cola", 58.299999999999997, "KO", 1 },
                    { 5, "Walmart", 163.41999999999999, "WMT", 1 },
                    { 6, "BONOS ARGENTINA USD 2030 L.A", 307.39999999999998, "AL30", 2 },
                    { 7, "Bonos Globales Argentina USD Step Up 2030", 336.10000000000002, "GD30", 2 },
                    { 8, "Delta Pesos Clase A", 0.018100000000000002, "Delta.Pesos", 3 },
                    { 9, "Fima Premium Clase A", 0.031699999999999999, "Fima.Premium", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activos");
        }
    }
}
