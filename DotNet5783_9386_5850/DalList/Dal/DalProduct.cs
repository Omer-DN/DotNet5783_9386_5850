

using DO;
using System.ComponentModel;
using static DO.Enums;
using System.Diagnostics;
using System.Xml.Linq;

namespace Dal;

public class DalProduct
{
    public static Product Create(int id, string name, double price, Category category, int instock)
    {
        Product newProduct = new Product();
        newProduct.ID = id;
        newProduct.Name = name;
        newProduct.Price = price;
        newProduct.Category = category;
        newProduct.InStock = instock;
        return newProduct;
    }
}
