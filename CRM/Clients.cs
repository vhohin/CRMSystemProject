using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Clients
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool Commercial { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebPage { get; set; }
        public DateTime FirstContacted { get; set; }
    }
}
