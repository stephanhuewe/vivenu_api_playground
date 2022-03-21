using System.Collections.Generic;

namespace Vivenu_API_Test.Model
{
    internal class Customer
    {
        public string name { get; set; }
        public string prename { get; set; }
        public string lastname { get; set; }
        public string image { get; set; }
        public string primaryEmail { get; set; }
        public Location location { get; set; }
        public string notes { get; set; }
        public ExtraFields extraFields { get; set; }
        public List<string> dataFields { get; set; }
        public List<string> tags { get; set; }
        public string accountId { get; set; }
    }

    public class Location
    {
        public string street { get; set; }
        public string postal { get; set; }
        public string city { get; set; }
        public string locale { get; set; }
        public string state { get; set; }
        public List<double> center { get; set; }
        public string country { get; set; }
    }

    public class ExtraFields
    {
    }
}
