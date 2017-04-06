using System;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using QRCoder;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfpath = Path.GetDirectoryName("PDFs");
            string imagepath = Path.GetDirectoryName("Images");
            renderQRCode();
            string[] text = File.ReadAllLines(@"C:/users/muize/Desktop/concert.txt");
            string[] endtexts = new string[text.Length];
            int indi = 0;
            string endtext = "";
            int artiestID = 1;

            foreach (string line in text)
            {
                if (line.StartsWith("Artiest"))
                {
                    continue;
                }

                string[] splitText = line.Split();
                string artiest = splitText[0];
                int zaalNr = Convert.ToInt32(splitText[2]);
                DateTime date = Convert.ToDateTime(splitText[4] + " " + splitText[5]);
                string[] text2 = InfoOpslaan(artiest, zaalNr, date);
                for (int i = 0; i < text2.Length; i++)
                {
                    endtext += text2[i];
                    endtext += " ";
                }
                endtexts[indi] = endtext;
                endtext = "";
                indi++;
            }
            indi = 0;

            Document doc = new Document();
            try
            {
                PdfWriter.GetInstance(doc, new FileStream("C:/users/muize/screenshots/pdfjes.pdf", FileMode.Create));
                doc.Open();

                
                var titleFont = FontFactory.GetFont("Verdana", 40, BaseColor.BLACK);
                var parFont = FontFactory.GetFont("Verdana", 15, BaseColor.BLACK);
                var paragraph1 = new Paragraph("Uw ticket", titleFont);
                paragraph1.Alignment = Element.ALIGN_CENTER;
                doc.Add(paragraph1);
                var line = new Paragraph("______________________", titleFont);
                line.Alignment = Element.ALIGN_CENTER;
                doc.Add(line);
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(renderQRCode(), BaseColor.WHITE); 
                doc.Add(jpg);
                artiestID = indi + 2;
                var paragraph2 = new Paragraph(endtexts[indi + 1], parFont);
                doc.Add(paragraph2);
                iTextSharp.text.Image artist = iTextSharp.text.Image.GetInstance("C:/users/muize/screenshots/" + artiestID.ToString() + ".jpg");
                doc.Add(artist);

            }

            catch (Exception ex)
            {
                //Log error;
            }
            finally
            {
                doc.Close();
            }
        }

        private static string RandomString(int Size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            Random random = new Random();

            for (int i = 0; i < Size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }

            return builder.ToString();
        }

        private static System.Drawing.Image renderQRCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(RandomString(20), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Image qrCodeImage = qrCode.GetGraphic(5);
            return qrCodeImage;
        }

        private static string[] InfoOpslaan(string artiest, int zaalNr, DateTime datum)
        {
            string[] returnArray = new string[3];
            returnArray[0] = artiest;
            returnArray[1] = Convert.ToString(zaalNr);
            returnArray[2] = Convert.ToString(datum);
            return returnArray;
        }
    }
}
