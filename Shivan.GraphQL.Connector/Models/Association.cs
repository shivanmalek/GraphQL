using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shivan.GraphQL.Connector.Models.Association
{
    public class AssociateObject
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
    }

    public class Data
    {
        public UseCompany useCompany { get; set; }
    }

    public class UseCompany
    {
        public AssociateUpdate associate_update { get; set; }
    }

    public class AssociateUpdate
    {
        public int affectedRows { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
    }
    public class Extensions
    {
        public string vbnxt_trace_id { get; set; }
    }

}