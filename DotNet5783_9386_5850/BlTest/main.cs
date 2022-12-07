using DalApi;
using BlApi;
using DO;
using BO;

namespace BlTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlApi.IBl BL = new BlApi.Bl();

            Console.WriteLine("Welcome, Please Choose one choice from the Menu:");
            Console.WriteLine("1 - Check the BoProduct Class");
            Console.WriteLine("2 - Check the BoCart Class");
            Console.WriteLine("3 - Check the BoOrder Class");
            Console.WriteLine("0 - Exit");
            int Choice1, Choice2;
            Choice1 = int.Parse(Console.ReadLine());
            while (Choice1 != 0)
            {
                switch (Choice1)
                {
                    case 1:
                        Console.WriteLine("BoProduct: Please Choose one choice:");
                        Console.WriteLine("1 - Add product to the store");
                        Console.WriteLine("2 - Get the list of products");
                        Console.WriteLine("3 - Get a Product for the manger of the store");
                        Console.WriteLine("4 - Get a Product for the buyer (catalog)");
                        Console.WriteLine("5 - Delete a Product from the store");
                        Console.WriteLine("6 - Update a Product from the store");
                        Console.WriteLine("0 - Exit");
                        Choice2 = int.Parse(Console.ReadLine());
                        while (Choice2 != 0)
                        {
                            switch (Choice2)
                            {
                                case 1:
                                    string name;
                                    double price;
                                    Category category;
                                    int id, instock;
                                    Console.WriteLine("Please enter Product Name:");
                                    name = Console.ReadLine();
                                    Console.WriteLine("Please Enter Product price:");
                                    price = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Please enter Product's category:");
                                    Console.WriteLine("1 - vegetables, 2 - Meat, 3 - Legumes, 4 - DairyProducts, 5 - CleanProducts");
                                    category = (Category)int.Parse(Console.ReadLine());
                                    Console.WriteLine("Please select quantity in stock for the product:");
                                    instock = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        Product newProduct = dal.Product.Create(name, price, category, instock);
                                        id = dal.Product.Add(newProduct);
                                        Console.WriteLine("The product has been successfully added with id: {0}", id);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Please Enter the ID of the product to get:");
                                    id = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        Product product = dal.Product.Get(id);
                                        Console.WriteLine("Product found!");
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, In Stock:{4}",
                                            product.ID, product.Name, product.Price, product.Category, product.InStock);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("The Product list of the store:");
                                    IEnumerable<Product> products = dal.Product.GetList();
                                    foreach (Product product in products)
                                    {
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, In Stock:{4}",
                                            product.ID, product.Name, product.Price, product.Category, product.InStock);
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Please Enter the ID of the product you want to update:");
                                    id = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        Product product = dal.Product.Get(id);
                                        Console.WriteLine("Product found!");
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, In Stock:{4}",
                                            product.ID, product.Name, product.Price, product.Category, product.InStock);
                                        Console.WriteLine("Please Enter the details of the new product to update:");
                                        Console.WriteLine("Please enter Product Name:");
                                        name = Console.ReadLine();
                                        Console.WriteLine("Please Enter Product price:");
                                        price = double.Parse(Console.ReadLine());
                                        Console.WriteLine("Please enter Product's category:");
                                        Console.WriteLine("0 - vegetables, 1 - Meat, 2 - Legumes, 3 - DairyProducts, 4 - CleanProducts");
                                        category = (Category)int.Parse(Console.ReadLine());
                                        Console.WriteLine("Please select quantity in stock for the product:");
                                        instock = int.Parse(Console.ReadLine());
                                        Product NewProduct = dal.Product.Create(name, price, category, instock);
                                        NewProduct.ID = product.ID;
                                        dal.Product.Update(NewProduct);
                                        Console.WriteLine("The product has been successfully updated!");
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("Please Enter the ID of the product you want to delete:");
                                    id = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        dal.Product.Delete(id);
                                        Console.WriteLine("The product has been successfully deleted!");
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Please Enter correct number!");
                                    break;
                            }
                            Console.WriteLine("DalProduct: Please Choose one choice:");
                            Console.WriteLine("1 - Add a Product to the product list of the store");
                            Console.WriteLine("2 - Get a Product from the product list of the store");
                            Console.WriteLine("3 - Get the Product list of the store");
                            Console.WriteLine("4 - Update a Product from the product list of the store");
                            Console.WriteLine("5 - Delete a Product from the product list of the store");
                            Console.WriteLine("0 - Exit");
                            Choice2 = int.Parse(Console.ReadLine());
                        }
                        break;
                    case 2:
                        Console.WriteLine("DalOrder: Please Choose one choice:");
                        Console.WriteLine("1 - Add a Order to the orders list of the store");
                        Console.WriteLine("2 - Get a Order from the orders list of the store");
                        Console.WriteLine("3 - Get the Order list of the store");
                        Console.WriteLine("4 - Update a Order from the orders list of the store");
                        Console.WriteLine("5 - Delete a Order from the orders list of the store");
                        Console.WriteLine("0 - Exit");
                }
    }
}