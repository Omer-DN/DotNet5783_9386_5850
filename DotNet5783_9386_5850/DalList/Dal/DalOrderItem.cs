
using DO;
using System.Diagnostics;

namespace Dal;

public class DalOrderItem
{
    public static OrderItem Create(int ProductID, int OrderID, double Price, int Amount)
    {
        OrderItem newOrderItem = new OrderItem();
        newOrderItem.ProductID = ProductID;
        newOrderItem.OrderID = OrderID;
        newOrderItem.Price = Price;
        newOrderItem.Amount = Amount;
        return newOrderItem;
    }
}
