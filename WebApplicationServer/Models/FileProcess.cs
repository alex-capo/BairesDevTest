namespace WebApplicationServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// Entity FileProcess
    /// </summary>
    public class FileProcess
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the length of the file.
        /// </summary>
        /// <value>
        /// The length of the file.
        /// </value>
        public long FileLength { get; set; }
        /// <summary>
        /// Gets or sets the bytes file.
        /// </summary>
        /// <value>
        /// The bytes file.
        /// </value>
        public byte[] BytesFile { get; set; }
    }
}
