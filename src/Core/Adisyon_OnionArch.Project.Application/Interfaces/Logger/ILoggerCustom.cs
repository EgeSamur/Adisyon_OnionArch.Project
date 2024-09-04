namespace Adisyon_OnionArch.Project.Application.Interfaces.Logger
{
    public interface ILoggerCustom
    {
        void Error(string message); // Hata mesajları için
        void Info(string message);  // Bilgilendirme mesajları için
        void Warn(string message);  // Uyarı mesajları için
    }
}
