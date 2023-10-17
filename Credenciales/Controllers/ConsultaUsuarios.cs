using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Credenciales.Controllers
{
    public class ConsultaUsuarios
    {
        public class Root
        {
            [JsonProperty("$id")]
            public string id { get; set; }
            public string usuario { get; set; }
            public string nombre_Usuario { get; set; }
            public string tipo_Usuario { get; set; }
        }



        public (HttpStatusCode, UsuarioViewModel) ConsultaUser(string user, string contra)
        
        {
            UsuarioViewModel userData = null;
            var options = new RestClientOptions("https://apimenu.capitalpeople.mx/")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("api/CredencialesP", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = $@"{{""token"": ""9ec161f7-e4e1-493a-94d6-2192d3c9b438"",""usuario"": ""{user}"",""pass"": ""{contra}""}}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Root> responseDataList = JsonConvert.DeserializeObject<List<Root>>(response.Content);
                if (responseDataList.Count > 0)
                {
                    Root responseData = responseDataList[0];
                    userData = new UsuarioViewModel
                    {
                        usuario = responseData.usuario,
                        nombre_Usuario = responseData.nombre_Usuario,
                        tipo_Usuario = responseData.tipo_Usuario
                    };
                }

            }
            return (response.StatusCode, userData);
        }



        public class UsuarioViewModel
        {
            public string id { get; set; }
            public string usuario { get; set; }
            public string nombre_Usuario { get; set; }
            public string tipo_Usuario { get; set; }
        }
    }
}