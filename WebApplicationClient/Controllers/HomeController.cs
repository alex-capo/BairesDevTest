namespace WebApplicationServer.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using WebApplicationServer.Models;

    /// <summary>
    /// Home Controller 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sends the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SendFile(IFormFile file)
        {
            byte[] buff = null;
            BinaryReader br = null;

            Stream path = file.OpenReadStream();

            using (StreamReader st = new StreamReader(path))
            {
                br = new BinaryReader(path);
                long numBytes = file.Length;
                buff = br.ReadBytes((int)numBytes);
                st.Close();
            }

            FileProcess fileToProcess = new FileProcess
            {
                FileName = file.FileName,
                FileLength = file.Length,
                BytesFile = buff
            };

            System.Net.Http.HttpResponseMessage content = Utils.GenericHttpClient.PostFileGeneric(fileToProcess);
            byte[] bytes = content.Content.ReadAsByteArrayAsync().Result;
            Response.ContentType = "text/plain";
            Response.Headers["Content-Disposition"] = $"attachment; filename=people.out";
            return File(bytes, System.Net.Mime.MediaTypeNames.Text.Plain);
        }
    }
}
