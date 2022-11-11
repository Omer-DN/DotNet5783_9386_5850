

using DO;

using static DO.Enums;

using static Dal.DataSource;

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

    public static int AddProduct(Product product)
    {
        for (int i = 0; i < Config.numOfProducts; i++)
            if (arrayOfProducts[i].ID == product.ID)
                throw new Exception("This product already exists in the system");
        DataSource.arrayOfProducts[DataSource.Config.numOfProducts++] = product;
        return product.ID;
    }

    public static void Deleteproduct(Product product)
    {
        for(int i=0;i<Config.numOfProducts;i++)
        {
            if (arrayOfProducts[i].ID == product.ID)
            {
                
                for (int j=i ; j < Config.numOfProducts-1;j++)
                {
                    arrayOfProducts[j] = arrayOfProducts[j + 1];
                }
                Config.numOfProducts--;
                return;
            }
        }
        throw new Exception("This product does not exist in the system");
    }

    public static void UpdateProduct(Product product)
    {
        for (int i = 0; i < Config.numOfProducts; i++)
            if (arrayOfProducts[i].ID == product.ID)
                arrayOfProducts[i] = product;            
            throw new Exception("This product does not exist in the system");
        
    }

    public static Product GetProduct(int id)
    {
        for (int i = 0; i < Config.numOfProducts;i++)
            if (arrayOfProducts[i].ID==id)
                return arrayOfProducts[i];
        throw new Exception("This product does not exist in the system");

    }

    // return a List of current products in the store
    public static Product[] GetProductList()
    {
        Product[] products = new Product[Config.numOfProducts];
        for (int i = 0; i < Config.numOfProducts; i++)
        {
            products[i] = arrayOfProducts[i];
        }
        return products;
    }
}


