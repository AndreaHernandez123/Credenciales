using Credenciales.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using static Credenciales.Controllers.ConsultarDatos;

namespace Credenciales.Controllers
{
    public class ConsultarDatos
    {
        public class Root
        {
            [JsonProperty("$id")]
            public string id { get; set; }
            public string NombreComp { get; set; }
            public string Area { get; set; }
            public string Telefono { get; set; }
            public string Whatsapp { get; set; }
            public string Correo { get; set; }
            public string Fotografia { get; set; }
            public string NumEmp { get; set; }
        }
        public (HttpStatusCode, ConsultaEmpleadosViewModel) ConsultaEmp(string numempl)        
        {
                            
            ConsultaEmpleadosViewModel userData = null;
            var options = new RestClientOptions("https://apimenu.capitalpeople.mx/")
           
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("api/CredencialesDatos", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = $@"{{""token"": ""9ec161f7-e4e1-493a-94d6-2192d3c9b438"", ""nuimempleado"":""{numempl}""}}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Root> responseDataList = JsonConvert.DeserializeObject<List<Root>>(response.Content);
                if (responseDataList.Count > 0)
                {
                    Root responseData = responseDataList[0];
                    userData = new ConsultaEmpleadosViewModel
                    {
                        NombreComp = responseData.NombreComp,
                        Area = responseData.Area,
                        Telefono = responseData.Telefono,
                        Whatsapp = responseData.Whatsapp,
                        Correo = responseData.Correo,
                        Fotografia = responseData.Fotografia,
                        NumEmp = responseData.NumEmp,
                    };
                }             
            }

            return (response.StatusCode, userData);
        }
        public class ConsultaEmpleadosViewModel
        {
            public string id { get; set; }
            public string NombreComp { get; set; }
            public string Area { get; set; }
            public string Telefono { get; set; }
            public string Whatsapp { get; set; }
            public string Correo { get; set; }
            public string Fotografia { get; set; }
            public string NumEmp { get; set; }
        }
    }
}