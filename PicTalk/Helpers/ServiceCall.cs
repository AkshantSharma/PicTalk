using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PicTalk.Helpers
{
    public static class ServiceCall
    {
        public static async Task<T> PostData<T, Tr>(string endpoint, HttpMethod method,
                                                         Tr content)
        {

            T returnResult = default(T);

            try
            {

                HttpClient client = null;

                client = new HttpClient();
                client.BaseAddress = new Uri(PTConstant.Host);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "7cd3e8fc8ebd43e695de859c4ed5c70e");

                client.Timeout = new TimeSpan(0, 0, 15);

                HttpResponseMessage result = null;

                StringContent data = null;
                if (content != null)
                    data = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                if (method == HttpMethod.Get)
                    result = await client.GetAsync(endpoint);

                if (method == HttpMethod.Put)
                    result = await client.PutAsync(endpoint, data);

                if (method == HttpMethod.Delete)
                    result = await client.DeleteAsync(endpoint);

                if (method == HttpMethod.Post)
                    result = await client.PostAsync(endpoint, data);

                if (result != null)
                {
                    if (result.IsSuccessStatusCode
                                       && result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        returnResult = JsonConvert.DeserializeObject<T>(json);
                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }

            return returnResult;
        }

        public static object PostData<T1, T2>(T2 v, object get, object p)
        {
            throw new NotImplementedException();
        }
    }
}
