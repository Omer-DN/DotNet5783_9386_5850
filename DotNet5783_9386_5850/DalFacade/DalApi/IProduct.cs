using DO;

using static DO.Enums;

namespace DalApi;
public interface IProduct : ICrud<Product>
{
    //methods for Product only:
    public Product Create(string name, double price, Category category, int instock)
    {
        Product newProduct = new Product();
        newProduct.Name = name;
        newProduct.Price = price;
        newProduct.Category = category;
        newProduct.InStock = instock;
        return newProduct;
    }
}

