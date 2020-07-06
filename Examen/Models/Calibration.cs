using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class Calibration
    {
        public long EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
