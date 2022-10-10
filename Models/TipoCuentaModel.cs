using ManejoPresupuesto.Validations;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models {
    public class TipoCuentaModel {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe ser entre {2} y {1}")]
        [Display(Name = "Nombre del tipo cuenta")]
        [PrimeraMayuscula]
        public string Nombre { get; set; }

        public int UsuarioID { get; set; }
        public int Orden { get; set; }

        /* Otras validaciones por defecto */
        /*[Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 18, maximum: 99, ErrorMessage = "La edad debe estar entre {1} y {2}")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electrónico válido")]
        public string Email { get; set; }

        [Url(ErrorMessage = "El campo debe ser una URL válida")]
        public string URL { get; set; }

        [CreditCard(ErrorMessage = "La TDC no es válida")]
        [Display(Name = "Tarjeta de Crédito")]
        public int TDC { get; set; } */
    }
}
