
using static BO.Enums;

namespace BO
{
    /// <summary>
    /// OrderTracking helper entity - 
    /// for order tracking screen
    /// </summary>
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
