using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BO.Enums;
using static DO.Enums;

namespace BO
{
    public class BoOrderTracking
    {
        public int ID { get; set; }
        public OrderStatus Status { get; set; }
        public List<TrackingSteps> trackingSteps { get; set; }
        public override string ToString()
        {
            return
            $@"
            ID = {ID}
            Status - {Status} 
            Tracking Steps: {trackingSteps}";
        }

    }
}
