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

/// <summary>
/// /// Implementation of the ICRUD methods for the Product entitie USING XML FILES - LinqToXml
/// </summary>
internal class DalProduct : IProduct
{
    //Method to add product from the Store data
    public int Add(Product product)
    {
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

    //Method to delete product from the Store data
    public void Delete(int id)
    {
        LoadXmlFile();
        XElement? productElement;
        productElement = (from p in ProductRoot.Elements()
                          where Convert.ToInt32(p.Element("ID")!.Value) == id
                          select p).FirstOrDefault();
        productElement!.Remove();
        ProductRoot.Save(fileNameListOfProducts);


    }

    //Method to update product from the Store data
    public void Update(Product product)
    {
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

    //Method to get product from the Store data
    public Product Get(int id)
    {
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

    //Method to get product from the Store data that hold specific condition 
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

    //Method to get product list from the Store data that hold specific condition 
    public IEnumerable<Product> GetList(Func<Product, bool>? condition)
    {
        LoadXmlFile();
        IEnumerable<Product> listOfProducts = loadListOfProduct();
        return (condition == null) ?
        listOfProducts.ToList() :
        listOfProducts.Where(x => condition(x)).ToList();
    }
}
