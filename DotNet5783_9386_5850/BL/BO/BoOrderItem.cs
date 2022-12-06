
namespace BO
{
    public class BoOrderItem
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public static int lastID = 100000;

        public override string ToString()
        {
            return
            $@"
            ID = {ID}
            Name: {Name}
            Product ID = {ID} 
            Price: {Price}
            Amount: {Amount}
            Total Price: {TotalPrice}";
        }
    }
}
