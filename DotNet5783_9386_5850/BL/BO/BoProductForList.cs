
using static BO.Enums;

namespace BO
{
    /// <summary>
    /// Helper entity of a product in the list ProductForList - 
    /// for the product list screen and catalog screen
    /// </summary>
    public class BoProductForList
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category? Category { get; set; }
        public override string ToString()
        {
            return
            $@"
            ID : {ID} 
            Name: {Name} 
            Price: {Price}
            Category: {Category}";
        }

    }
}
