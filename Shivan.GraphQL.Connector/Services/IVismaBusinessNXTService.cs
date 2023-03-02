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
        Task<Root> GetGithubUser(string base_url, string token, string query);
    }
}
