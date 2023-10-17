using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace Credenciales.DataAccess
{
    public class ImagenCrede
    {
        public void ReplaceImageWithText(string docf, string imagePath, string docfinal)
        {
            Document document = new Document();
            document.LoadFromFile(docf);
            Image image = Image.FromFile(imagePath);
            Image img_fnl = resizeImage(image, 200, 200);
            TextSelection[] selections = document.FindAllString("E-iceblue", true, true);

            foreach (TextSelection selection in selections)
            {
                DocPicture pic = new DocPicture(document);
                pic.LoadImage(img_fnl);

                TextRange range = selection.GetAsOneRange();
                int index = range.OwnerParagraph.ChildObjects.IndexOf(range);
                range.OwnerParagraph.ChildObjects.Insert(index, pic);
                range.OwnerParagraph.ChildObjects.Remove(range);
            }
            string documento = docfinal + "/" + "prueba.docx";
            document.SaveToFile(documento, FileFormat.Docx);
            image.Dispose();
            img_fnl.Dispose();


        }

        private Image resizeImage(Image image, int width, int height)
        {
            var destinationRect = new Rectangle(0, 0, width, height);
            var destinationImage = new Bitmap(width, height);

            destinationImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);



            using (var graphics = Graphics.FromImage(destinationImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;



                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destinationRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }



            return (Image)destinationImage;
        }



    }

}