

using DO;
using static DalList.DataSource;
using DalApi;
using System.Reflection.Metadata;

namespace Dal;

public class DalProduct:IProduct
{
    public int Add(Product product)
    {
        if (listOfProducts != null)
        {
            if (listOfProducts.Any(i => i.ID == product.ID))
            {
                throw new IdAlreadyExist("This product already exists in the system");
            }
        }
        //if(!(listOfProducts== null))
        //    foreach (Product i in listOfProducts)
        //    {
        //       if (i.ID == product.ID)
        //            throw new IdAlreadyExist("This product already exists in the system");
        //    }
        listOfProducts.Add(product);
        return product.ID;
    }

    public void Delete(int id)

    {
        if (!listOfProducts.Any(i => i.ID == id))
            throw new IdNotFound("This product does not exist in the system");
        listOfProducts.RemoveAll(i => i.ID == id);

        //foreach (Product i in listOfProducts)
        //{
        //    if (i.ID == id)
        //    {
        //        listOfProducts.Remove(i);
        //        return;
        //    }
        //}
        //throw new IdNotFound("This product does not exist in the system");
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
    //{
    //    var find_product = listOfProducts.FirstOrDefault(i => i.ID == id);
    //    if (find_product == null)
    //        throw new Exception("This product does not exist in the system");
    //    else
    //        return find_product;
    //}
    {
        foreach (Product i in listOfProducts)
            if (i.ID == id)
                return i;
        throw new Exception("This product does not exist in the system");
    }

    public Product GetCond(int id, Func<Product, bool>? condition)

    {
        try
        {
            return listOfProducts.First(i => i.ID == id && condition!(i));
        }
        catch (InvalidOperationException)
        {
            throw new Exception("This product does not exist in the system");
        }
    }
    //{
    //    foreach (Product i in listOfProducts)
    //        if (i.ID == id && condition!(i))
    //            return i;
    //    throw new Exception("This product does not exist in the system");
    //}

    // return a List of current products in the store
    public IEnumerable<Product> GetList(Func<Product, bool>? condition )

    {
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