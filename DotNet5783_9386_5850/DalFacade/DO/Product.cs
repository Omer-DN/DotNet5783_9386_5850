
using System.Diagnostics;
using System.Xml.Linq;

namespace DO;

public struct Product
{
    public int Id { get; set; }
    public override string ToString()
    {
        return
        $@"Product ID = {ID}: {Name} 
        category - {Category} 
        Price: {Price}
        Amount in stock: {InStock}";
    }
}