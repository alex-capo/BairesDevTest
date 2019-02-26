using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using WebApplicationServer.Models;

namespace WebApplicationServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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
            Response.Headers["Content-Disposition"] = $"attachment; filename=peopleOut_{DateTime.Today.ToString("M/d/yy HH:mm:ss")}.txt";
            return File(bytes, System.Net.Mime.MediaTypeNames.Text.Plain);
        }
    }
}
