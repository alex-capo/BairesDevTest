using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplicationServer.Models;

namespace WebApplicationServer.Utils
{
    public class GenericHttpClient
    {
        private const string Url = "https://localhost:44380/api/ProcessFile/UploadFile";

        public static HttpResponseMessage PostFileGeneric(FileProcess byteFile)
        {
            var response = new HttpResponseMessage();
            var url = $"{Url}/";
            var content = JsonConvert.SerializeObject(byteFile);
            var httpContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var resp = client.PostAsync(url, httpContent).Result;
                if (!resp.IsSuccessStatusCode)response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                var contentResponse = resp?.Content?.ReadAsStringAsync()?.Result;
                response.Content = new StringContent(contentResponse?? string.Empty);
            }
            return response;
        }

    }
}
