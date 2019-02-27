namespace WebApplicationServer.Models
{

    /// <summary>
    /// Entity CustomerInfo
    /// </summary>
    public class CustomerInfo
    {
        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>
        /// The person identifier.
        /// </value>
        public int PersonId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the current role.
        /// </summary>
        /// <value>
        /// The current role.
        /// </value>
        public string CurrentRole { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the industry.
        /// </summary>
        /// <value>
        /// The industry.
        /// </value>
        public string Industry { get; set; }
        /// <summary>
        /// Gets or sets the number of recommendations.
        /// </summary>
        /// <value>
        /// The number of recommendations.
        /// </value>
        public int NumberOfRecommendations { get; set; }
        /// <summary>
        /// Gets or sets the number of connections.
        /// </summary>
        /// <value>
        /// The number of connections.
        /// </value>
        public int NumberOfConnections { get; set; }
    }
}
