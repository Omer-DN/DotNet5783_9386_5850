using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
