

using DO;
using static DalList.DataSource;
using DalApi;
using System.Reflection.Metadata;

namespace DalList;

public class DalProduct:IProduct
{
    public int Add(Product product)
    {
        if(!(listOfProducts== null))
            foreach (Product i in listOfProducts)
            {
               if (i.ID == product.ID)
                    throw new IdAlreadyExist("This product already exists in the system");
            }
        //product.ID = DataSource.getlastProductId(); //stage 1
        listOfProducts.Add(product);
        return product.ID;
    }

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

    public Product Get(int id)
    {
        foreach (Product i in listOfProducts)
            if (i.ID == id)
                return i;
        throw new Exception("This product does not exist in the system");
    }

    // return a List of current products in the store
    public IEnumerable<Product> GetList(Func<Product, bool>? condition )
    {    
        List<Product> products = new List<Product>();
        if (condition == null) 
        {
            foreach (Product i in listOfProducts)
                products.Add(i);
        }
        else
            products = listOfProducts.FindAll(x => condition(x));
           
       return products;
    }

    public Product GetCond(int id, Func<Product, bool>? condition)
    {
        foreach (Product i in listOfProducts)
            if (i.ID == id && condition(i))
                return i;
        throw new Exception("This product does not exist in the system");
    }
}