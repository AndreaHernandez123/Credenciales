using Credenciales.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using static Credenciales.Controllers.ConsultaUsuarios;

namespace Credenciales.Controllers
{
    public class Insertardatos
    {

        public bool InsertDatos(string rutaok, RegistraEmplsViewModel model)
        {
            var options = new RestClientOptions("https://apimenu.capitalpeople.mx/")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("api/CredencialesP", Method.Put);

            request.AddHeader("Content-Type", "application/json");

            var body = $@"{{ ""token"": ""9ec161f7-e4e1-493a-94d6-2192d3c9b438"",""NombreComp"": ""{model.nombre.ToUpper()}"",""Area"": ""{model.area.ToUpper()}"",""Telefono"": ""{model.telefono}"",""Whatsapp"": ""{model.whatsapp}"",""Correo"": ""{model.correo}"",""Fotografia"": ""{rutaok}"",""NumEmp"": ""{model.numemp}""}}";


            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);                                    
            return true;
        }
    }
}