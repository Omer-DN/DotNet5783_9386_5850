using static BO.Enums;

namespace BO
{
    /// <summary>
    /// Auxiliary entity of a product item (which represents a product for the catalog) ProductItem - 
    /// for the catalog screen - with the list of products that are shown to the buyer
    /// </summary>
    public class BoProductItem
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public bool InStock { get; set; }
        public override string ToString()
        {
            return
            $@"
            ID = {ID}
            Name: {Name}
            Price: {Price}
            category - {Category} 
            Amount in Cart: {Amount}
            InStock: {InStock}";
        }


    }
}
