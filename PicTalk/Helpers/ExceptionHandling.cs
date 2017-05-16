using Newtonsoft.Json;
using PicTalk.Models.ModelRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PicTalk.Helpers
{
    public static class ExceptionHandling
    {
        public static async void LogUnhandledException
            (Exception exception, string model = "", string _UDID = "")
        {
            try
            {
                const string errorFileName = "Fatal.txt";
                var httpClient = new HttpClient();

                ErrorLogModel logModel = new ErrorLogModel()
                {
                    ExceptionMessage = exception.Message,
                    Module = model,
                    ErrorLogTime = DateTime.Now,
                    UDID = _UDID
                };


                StringContent content = new StringContent(JsonConvert.SerializeObject(logModel), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(PTConstant.ErrorApi, content);
                if (response.IsSuccessStatusCode)
                {
                }

            }
            catch (Exception ex)
            {
                // just suppress any error logging exceptions
            }
        }
    }
}
