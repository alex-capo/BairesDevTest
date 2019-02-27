namespace WebApplicationServer.Mapping
{
    using TinyCsvParser.Mapping;
    using WebApplicationServer.Models;

    /// <summary>
    /// Class CustomerInfoMapping
    /// </summary>
    /// <seealso cref="TinyCsvParser.Mapping.CsvMapping{WebApplicationServer.Models.CustomerInfoModel}" />
    public class CustomerInfoMapping: CsvMapping<CustomerInfoModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerInfoMapping"/> class.
        /// </summary>
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
