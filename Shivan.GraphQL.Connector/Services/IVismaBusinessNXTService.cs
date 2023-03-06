using Shivan.GraphQL.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shivan.GraphQL.Connector.Models.Association;

namespace Shivan.GraphQL.Connector.Services
{
    public interface IVismaBusinessNXTService
    {
        Task<Root> GetNextBasicInfo(string base_url, string token, string query);
        Task<AssociateObject> PostVBNxt(string base_url, string token, string query);
    }
}
