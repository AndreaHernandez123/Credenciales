using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Credenciales.Models
{
    public class UserViewModel
    {
        public int Id_user { get; set; }
        public string usuario { get; set; }
        public string contra { get; set; }
        public string tipo_Usuario { get; set; }

    }
}