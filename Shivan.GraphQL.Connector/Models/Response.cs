using Newtonsoft.Json;

namespace Shivan.GraphQL.Connector.Models
{
    public class AvailableCompanies
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
    }    
    
    public class AvailableCustomers
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
    }     
    
    public class Data
    {
        public AvailableCustomers availableCustomers { get; set; }
        public AvailableCompanies availableCompanies { get; set; }
    }     
    
    public class Extensions
    {
        [JsonProperty("vbnxt-trace-id")]
        public string vbnxttraceid { get; set; }
    }     
    
    public class Item
    {
        public string name { get; set; }
        public int vismaNetCustomerId { get; set; }
        public int vismaNetCompanyId { get; set; }
    }     
    
    public class Root
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
    }
}
