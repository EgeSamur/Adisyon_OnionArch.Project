namespace Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Exceptions
{
    public class ExceptionModel 
    {
        public IEnumerable<string> Errors { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(Errors);
        }
    }

    //public class ErrorStatusCode
    //{
    //    public int StatusCode { get; set; }
    //}
}
