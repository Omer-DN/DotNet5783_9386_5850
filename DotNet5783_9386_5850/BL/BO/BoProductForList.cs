
using static BO.Enums;

namespace BO
{
    public class BoProductForList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category category { get; set; }
        public override string ToString()
        {
            return
            $@"
            ID = {ID}: {ID} 
            Name: {Name} 
            Price: {Price}
            Category: {category}";
        }

    }
}
