using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Linq;
using System.Web;

namespace Credenciales.Models
{
    public class DatosCredencialViewModel
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string area { get; set; }
        public string telefono { get; set; }
        public string whatsapp { get; set; }
        public string correo { get; set; }
        public string fotografia { get; set; }
        public string numemp { get; set; }
        public HttpPostedFileBase foto { get; set; }
        public string qrCodeImage { get; set; }


    }
}