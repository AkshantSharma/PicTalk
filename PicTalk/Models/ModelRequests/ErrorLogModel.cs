using System;

namespace PicTalk.Models.ModelRequests
{
    public class ErrorLogModel
    {
        public int Id { get; set; }
        public string UDID { get; set; }
        public string ExceptionMessage { get; set; }
        public string Module { get; set; }
        public DateTime ErrorLogTime { get; set; }
    }
}
