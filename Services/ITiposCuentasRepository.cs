using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Services {
    public interface ITiposCuentasRepository {
        Task Crear(TipoCuentaModel tipoCuenta);
        Task<bool> ExisteTipoCuenta(string nombre, int usuarioID);
        Task<IEnumerable<TipoCuentaModel>> ObtenerListadoByUsuarioID(int usuarioID);
    }
}
