using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal
{
    internal class XmlDataSource
    {
        //internal static List<Order> listOfOrders = new List<Order>(100);
        //internal static List<OrderItem> listOfOrderItems = new List<OrderItem>(200);
        internal static string fileNameListOfProducts = "../xml/List_Of_Products.xml";
        internal static string fileNameListOfOrders = "../xml/List_Of_Orders.xml";
        internal static string fileNameListOfOrderItems = "../xml/List_Of_OrderItems.xml";
        internal static XElement ProductRoot = new XElement("Products");



        readonly Random rand = new Random();

        static internal int lastProductId = 100000;
        static internal int lastOrderId = 100000;
        static internal int lastOrderItemId = 100000;
        internal static int numOfOrderItems;

        static internal int getlastProductId()
        {
            return lastProductId++;
        }
        static internal int getlastOrderId()
        {
            return lastOrderId++;
        }
        static internal int getlastOrderItemId()
        {
            return lastOrderItemId++;
        }

        //in Product we Using LinqToXml:
        static internal IEnumerable<Product> loadListOfProduct()
        {
            LoadXmlFile();
            IEnumerable<Product> list;
            list = (from p in ProductRoot.Elements()
                    select new Product()
                    {
                        ID = int.Parse(p.Element("ID")!.Value),
                        Name = p.Element("Name")!.Value,
                        Price = double.Parse(p.Element("Price")!.Value),
                        Category = (Enums.Category)Enum.Parse(typeof(Enums.Category), p.Element("Category")!.Value, true),
                        InStock = int.Parse(p.Element("InStock")!.Value)

                        /*XmlSerializer x = new XmlSerializer(typeof(List<Product>));
                        FileStream fs = new FileStream(fileNameListOfProducts, FileMode.Open);
                        list = (List<Product>)x.Deserialize(fs);
                        fs.Close();
                        return list;*/
                    }).ToList();
            return list;
        }


        static internal void LoadData()
        {
            try
            {
                ProductRoot = XElement.Load(fileNameListOfProducts);
            }
            catch
            {
                throw new Exception("File Upload Problem");
            }
        }

        private static void CreateFiles()
        {
            ProductRoot = new XElement("Products");
            ProductRoot.Save(fileNameListOfProducts);
        }

        public static void LoadXmlFile()
        {
            if (!File.Exists(fileNameListOfProducts))
                CreateFiles();
            else
                LoadData();
        }

        /*static internal void saveListOfProducts(List<Product> list)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(fileNameListOfProducts, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close(); 
        }*/


        //in Order And OrdeItem we use Xml Serialize:
        static internal List<Order> loadListOfOrders()
        {
            if (!File.Exists(fileNameListOfOrders))
            {
                saveListOfOrders(new List<Order>());
            }
            List<Order> list;
            XmlSerializer x = new XmlSerializer(typeof(List<Order>));
            FileStream fs = new FileStream(fileNameListOfOrders, FileMode.Open);
            list = (List<Order>)x.Deserialize(fs);
            fs.Close();
            return list;
        }
        static internal void saveListOfOrders(List<Order> list)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(fileNameListOfOrders, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }

        static internal List<OrderItem> loadListOfOrderItems()
        {
            if (!File.Exists(fileNameListOfOrderItems))
            {
                saveListOfOrderItems(new List<OrderItem>());
            }
            List<OrderItem> list;
            XmlSerializer x = new XmlSerializer(typeof(List<OrderItem>));
            FileStream fs = new FileStream(fileNameListOfOrderItems, FileMode.Open);
            list = (List<OrderItem>)x.Deserialize(fs);
            fs.Close();
            return list;
        }
        static internal void saveListOfOrderItems(List<OrderItem> list)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(fileNameListOfOrderItems, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }









    }
}
