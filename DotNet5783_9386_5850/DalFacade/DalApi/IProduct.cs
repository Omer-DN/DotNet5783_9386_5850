using DO;

using static DO.Enums;

namespace DalApi;
/// <summary>
/// Class that make methods that Special only for the Product entitie
/// </summary>
public interface IProduct : ICrud<Product>
{
    //methods for Product only:
    public Product Create(string name, double price, Category category, int instock)
    {
        Product newProduct = new ();
        newProduct.Name = name;
        newProduct.Price = price;
        newProduct.Category = category;
        newProduct.InStock = instock;
        return newProduct;
    }
}

