using QRCoder;

namespace Adisyon_OnionArch.Project.Application.Common.QrCodeHelpers
{
    public static class QrCodeHelper
    {
        public static string GenerateQrCode(int tableId)
        {
            string url = $"https://localhost-my-adisyon-project.com/menu/{tableId}";

            // QR Kodu oluştur
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            // QR kodu PNG byte dizisi olarak al
            byte[] qrCodeBytes = qrCode.GetGraphic(20);

            // SkiaSharp kullanarak byte dizisini PNG olarak dosyaya kaydet
            string qrCodeFileName = $"table-{tableId}-qrcode.png";
            string qrCodeFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "qrcodes", qrCodeFileName);

            // Byte dizisini dosyaya kaydetme
            File.WriteAllBytes(qrCodeFilePath, qrCodeBytes);

            return qrCodeFilePath; // Dosya yolunu döndür
        }
    }
}
