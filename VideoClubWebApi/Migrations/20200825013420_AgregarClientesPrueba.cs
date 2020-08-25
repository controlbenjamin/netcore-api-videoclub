using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoClubWebApi.Migrations
{
    public partial class AgregarClientesPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Correa', 'Benjamín', '31526875')");
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Perez', 'Miriam', '36258753')");
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Dion', 'Celine', '30263987')");
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Sanchez', 'Marta', '224556336')");
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Vai', 'Steve Ciro', '17233666')");
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Mercado', 'Wally', '23695565')");
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Marquez', 'Lisandro', '6987456')");
            migrationBuilder.Sql("INSERT INTO Clientes (Apellidos, Nombres, Dni) VALUES ('Gimenez', 'Susana', '10222333')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Clientes ");
        }
    }
}
