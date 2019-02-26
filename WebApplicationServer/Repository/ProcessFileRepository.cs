using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;
using WebApplicationServer.Mapping;
using WebApplicationServer.Models;

namespace WebApplicationServer.Repository
{
    public class ProcessFileRepository : IProcessFileRepository
    {
        public IEnumerable<CustomerInfo> GetCustomerInfos(byte[] bytesFile)
        {
            var customerList = new List<CustomerInfo>();
            CsvParserOptions csvParserOptions = new CsvParserOptions(false, '|');
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            CustomerInfoMapping csMapping = new CustomerInfoMapping();
            CsvParser<CustomerInfoModel> csvParser = new CsvParser<CustomerInfoModel>(csvParserOptions, csMapping);

            var data = Encoding.UTF8.GetString(bytesFile);
            var readerData = csvParser
                .ReadFromString(csvReaderOptions, data).ToList();

            readerData.ForEach(x =>
            {
                var pId = int.TryParse(x.Result.PersonId, out int resultPersonId);
                var nOc = int.TryParse(x.Result.NumberOfConnections, out int resultNumberOfConnections);
                var nOr = int.TryParse(x.Result.NumberOfRecommendations, out int resultNumberOfRecommendations);

                customerList.Add(new CustomerInfo
                {
                    PersonId = pId ? resultPersonId : default(int),
                    Name = x.Result.Name,
                    LastName = x.Result.LastName,
                    Country = x.Result.Country,
                    CurrentRole = x.Result.CurrentRole,
                    Industry = x.Result.Industry,
                    NumberOfConnections = nOc ? resultNumberOfConnections : default(int),
                    NumberOfRecommendations = nOr ? resultNumberOfRecommendations : default(int)
                });
            });

            return customerList;
        }

        public byte[] SaveToText(IEnumerable<CustomerInfo> customers)
        {
            string path = $"{Directory.GetCurrentDirectory()}\\people.out";
            if (File.Exists(path)) File.Delete(path);

            using (TextWriter tw = new StreamWriter(path))
            {
                foreach (var item in customers.ToList())
                {
                    //tw.WriteLine($"{item.PersonId}|{item.Name}|{item.LastName}|{item.CurrentRole}|{item.Country}|{item.Industry}|{item.NumberOfRecommendations}|{item.NumberOfConnections}");
                    tw.WriteLine($"{item.PersonId}");
                }
                tw.Close();
            }

            return File.ReadAllBytes(path);
        }
    }
}
