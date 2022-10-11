using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Services {
    public interface ITiposCuentasRepository {
        Task Crear(TipoCuentaModel tipoCuenta);
    }
}
