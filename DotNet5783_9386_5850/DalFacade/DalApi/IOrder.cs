using DO;

namespace DalApi
{
    public interface IOrder : ICrud<Order>
    {
        //methods for Order only:
        public Order Create(string costumerName, string costumerEmail, string costumerAdress, DateTime OrderDate, DateTime ShipDate, DateTime DeliveryDate)
        {
            Order newOrder = new Order();
            newOrder.CostumerName = costumerName;
            newOrder.CostumerEmail = costumerEmail;
            newOrder.CostumerAdress = costumerAdress;
            newOrder.OrderDate = OrderDate;
            newOrder.ShipDate = ShipDate;
            newOrder.DeliveryDate = DeliveryDate;
            return newOrder;
        }
    }
}
