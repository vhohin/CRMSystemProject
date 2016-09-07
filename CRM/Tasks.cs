using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Tasks
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string NameTask { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InformationNotes { get; set; }
        public string Status { get; set; }
        public string TaskType { get; set; }
        public string Priority { get; set; }
        public string Reminder { get; set; }
        public int ClientId { get; set; }
     

    }
}
