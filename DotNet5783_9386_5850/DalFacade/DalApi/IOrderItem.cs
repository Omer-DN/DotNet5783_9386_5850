using DO;

namespace DalApi
{
    public interface IOrderItem : ICrud<OrderItem>
    {
        //methods for OrderItem only:
        public OrderItem Create(int ProductID, int OrderID, double Price, int Amount)
        {
            OrderItem newOrderItem = new OrderItem();
            newOrderItem.ProductID = ProductID;
            newOrderItem.OrderID = OrderID;
            newOrderItem.Price = Price;
            newOrderItem.Amount = Amount;
            return newOrderItem;
        }
    }
}
