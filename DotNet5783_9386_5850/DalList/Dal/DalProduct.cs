

using DO;

using static DO.Enums;

using static Dal.DataSource;

namespace Dal;

public class DalProduct
{
    public Product Create(string name, double price, Category category, int instock)
    {
        Product newProduct = new Product();
        newProduct.Name = name;
        newProduct.Price = price;
        newProduct.Category = category;
        newProduct.InStock = instock;
        return newProduct;
    }

    public int AddProduct(Product product)
    {
        for (int i = 0; i < Config.numOfProducts; i++)
            if (arrayOfProducts[i].ID == product.ID)
                throw new Exception("This product already exists in the system");
        product.ID = DataSource.Config.getlastProductId();
        DataSource.arrayOfProducts[DataSource.Config.numOfProducts++] = product;
        return product.ID;
    }

    public void Deleteproduct(int id)
    {
        for(int i=0;i<Config.numOfProducts;i++)
        {
            if (arrayOfProducts[i].ID == id)
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

    public void UpdateProduct(Product product)
    {
        for (int i = 0; i < Config.numOfProducts; i++)
            if (arrayOfProducts[i].ID == product.ID)
                arrayOfProducts[i] = product;            
            throw new Exception("This product does not exist in the system");
        
    }

    public Product GetProduct(int id)
    {
        for (int i = 0; i < Config.numOfProducts;i++)
            if (arrayOfProducts[i].ID==id)
                return arrayOfProducts[i];
        throw new Exception("This product does not exist in the system");

    }

    // return a List of current products in the store
    public Product[] GetProductList()
    {
        Product[] products = new Product[Config.numOfProducts];
        for (int i = 0; i < Config.numOfProducts; i++)
        {
            products[i] = arrayOfProducts[i];
        }
        return products;
    }
}



