using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;
using static DO.Enums;

namespace BO
{
    public class TrackingSteps
    {
        public DateTime? Time { get; set; }
        public OrderStatus Status  { get; set; }
        public override string ToString()
        {
            return
            $@"
            Date - {Time} | Status - {Status}";
        }
    }
}
