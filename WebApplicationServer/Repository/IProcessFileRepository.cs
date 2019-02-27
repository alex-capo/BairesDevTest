namespace WebApplicationServer.Repository
{
    using System.Collections.Generic;
    using WebApplicationServer.Models;

    /// <summary>
    /// Interface IProcessFileRepository
    /// </summary>
    public interface IProcessFileRepository
    {
        /// <summary>
        /// Gets the customer infos.
        /// </summary>
        /// <param name="bytesFile">The bytes file.</param>
        /// <returns></returns>
        IEnumerable<CustomerInfo> GetCustomerInfos(byte[] bytesFile);
        /// <summary>
        /// Saves to text.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <returns></returns>
        byte[] SaveToText(IEnumerable<CustomerInfo> customers);
    }
}
