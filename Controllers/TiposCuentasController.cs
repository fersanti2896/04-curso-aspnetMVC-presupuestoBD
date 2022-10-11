using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Controllers {
    public class TiposCuentasController : Controller {
        private readonly ITiposCuentasRepository tiposCuentasRepository;

        public TiposCuentasController(ITiposCuentasRepository tiposCuentasRepository) {
            this.tiposCuentasRepository = tiposCuentasRepository;
        }

        public IActionResult Crear() {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuentaModel tipoCuenta) {
            if (!ModelState.IsValid) {
                return View(tipoCuenta);
            }

            tipoCuenta.UsuarioID = 1;
            await tiposCuentasRepository.Crear(tipoCuenta);   

            return View();
        }
    }
}
