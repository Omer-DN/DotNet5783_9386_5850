using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
using System.Xml.Linq;
using static Dal.XmlDataSource;


internal class DalProduct : IProduct
{
    public int Add(Product product)
    {
        /*List<Product> listOfProducts = loadListOfProduct();
        if (!(listOfProducts == null))
            foreach (Product i in listOfProducts)
            {
                if (i.ID == product.ID)
                    throw new IdAlreadyExist("This product already exists in the system");
            }
        listOfProducts?.Add(product);
        saveListOfProducts(listOfProducts);
        return product.ID;*/
        LoadXmlFile();
        XElement ID = new XElement("ID", product.ID);
        XElement Name = new XElement("Name", product.Name);
        XElement Price = new XElement("Price", product.Price);
        XElement Category = new XElement("Category", product.Category);
        XElement InStock = new XElement("InStock", product.InStock);
        ProductRoot.Add(new XElement("student", ID, Name, Price, Category,InStock));
        ProductRoot.Save(fileNameListOfProducts);
        return product.ID;
    }

    public void Delete(int id)

    {
        /* List<Product> listOfProducts = loadListOfProduct();
         foreach (Product i in listOfProducts)
         {
             if (i.ID == id)
             {
                 listOfProducts.Remove(i);
                 return;
             }
         }
         throw new IdNotFound("This product does not exist in the system");
         saveListOfProducts(listOfProducts);*/
        LoadXmlFile();
        XElement? productElement;
        productElement = (from p in ProductRoot.Elements()
                          where Convert.ToInt32(p.Element("ID").Value) == id
                          select p).FirstOrDefault();
        productElement!.Remove();
        ProductRoot.Save(fileNameListOfProducts);


    }

    public void Update(Product product)
    {
        /*List<Product> listOfProducts = loadListOfProduct();
        if (listOfProducts.Exists(x => x.ID == product.ID))
        {
            var index = listOfProducts.FindIndex(i => i.ID == product.ID);
            listOfProducts[index] = product;
            return;
        }
        throw new Exception("This product does not exist in the system");
        saveListOfProducts(listOfProducts);*/
        LoadXmlFile();
        XElement? productElement = (from p in ProductRoot.Elements()
                                   where Convert.ToInt32(p.Element("ID")!.Value) == product.ID
                                   select p).FirstOrDefault();
        productElement!.Element("ID")!.Value = product.ID.ToString();
        productElement.Element("Name")!.Value = product.Name!;
        productElement.Element("Price")!.Value = product.Price.ToString();
        productElement.Element("Category")!.Value = product.Category.ToString();
        productElement.Element("InStock")!.Value = product.InStock.ToString();
        ProductRoot.Save(fileNameListOfProducts);

    }

    public Product Get(int id)
    {
        /*List<Product> listOfProducts = loadListOfProduct();
        foreach (Product i in listOfProducts)
            if (i.ID == id)
                return i;
        throw new Exception("This product does not exist in the system");*/

        LoadXmlFile();
        Product product;
        product = (from p in ProductRoot.Elements()
                   where int.Parse(p.Element("ID")!.Value) == id
                   select new Product()
                   {
                       ID = int.Parse(p.Element("ID")!.Value),
                       Name = p.Element("Name")!.Value,
                       Price = double.Parse(p.Element("Price")!.Value),
                       Category = (Enums.Category)Enum.Parse(typeof(Enums.Category), p.Element("Category")!.Value, true),
                       InStock = int.Parse(p.Element("InStock")!.Value)
                   }).FirstOrDefault();
        return product;

    }

    public Product GetCond(int id, Func<Product, bool>? condition)
    {
        LoadXmlFile();
        IEnumerable<Product> listOfProducts = loadListOfProduct();
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
        LoadXmlFile();
        IEnumerable<Product> listOfProducts = loadListOfProduct();
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
