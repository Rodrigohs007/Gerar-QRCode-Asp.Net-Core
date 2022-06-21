using QRCoder;
using System.Drawing;
using System.IO;

namespace Gerando_QRCode.Funcoes
{
    public class QRCode_Generate
    {

        public static Bitmap GenerateImage(string url)
        {
            var qrGenerate = new QRCodeGenerator();
            var qrCodeData = qrGenerate.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrcode = new QRCode(qrCodeData);
            var qrCodeImage = qrcode.GetGraphic(10);
            return qrCodeImage;

        }

        private static byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }

        public static byte[] GenerateByteArray(string url)
        {
            var image = GenerateImage(url);
            return ImageToByte(image);
        }
    }
}
