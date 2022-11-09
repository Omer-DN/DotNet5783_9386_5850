

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
        foreach (Product i in DataSource.arrayOfproducts)
        {
            if (product.ID == i.ID)
                throw new Exception("This product already exists in the system");
        }
        DataSource.arrayOfproducts[DataSource.Config.numOfProducts++] = product;
        return product.ID;
    }

    public static void Deleteproduct(Product product)
    {
        for(int i=0;i<Config.numOfProducts;i++)
        {
            if (arrayOfproducts[i].ID == product.ID)
            {
                
                for (int j=i ; j < Config.numOfProducts-1;j++)
                {
                    arrayOfproducts[j] = arrayOfproducts[j + 1];
                }
                Config.numOfProducts--;
                return;
            }
        }
        throw new Exception("This product does not exist in the system");
    }

    public static void UpdateProduct(Product product)
    {
        foreach (Product i in arrayOfproducts)
        {
            if (i.ID == product.ID)
            {
                i.Name.Concat(product.Name);
            }
            throw new Exception("This product does not exist in the system");
        }
    }

    public static Product getProduct(int ID)
    {
        foreach (Product i in arrayOfproducts)
            if (i.ID == ID)
                return i;
    }
}


