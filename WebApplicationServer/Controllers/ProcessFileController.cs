namespace WebApplicationServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApplicationServer.Models;
    using WebApplicationServer.Repository;

    /// <summary>
    /// Controller ProcessFileController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessFileController : Controller
    {
        /// <summary>
        /// The process file repository
        /// </summary>
        private IProcessFileRepository _processFileRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessFileController"/> class.
        /// </summary>
        /// <param name="processFileRepository">The process file repository.</param>
        public ProcessFileController(IProcessFileRepository processFileRepository)
        {
            _processFileRepository = processFileRepository;
        }

        /// <summary>
        /// Gets the file to process.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
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