
using static BO.Enums;

namespace BO
{
    public class TrackingSteps
    {
        public DateTime Time { get; set; }
        public OrderStatus Status  { get; set; }
        public override string ToString()
        {
            return
            $@"
            Date - {Time} 
            Status - {Status}";
        }
    }
}
