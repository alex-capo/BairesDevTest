using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationServer.Models
{
    public class FileProcess
    {
        public string FileName { get; set; }
        public long FileLength { get; set; }
        public byte[] BytesFile { get; set; }
    }
}
