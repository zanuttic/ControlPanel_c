using System;
using System.ComponentModel.DataAnnotations;

namespace ControlPanel.Models
{
    public class MemoTest
    {
        public int MemoTestID { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 50")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 250")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Verifique que la cantidad de caracteres ingresado sea mayor a 3 y menor de 250")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public Boolean Estado { get; set; }
    }
}
