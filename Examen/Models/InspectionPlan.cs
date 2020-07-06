using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class InspectionPlan
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
