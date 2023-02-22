
namespace BO
{
    /// <summary>
    /// Auxiliary entity of an item in an order (represents a line in an order) OrderItem - 
    /// for a list of items in the shopping basket screen and in the order details screen
    /// </summary>
    public class BoOrderItem
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return
            $@"
            ID = {ID}
            Name: {Name}
            Product ID = {ProductID} 
            Price: {Price}
            Amount: {Amount}
            Total Price: {TotalPrice}";
        }
    }
}
