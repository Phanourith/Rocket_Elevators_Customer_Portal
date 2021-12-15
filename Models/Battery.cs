using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocketElevatorsCustomerPortal.Models
{
    public class Battery
    {
        public int id { get; set; }
        public int building_id { get; set; }
        public string battery_type { get; set; }
        public string status { get; set; }
        public int employee_id { get; set; }
        public string Date_of_ { get; set; }
        public DateTime date_of_last_inspection { get; set; }
        public string certificate_of_operations { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime date_of_commissioning { get; set; }
    }
}
