using Credenciales.Controllers;
using Credenciales.Models;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Navigation;

namespace Credenciales.DataAccess
{
    public class DataAcc
    {
        ConsultarDatos cd = new ConsultarDatos();
        public string SearchAndReplace(string numemp, string document, DatosCredencialViewModel model)
        {

            string documento = " ";
            string fechahoy = DateTime.Now.ToString("ddMMyyyyhhmmss");
            var condatos = cd.ConsultaEmp(numemp);
            File.Copy(document, HttpContext.Current.Server.MapPath("~/Documents/" + condatos.Item2.NumEmp + fechahoy + ".docx"), true);
            documento = HttpContext.Current.Server.MapPath("~/Documents/" + condatos.Item2.NumEmp + fechahoy + ".docx");
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(documento, true))
            {

                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }
                Regex regexApaterno = new Regex("Nombre");
                docText = regexApaterno.Replace(docText, condatos.Item2.NombreComp);
                Regex regexArea = new Regex("Area");
                docText = regexArea.Replace(docText, condatos.Item2.Area);
                Regex regexTelefono = new Regex("Telefono");
                docText = regexTelefono.Replace(docText, condatos.Item2.Telefono);
                Regex regexWhatsapp = new Regex("Whatsapp");
                docText = regexWhatsapp.Replace(docText, condatos.Item2.Whatsapp);
                Regex regexCorreo = new Regex("Correo");
                docText = regexCorreo.Replace(docText, condatos.Item2.Correo);
                Regex regexNumemp = new Regex("Numemp");
                docText = regexNumemp.Replace(docText, condatos.Item2.NumEmp);
                docText = docText.Replace("Numemp", model.numemp);
                using (System.IO.StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create), Encoding.UTF8))
                {
                    sw.Write(docText);

                }
                string fName = documento;
                FileInfo fi = new FileInfo(fName);
                long sz = fi.Length;

            }
            return documento;
        }


        public string convertimages(string ruta) 
        {
            string base64Imagen = string.Empty;
            byte[] bytesImagen = File.ReadAllBytes(ruta);
            base64Imagen = Convert.ToBase64String(bytesImagen);
            if (string.IsNullOrEmpty(base64Imagen))
                return "N/A";
            else
                return base64Imagen;
            
        }

    
    }
}