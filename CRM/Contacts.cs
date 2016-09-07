using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Contacts
    {
        public int ContactId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public string ContactType { get; set; }
        public string Location { get; set; }
        public DateTime ContactDate { get; set; }       
        public string Subject { get; set; }
        public string Outcome { get; set; }
        public string ActionsToDo { get; set; }       

    }
}
