
using static BO.Enums;

namespace BO
{
    /// <summary>
    /// TrackingSteps helper entity - 
    /// for order mode
    /// </summary>
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
