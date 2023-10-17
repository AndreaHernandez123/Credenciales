using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Credenciales.Models
{
    public class RegistraEmplsViewModel
    {

        public string id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo Area es obligatorio")]
        public string area { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "El campo Whatsapp es obligatorio")]
        public string whatsapp { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string correo { get; set; }
        public string fotografia { get; set; }
        [Required(ErrorMessage = "El campo Num Empleado  es obligatorio")]
        public string numemp { get; set; }
        [Required(ErrorMessage = "El campo Fotografia es obligatorio")]
        public HttpPostedFileBase foto { get; set; }
    }
}