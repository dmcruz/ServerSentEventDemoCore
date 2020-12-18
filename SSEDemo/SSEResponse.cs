using System;
namespace SSEDemo
{
    public class SSEResponse
    {
        public SSEResponse()
        {
            Id = 1;
            Url = "http://www.google.com";
            Ts = DateTime.Now;

        }

        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime Ts { get; set; }
    }
}
