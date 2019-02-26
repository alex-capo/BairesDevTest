using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationServer.Models;

namespace WebApplicationServer.Repository
{
    public interface IProcessFileRepository
    {
        IEnumerable<CustomerInfo> GetCustomerInfos(byte[] bytesFile);
        byte[] SaveToText(IEnumerable<CustomerInfo> customers);
    }
}
