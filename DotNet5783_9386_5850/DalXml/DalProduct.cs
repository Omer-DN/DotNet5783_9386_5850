using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
using static Dal.XmlDataSource;


internal class DalProduct : IProduct
{
    public int Add(Product product)
    {
        List<Product> listOfProducts = loadListOfProduct();
        if (!(listOfProducts == null))
            foreach (Product i in listOfProducts)
            {
                if (i.ID == product.ID)
                    throw new IdAlreadyExist("This product already exists in the system");
            }
        listOfProducts?.Add(product);
        saveListOfProducts(listOfProducts);
        return product.ID;
    }

    public void Delete(int id)

    {
        List<Product> listOfProducts = loadListOfProduct();
        foreach (Product i in listOfProducts)
        {
            if (i.ID == id)
            {
                listOfProducts.Remove(i);
                return;
            }
        }
        throw new IdNotFound("This product does not exist in the system");
        saveListOfProducts(listOfProducts);
    }

    public void Update(Product product)
    {
        List<Product> listOfProducts = loadListOfProduct();
        if (listOfProducts.Exists(x => x.ID == product.ID))
        {
            var index = listOfProducts.FindIndex(i => i.ID == product.ID);
            listOfProducts[index] = product;
            return;
        }
        throw new Exception("This product does not exist in the system");
        saveListOfProducts(listOfProducts);

    }

    public Product Get(int id)
    {
        List<Product> listOfProducts = loadListOfProduct();
        foreach (Product i in listOfProducts)
            if (i.ID == id)
                return i;
        throw new Exception("This product does not exist in the system");
    }

    public Product GetCond(int id, Func<Product, bool>? condition)
    {
        List<Product> listOfProducts = loadListOfProduct();
        var product = (from i in listOfProducts
                       let match = i.ID == id && condition!(i)
                       where match
                       select i).FirstOrDefault();
        if (product.ID == null)
            throw new Exception("This product does not exist in the system");
        else
            return product;
    }
    //{
    //    foreach (Product i in listOfProducts)
    //        if (i.ID == id && condition!(i))
    //            return i;
    //    throw new Exception("This product does not exist in the system");
    //}

    // return a List of current products in the store
    public IEnumerable<Product> GetList(Func<Product, bool>? condition)
    {
        List<Product> listOfProducts = loadListOfProduct();
        return (condition == null) ?
        listOfProducts.ToList() :
        listOfProducts.Where(x => condition(x)).ToList();
    }
    //{    
    //    List<Product> products = new List<Product>();
    //    if (condition == null) 
    //    {
    //        foreach (Product i in listOfProducts)
    //            products.Add(i);
    //    }
    //    else
    //        products = listOfProducts.FindAll(x => condition(x));

    //   return products;
    //}

}
