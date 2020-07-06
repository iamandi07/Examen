using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<InspectionPlan> InspectionPlans { get; set; } = new List<InspectionPlan>();
    }
}
