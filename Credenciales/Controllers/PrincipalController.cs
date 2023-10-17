using Credenciales.Models;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Ajax.Utilities;
using Microsoft.Win32;
using QRCoder;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;
using static System.Net.WebRequestMethods;
using QRCode = QRCoder.QRCode;
using iText.Html2pdf;
using Rotativa;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using Rotativa.Options;
using Orientation = System.Web.UI.WebControls.Orientation;
using Margins = Rotativa.Options.Margins;
using Size = Rotativa.Options.Size;
using static iTextSharp.text.TabStop;
using System.Windows.Controls;
using Xceed.Words.NET;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using DocumentFormat.OpenXml.EMMA;
using Credenciales.DataAccess;
using ContentDisposition = Rotativa.Options.ContentDisposition;
using System.Drawing.Drawing2D;

namespace Credenciales.Controllers
{
    public class PrincipalController : Controller
    {
        Insertardatos ins = new Insertardatos();
        ConsultarDatos cd = new ConsultarDatos();
        DataAcc dt = new DataAcc();
        ImagenCrede imgn = new ImagenCrede();

        public ActionResult Index()

        {

            return View();
        }
        public ActionResult Consulta()
        {

            return View();
        }
        public ActionResult Credencial(string numemp, DatosCredencialViewModel model)
        {
            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);
            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;
                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/Credencial?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/Credencial?NumEmp=";
                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }

            }
            return View(model);
        }
        public ActionResult CredencialCapital(string numemp, DatosCredencialViewModel model)
        {
            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);

            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;

                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/CredencialCapital?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/CredencialCapital?NumEmp=";

                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }

            }
            return View(model);
        }
        public ActionResult CredencialRhpay(string numemp, DatosCredencialViewModel model)
                {

            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);

            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;
                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/CredencialRhpay?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/CredencialRhpay?NumEmp=";

                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }

            }
            return View(model);
        }
        public ActionResult CredencialTrafico(string numemp, DatosCredencialViewModel model)
        {

            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);

            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;
                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/CredencialTrafico?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/CredencialTrafico?NumEmp=";

                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }

            }
            return View(model);
        }
        public ActionResult PartialCredencial(string numemp, DatosCredencialViewModel model)
        {
            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);
            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;
                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/PartialCredencial?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/Credencial?NumEmp=";

                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }
            }
            return View("PartialCredencial", model);
        }
        public ActionResult PartialCap(string numemp, DatosCredencialViewModel model)
        {
            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);
            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;            
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;
                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/CredencialCapital?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/CredencialCapital?NumEmp=";

                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }
            }
            return View(model);
        }
        public ActionResult PartialRh(string numemp, DatosCredencialViewModel model)
        {
            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);

            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;
                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/CredencialRhpay?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/CredencialRhpay?NumEmp=";

                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }

            }
            return View(model);
        }
        public ActionResult PartialTrafico(string numemp, DatosCredencialViewModel model)
        {
            string vr = numemp;

            var condatos = cd.ConsultaEmp(vr);

            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia);
                Session["DatosCredencial"] = model;
                string baseUrl = "https://pruebascp.capitalpeople.mx/Principal/CredencialTrafico?NumEmp=";
                //string baseUrl = "https://localhost:44344/Principal/CredencialTrafico?NumEmp=";

                string qrCodeURL = baseUrl + numemp;
                // Generar el código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeURL, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                // Convertir la imagen del código QR a una representación en base64 para mostrarla en la vista
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = stream.ToArray();
                    string base64Image = Convert.ToBase64String(imageBytes);
                    model.qrCodeImage = "data:image/png;base64," + base64Image;
                }

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult RegistrarEmpl( RegistraEmplsViewModel model)
            {
            string fechahoy = DateTime.Now.ToString("ddMMyyyyhhss");
            string numEmp = model.numemp + fechahoy;
            string rutasitio = Server.MapPath("~/Fotografias");

            string rutaok = "~/Fotografias" + "/" + numEmp + model.foto.FileName;
            string rutacarpeta = Path.Combine(rutasitio + "/" + numEmp + model.foto.FileName);
            model.foto.SaveAs(rutacarpeta);
            // Validar que esten llenos correctamente los campos.
            if (string.IsNullOrEmpty(model.nombre) ||
                string.IsNullOrEmpty(model.numemp) ||
                string.IsNullOrEmpty(model.area) ||
                string.IsNullOrEmpty(model.telefono) ||
                string.IsNullOrEmpty(model.whatsapp) ||
                string.IsNullOrEmpty(model.correo) ||
                string.IsNullOrEmpty(rutaok))
            {
                ModelState.AddModelError(string.Empty, "Por favor completa todos los campos obligatorios.");
                return View(model);
            }
            var consult = ins.InsertDatos(rutaok, model);

                Session["NumEmp"] = model.numemp;
            using (var image = System.Drawing.Image.FromStream(model.foto.InputStream, true, true))
            {
                var newWidth = 180;
                var newHeight = 180;

                foreach (var format in new[] { System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Png })
                {
                    using (var newImage = new Bitmap(newWidth, newHeight))
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, newWidth, newHeight));

                        // Guardar la imagen en el formato actual
                        var filePath = Path.ChangeExtension(rutacarpeta, format.ToString().ToLower());
                        newImage.Save(filePath, format);
                    }
                }
            }


            if (consult == true)
            {            
                if (model.area == "GN10")
                {
                    return RedirectToAction("Credencial", "Principal", new { NumEmp = model.numemp });
                }
                if(model.area == "CAPITAL PEOPLE")
                {
                    return RedirectToAction("CredencialCapital", "Principal", new { NumEmp = model.numemp });
                }
                if (model.area == "RH PAY")
                {
                    return RedirectToAction("CredencialRhpay", "Principal", new { NumEmp = model.numemp });
                }
                if (model.area == "TRAFICO")
                {
                    return RedirectToAction("CredencialTrafico", "Principal", new { NumEmp = model.numemp });
                }
            }
            TempData["ok"] = "Registro completado";

            return RedirectToAction("Credencial", "Principal");

        }
        [HttpPost]
        public ActionResult ConsultarEmpleados(string numemp, DatosCredencialViewModel model)
        {

            var condatos = cd.ConsultaEmp(numemp);

            Session["NumEmp"] = model.numemp;

            if (condatos.Item1 == HttpStatusCode.OK)
            {
                model.numemp = condatos.Item2.NumEmp;
                model.nombre = condatos.Item2.NombreComp;
                model.area = condatos.Item2.Area;
                model.telefono = condatos.Item2.Telefono;
                model.whatsapp = condatos.Item2.Whatsapp;
                model.correo = condatos.Item2.Correo;
                model.fotografia = Url.Content(condatos.Item2.Fotografia); // Convertir la ruta virtual en una URL válida
            }
            if (model.area == "GN10")
            {
                return RedirectToAction("Credencial", "Principal", new { NumEmp = model.numemp });
            }
            if (model.area == "CAPITAL PEOPLE")
            {
                return RedirectToAction("CredencialCapital", "Principal", new { NumEmp = model.numemp });
            }
            if (model.area == "RH PAY")
            {
                return RedirectToAction("CredencialRhpay", "Principal", new { NumEmp = model.numemp });
            }
            if (model.area == "TRAFICO")
            {
                return RedirectToAction("CredencialTrafico", "Principal", new { NumEmp = model.numemp });
            }
            else
            {
            return RedirectToAction("Index", "Principal");
            }
        }

        public ActionResult GenerarPDF()
        {
            var model = (DatosCredencialViewModel)Session["DatosCredencial"];
            if (model == null)
            {
                return RedirectToAction("Error");
            }
            string vista = "Credencial"; 
            string nombreArchivo = "Credencial.pdf";        
            if (model.area == "GN10")
            {
                vista = "PartialCredencial";
                nombreArchivo = "CredencialGN10.pdf";
            }
            else if (model.area == "CAPITAL PEOPLE")
            {
                vista = "PartialCap";
                nombreArchivo = "CredencialCapitalPeople.pdf";
            }
            else if (model.area == "RH PAY")
            {
                vista = "PartialRh";
                nombreArchivo = "CredencialRhpay.pdf";
            }
            else if (model.area == "TRAFICO")
            {
                vista = "PartialTrafico";
                nombreArchivo = "CredencialTrafico.pdf";
            }
            return new ViewAsPdf(vista, model)
            {
                FileName = nombreArchivo, 
                PageSize = Size.A4,
                ContentDisposition = ContentDisposition.Attachment
            };
        }
    }
}


//public void GeneraWord(string numemp)
//{
//    var model = (DatosCredencialViewModel)Session["DatosCredencial"];
//    string fechahoy = DateTime.Now.ToString("ddMMyyyyhhss");
//    string numEmp = model.numemp + fechahoy;
//    string fotografia = Url.Content(model.fotografia);
//    string rutasitio = Server.MapPath("~/Fotografias");

//    string fileName = fotografia;
//    string filePath = Path.Combine(rutasitio, fileName);

//    string documento = Server.MapPath("~/Documents/prueba.docx");
//    var doc = dt.SearchAndReplace(numemp, documento, model);
//    imgn.ReplaceImageWithText(doc, documento, filePath);
//}