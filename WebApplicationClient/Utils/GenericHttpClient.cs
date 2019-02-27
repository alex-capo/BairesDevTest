namespace WebApplicationServer.Utils
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using WebApplicationServer.Models;

    /// <summary>
    /// Class GenericHttpClient
    /// </summary>
    public class GenericHttpClient
    {        
        /// <summary>
        /// The URL
        /// </summary>
        private static string Url = "https://webapplicationserver20190227113806.azurewebsites.net/api/ProcessFile/UploadFile";
        
        /// <summary>
        /// Posts the file generic.
        /// </summary>
        /// <param name="byteFile">The byte file.</param>
        /// <returns></returns>
        public static HttpResponseMessage PostFileGeneric(FileProcess byteFile)
        {          
            HttpResponseMessage response = new HttpResponseMessage();
            string url = $"{Url}/";
            string content = JsonConvert.SerializeObject(byteFile);
            StringContent httpContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = client.PostAsync(url, httpContent).Result;
                if (!resp.IsSuccessStatusCode)response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                string contentResponse = resp?.Content?.ReadAsStringAsync()?.Result;
                response.Content = new StringContent(contentResponse?? string.Empty);
            }
            return response;
        }
    }
}
