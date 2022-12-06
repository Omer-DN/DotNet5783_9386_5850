
using static BO.Enums;

namespace BO
{
    /// <summary>
    /// Main logical entity of an order (Order) - 
    /// for an order details screen and actions on an order
    /// </summary>
    public class BoOrder
    {
        public int ID { get; set; }
        public string? CostumerName { get; set; }
        public string? CostumerEmail { get; set; }
        public string? CostumerAdress { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<BoOrderItem>? Items { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString()
        {
            return
            $@" ID = {ID}
            Costumer Name - {CostumerName} 
            Costumer Email - {CostumerEmail}
            Costumer Adress - {CostumerAdress}
            Order Date : {OrderDate}
            Order Status: {Status}
            Payment Date: {PaymentDate}
            Ship Date: {ShipDate}
            Delivery Date: {DeliveryDate}
            Items: {Items}
            Total Price:{TotalPrice}";
        }

    }
}
