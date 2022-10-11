using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Services {
    public class TiposCuentasRepository : ITiposCuentasRepository {
        /* Inserción de un tipo cuenta en la BD */
        private readonly string conecctionString;
        public TiposCuentasRepository(IConfiguration configuration) {
            conecctionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuentaModel tipoCuenta) { 
            using var connection = new SqlConnection(conecctionString);
            var id = await connection.QuerySingleAsync<int>($@"INSERT INTO TiposCuentas(Nombre, UsuarioID, Orden)
                                                               VALUES (@Nombre, @UsuarioID, 0);
                                                               SELECT SCOPE_IDENTITY();", tipoCuenta);

            tipoCuenta.Id = id;
        }
    }
}
