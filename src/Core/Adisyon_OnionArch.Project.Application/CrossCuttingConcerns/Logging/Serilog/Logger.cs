using Adisyon_OnionArch.Project.Application.Interfaces.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Logging.Serilog
{
    public class LoggerCustom : ILoggerCustom
    {
        private readonly ILogger<LoggerCustom> _logger;

        public LoggerCustom(ILogger<LoggerCustom> logger)
        {
            _logger = logger;
        }

        // Hata mesajlarını loglama
        public void Error(string message)
        {
            _logger.LogError(message);
        }

        // Bilgilendirme mesajlarını loglama
        public void Info(string message)
        {
            _logger.LogInformation(message);
        }

        // Uyarı mesajlarını loglama
        public void Warn(string message)
        {
            _logger.LogWarning(message);
        }
    }

}
