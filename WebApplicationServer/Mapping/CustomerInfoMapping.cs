using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;
using WebApplicationServer.Models;

namespace WebApplicationServer.Mapping
{
    public class CustomerInfoMapping: CsvMapping<CustomerInfoModel>
    {
        public CustomerInfoMapping()
        {
            MapProperty(0, x => x.PersonId);
            MapProperty(1, x => x.Name);
            MapProperty(2, x => x.LastName);
            MapProperty(3, x => x.CurrentRole);
            MapProperty(4, x => x.Country);
            MapProperty(5, x => x.Industry);
            MapProperty(6, x => x.NumberOfRecommendations);
            MapProperty(7, x => x.NumberOfConnections);
        }
    }
}
