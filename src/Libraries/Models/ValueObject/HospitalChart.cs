using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ValueObject
{
    public class HospitalChart
    {
        public string Hospital { get; set; }
        public int Count { get; set; }
        public long TotalCapacity { get; set; }
    }
}
