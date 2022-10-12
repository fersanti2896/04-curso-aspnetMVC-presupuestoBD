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

        /* Verifica si existe una cuenta en la BD */
        public async Task<bool> ExisteTipoCuenta(string nombre, int usuarioID) {
            using var connection = new SqlConnection(conecctionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>($@"SELECT 1
                                                                           FROM TiposCuentas
                                                                           WHERE Nombre = @Nombre AND UsuarioID = @UsuarioID;", 
                                                                        new { nombre, usuarioID });

            return existe == 1;
        }

        /* Listado de Tipos Cuentas */
        public async Task<IEnumerable<TipoCuentaModel>> ObtenerListadoByUsuarioID(int usuarioID) {
            using var connection = new SqlConnection(conecctionString);

            return await connection.QueryAsync<TipoCuentaModel>(@"SELECT Id, Nombre, Orden 
                                                                  FROM TiposCuentas
                                                                  WHERE UsuarioID = @UsuarioID", new { usuarioID });
        }
    }
}
