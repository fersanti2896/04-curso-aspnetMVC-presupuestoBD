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

            var existeTipoCuenta = await tiposCuentasRepository.ExisteTipoCuenta(tipoCuenta.Nombre, tipoCuenta.UsuarioID);

            if (existeTipoCuenta) {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre), $"El nombre { tipoCuenta.Nombre } ya existe!");

                return View(tipoCuenta);
            }

            await tiposCuentasRepository.Crear(tipoCuenta);

            return RedirectToAction("Index");
        }

        /* Verifica la existencia de un tipo de cuenta desde JS */
        [HttpGet]
        public async Task<IActionResult> VerificaExistenciaTipoCuenta(string nombre) {
            var usuarioID = 1;
            var existeTipoCuenta = await tiposCuentasRepository.ExisteTipoCuenta(nombre, usuarioID);

            if (existeTipoCuenta) { 
                return Json($"¡El nombre { nombre } ya existe!");
            }

            return Json(true);
        }

        /* Listado de Tipos Cuentas por Usuario ID */
        public async Task<IActionResult> Index() {
            var usuarioID = 1;
            var tiposCuentas = await tiposCuentasRepository.ObtenerListadoByUsuarioID(usuarioID);

            return View(tiposCuentas);  
        }
    }
}
