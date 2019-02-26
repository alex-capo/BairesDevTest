using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationServer.Models;
using WebApplicationServer.Repository;

namespace WebApplicationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessFileController : Controller
    {
        private IProcessFileRepository _processFileRepository;

        public ProcessFileController(IProcessFileRepository processFileRepository)
        {
            _processFileRepository = processFileRepository;
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> GetFileToProcess(FileProcess file)
        {
            var records = _processFileRepository.GetCustomerInfos(file.BytesFile);
            var rankingRecord = records.OrderByDescending(o => o.NumberOfConnections).ThenByDescending(c => c.NumberOfRecommendations).Take(100);
            var bytesFile = _processFileRepository.SaveToText(rankingRecord);

            return File(bytesFile, System.Net.Mime.MediaTypeNames.Text.Plain, "people.out");
        }
    }
}