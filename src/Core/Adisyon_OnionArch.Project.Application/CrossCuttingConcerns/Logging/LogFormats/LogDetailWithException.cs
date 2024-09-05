using Adisyon_OnionArch.Project.Domain.Common;
using Microsoft.AspNetCore.Http;

namespace Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Logging.LogFormats
{
    public class LogDetailWithException  : EntityBase
    {
        public string TraceId { get; set; }
        public string LogType { get; set; }
        public string Path { get; set; }
        public string Query { get; set; }
        public string Header { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public int StatusCode { get; set; }
        public string HttpMethod { get; set; }
        public string IpAddress { get; set; }
        public DateTime LogDate { get; set; }
        public string User { get; set; }
        public string Detail { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }

}
