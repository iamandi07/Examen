using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Equipment
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string EquipementType { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTime CalibrationDate { get; set; }
    }
}
