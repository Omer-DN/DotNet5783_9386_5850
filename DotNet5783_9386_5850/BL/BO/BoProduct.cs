
using static BO.Enums;

namespace BO
{
    /// <summary>
    /// Main logical entity of a product (Product) - 
    /// for screens of product details (for management)
    /// </summary>
    public class BoProduct
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category? Category { get; set; }
        public int InStock { get; set; }

        public override string ToString()
        {
            return
            $@"Product ID = {ID}: {Name} 
            category - {category} 
            Price: {Price}
            Amount in stock: {InStock}";
        }
    }
}
