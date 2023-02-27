

using DO;
using static DalList.DataSource;
using DalApi;
using System.Reflection.Metadata;

namespace Dal;

/// <summary>
/// Implementation of the ICRUD methods for the Product entitie
/// </summary>
public class DalProduct:IProduct
{
    //Method to add product from the Store data
    public int Add(Product product)
    {
        if (!(listOfProducts == null))
            foreach (Product i in listOfProducts)// check if the id is already exist in store
            {
                if (i.ID == product.ID)
                    throw new IdAlreadyExist("This product already exists in the system");
            }
        listOfProducts?.Add(product);
        return product.ID;
    }
    //Method to delete product from the Store data
    public void Delete(int id)

    {

        foreach (Product i in listOfProducts)
        {
            if (i.ID == id)
            {
                listOfProducts.Remove(i);
                return;
            }
        }
        throw new IdNotFound("This product does not exist in the system");
    }

    //Method to update product from the Store data
    public void Update(Product product)
    {
        if (listOfProducts.Exists(x => x.ID == product.ID))
        {
            var index = listOfProducts.FindIndex(i => i.ID == product.ID);
            listOfProducts[index] = product;
            return;
        }
        throw new Exception("This product does not exist in the system");
    }

    //Method to get product from the Store data
    public Product Get(int id)
    {
        foreach (Product i in listOfProducts)
            if (i.ID == id)
                return i;
        throw new Exception("This product does not exist in the system");
    }

    //Method to get product from the Store data that hold specific condition 
    public Product GetCond(int id, Func<Product, bool>? condition)
    {
        var product = (from i in listOfProducts
                       let match = i.ID == id && condition!(i)
                       where match
                       select i).FirstOrDefault();
        if (product.ID == null)
            throw new Exception("This product does not exist in the system");
        else
            return product;
    }

    //Method to get product list from the Store data that hold specific condition 
    public IEnumerable<Product> GetList(Func<Product, bool>? condition )

    {
        return (condition == null) ?
        listOfProducts.ToList() :
        listOfProducts.Where(x => condition(x)).ToList();
    }
}