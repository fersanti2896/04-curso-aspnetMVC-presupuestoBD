using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models {
    public class TipoCuentaModel {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe ser entre {2} y {1}")]
        [Display(Name = "Nombre del tipo cuenta")]
        public string Nombre { get; set; }
        public int UsuarioID { get; set; }
        public int Orden { get; set; }
    }
}
