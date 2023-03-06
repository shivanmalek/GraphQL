using Shivan.GraphQL.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shivan.GraphQL.Connector.Services
{
    public interface IVismaBusinessNXTService
    {
        Task<Root> GetNextBasicInfo(string base_url, string token, string query);
        Task<Models.Association.AssociateObject> PostVBNxt(string base_url, string token, string query);
    }
}
