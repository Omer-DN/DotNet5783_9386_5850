using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static DO.Enums;

namespace Dal
{
    /// <summary>
    /// Data Source class that works with Xml Files
    /// </summary>
    internal class XmlDataSource
    {
        //Static fileds that show the files names and Paths
        internal static string fileNameListOfProducts = "../xml/List_Of_Products.xml";
        internal static string fileNameListOfOrders = "../xml/List_Of_Orders.xml";
        internal static string fileNameListOfOrderItems = "../xml/List_Of_OrderItems.xml";
        internal static string fileNameConfig = "../xml/Config.xml";
        internal static XElement ProductRoot = new XElement("Products");



        readonly Random rand = new Random();

        //Method to load the config class from the file
        static public Config loadConfig()
        {
            if (!File.Exists(fileNameConfig))
            {
                saveConfig(new Config());
            }
            Config config;
            XmlSerializer x = new XmlSerializer(typeof(Config));
            FileStream fs = new FileStream(fileNameConfig, FileMode.Open);
            config = (Config)x.Deserialize(fs)!;
            fs.Close();
            return config;

        }

        //Method to save the config class to the file
        static public void saveConfig(Config config)
        {
            XmlSerializer x = new XmlSerializer(config.GetType());
            FileStream fs = new FileStream(fileNameConfig, FileMode.Create);
            x.Serialize(fs, config);
            fs.Close();
        }


        //Methods to get the last ID that used to create new Product/Order/OrderItem and add 1 to it
        static public int getlastProductId()
        {
            Config config = loadConfig();
            int output = config.lastProductId++;
            saveConfig(config);
            return output;
        }
        static public int getlastOrderId()
        {
            Config config = loadConfig();
            int output = config.lastOrderId++;
            saveConfig(config);
            return output;
        }
        static public int getlastOrderItemId()
        {
            Config config = loadConfig();
            int output = config.lastOrderItemId++;
            saveConfig(config);
            return output;
        }

        //in Product we Using LinqToXml:

        //Method to load and return the list of products on the store from the file
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
                    }).ToList();
            return list;
        }

        //load the data from file
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
        //create new file
        private static void CreateFiles()
        {
            ProductRoot = new XElement("Products");
            ProductRoot.Save(fileNameListOfProducts);
        }
        //Method to check if file exist, if not - create new, if yes - load from it
        public static void LoadXmlFile()
        {
            if (!File.Exists(fileNameListOfProducts))
                CreateFiles();
            else
                LoadData();
        }


        //in Order And OrdeItem we use Xml Serialize:

        //Method to load and return the list of Orders on the store from the file
        static internal List<Order> loadListOfOrders()
        {
            if (!File.Exists(fileNameListOfOrders))
            {
                saveListOfOrders(new List<Order>());
            }
            List<Order> list;
            XmlSerializer x = new XmlSerializer(typeof(List<Order>));
            FileStream fs = new FileStream(fileNameListOfOrders, FileMode.Open);
            list = (List<Order>)x.Deserialize(fs)!;
            fs.Close();
            return list;
        }

        //Method to save list of orders to the file
        static internal void saveListOfOrders(List<Order> list)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(fileNameListOfOrders, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }

        //Method to load and return the list of Order Items on the store from the file
        static internal List<OrderItem> loadListOfOrderItems()
        {
            if (!File.Exists(fileNameListOfOrderItems))
            {
                saveListOfOrderItems(new List<OrderItem>());
            }
            List<OrderItem> list;
            XmlSerializer x = new XmlSerializer(typeof(List<OrderItem>));
            FileStream fs = new FileStream(fileNameListOfOrderItems, FileMode.Open);
            list = (List<OrderItem>)x.Deserialize(fs)!;
            fs.Close();
            return list;
        }

        //Method to save list of order items to the file
        static internal void saveListOfOrderItems(List<OrderItem> list)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(fileNameListOfOrderItems, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }









    }
}
