using static BO.Enums;

namespace BO
{
    public class BoProductItem
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category category { get; set; }
        public int Amount { get; set; }
        public bool InStock { get; set; }
        public override string ToString()
        {
            return
            $@"
            ID = {ID}
            Name: {Name}
            Price: {Price}
            category - {category} 
            Amount in stock: {Amount}
            InStock: {InStock}";
        }


    }
}
