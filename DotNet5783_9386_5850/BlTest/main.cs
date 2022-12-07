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
            IBl BL = new Bl();
            BoCart UserCart = new BoCart();
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
                        Console.WriteLine("2 - Get a Product for the buyer (from catalog)");
                        Console.WriteLine("3 - Get a Product for the manger of the store");
                        Console.WriteLine("4 - Get the list of products");
                        Console.WriteLine("5 - Update a Product from the store");
                        Console.WriteLine("6 - Delete a Product from the store");
                        Console.WriteLine("0 - Exit");
                        Choice2 = int.Parse(Console.ReadLine());
                        while (Choice2 != 0)
                        {
                            switch (Choice2)
                            {
                                case 1:

                                    string name;
                                    double price;
                                    BO.Enums.Category category;
                                    int id, instock;
                                    Console.WriteLine("Please enter Product Name:");
                                    name = Console.ReadLine()!;
                                    Console.WriteLine("Please Enter Product price:");
                                    price = double.Parse(Console.ReadLine()!);
                                    Console.WriteLine("Please enter Product's category:");
                                    Console.WriteLine("1 - vegetables, 2 - Meat, 3 - Legumes, 4 - DairyProducts, 5 - CleanProducts");
                                    category = (BO.Enums.Category)int.Parse(Console.ReadLine()!);
                                    Console.WriteLine("Please select quantity in stock for the product:");
                                    instock = int.Parse(Console.ReadLine()!);
                                    try
                                    {
                                        BoProduct newProduct = BL.BoProduct.Create(name, price, category, instock);
                                        BL.BoProduct.AddProduct(newProduct);
                                        Console.WriteLine("The product has been successfully added!");
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                            
                                case 2:
                                    Console.WriteLine("Please Enter the ID of the product to get from the catalog:");
                                    id = int.Parse(Console.ReadLine()!);
                                    try
                                    {
                                        BoProductItem newProductitem = BL.BoProduct.BuyerGetProduct(UserCart,id);
                                        Console.WriteLine("Product found!");
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, Amount in Cart:{4} In Stock:{5}",
                                            newProductitem.ID, newProductitem.Name, newProductitem.Price,
                                            newProductitem.Category, newProductitem.Amount,newProductitem.InStock);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Please Enter the ID of the product to get (for manager):");
                                    id = int.Parse(Console.ReadLine()!);
                                    try
                                    {
                                        BoProduct newProductitem = BL.BoProduct.ManagerGetProduct(id);
                                        Console.WriteLine("Product found!");
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, In Stock:{4}",
                                            newProductitem.ID, newProductitem.Name, newProductitem.Price,
                                            newProductitem.Category, newProductitem.InStock);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("The Product list of the store:");
                                    IEnumerable<BoProductForList> products = BL.BoProduct.GetListOfProducts();
                                    foreach (BoProductForList product in products)
                                    {
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}",
                                            product.ID, product.Name, product.Price, product.Category);
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("Please Enter the ID of the product you want to update:");
                                    id = int.Parse(Console.ReadLine()!);
                                    try
                                    {
                                        BoProduct productToUpdate = BL.BoProduct.ManagerGetProduct(id);
                                        Console.WriteLine("Product found!");
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, In Stock:{4}",
                                            productToUpdate.ID, productToUpdate.Name, productToUpdate.Price,
                                            productToUpdate.Category, productToUpdate.InStock);
                                        Console.WriteLine("Please Enter the details of the new product to update:");
                                        Console.WriteLine("Please enter Product Name:");
                                        name = Console.ReadLine()!;
                                        Console.WriteLine("Please Enter Product price:");
                                        price = double.Parse(Console.ReadLine()!);
                                        Console.WriteLine("Please enter Product's category:");
                                        Console.WriteLine("0 - vegetables, 1 - Meat, 2 - Legumes, 3 - DairyProducts, 4 - CleanProducts");
                                        category = (BO.Enums.Category)int.Parse(Console.ReadLine()!);
                                        Console.WriteLine("Please select quantity in stock for the product:");
                                        instock = int.Parse(Console.ReadLine()!);
                                        BoProduct NewProduct = BL.BoProduct.Create(name, price, category, instock);
                                        NewProduct.ID = productToUpdate.ID;
                                        BL.BoProduct.UpdateProduct(NewProduct);
                                        Console.WriteLine("The product has been successfully updated!");
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine("Please Enter the ID of the product you want to delete:");
                                    id = int.Parse(Console.ReadLine()!);
                                    try
                                    {
                                        BL.BoProduct.DeleteProduct(id);
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
                            Console.WriteLine("BoProduct: Please Choose one choice:");
                            Console.WriteLine("1 - Add product to the store");
                            Console.WriteLine("2 - Get a Product for the buyer (from catalog)");
                            Console.WriteLine("3 - Get a Product for the manger of the store");
                            Console.WriteLine("4 - Get the list of products");
                            Console.WriteLine("5 - Update a Product from the store");
                            Console.WriteLine("6 - Delete a Product from the store");
                            Console.WriteLine("0 - Exit");
                            Choice2 = int.Parse(Console.ReadLine()!);
                        }
                        break;
                    case 2:
                        Console.WriteLine("BoCart: Please Choose one choice:");
                        




                }
    }
}