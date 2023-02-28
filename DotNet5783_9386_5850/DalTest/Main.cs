using DO;

using static DO.Enums;


namespace DalList
{
    class TestClass
    {
        static void Main(string[] args)
        {
            DalApi.IDal? dal = DalApi.Factory.Get();
            Console.WriteLine("Welcome, Please Choose one choice from the Menu:");
            Console.WriteLine("1 - Check the DalProduct Class");
            Console.WriteLine("2 - Check the DalOrder Class");
            Console.WriteLine("3 - Check the DalOrderItem Class");
            Console.WriteLine("0 - Exit");
            int Choice1, Choice2;
            Choice1 = int.Parse(Console.ReadLine()!);
            while (Choice1 != 0)
            {
                switch (Choice1)
                {
                    case 1:
                        Console.WriteLine("DalProduct: Please Choose one choice:");
                        Console.WriteLine("1 - Add a Product to the product list of the store");
                        Console.WriteLine("2 - Get a Product from the product list of the store");
                        Console.WriteLine("3 - Get the Product list of the store");
                        Console.WriteLine("4 - Update a Product from the product list of the store");
                        Console.WriteLine("5 - Delete a Product from the product list of the store");
                        Console.WriteLine("0 - Exit");
                        Choice2 = int.Parse(Console.ReadLine()!);
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
                                    name = Console.ReadLine()!;
                                    Console.WriteLine("Please Enter Product price:");
                                    bool ok = double.TryParse(Console.ReadLine(), out price);
                                    if (!ok)
                                        throw new IOException("input is Wrzong");
                                    Console.WriteLine("Please enter Product's category:");
                                    Console.WriteLine("1 - Vegetables, 2 - Meat, 3 - Legumes, 4 - DairyProducts, 5 - CleanProducts");
                                    category = (Category)int.Parse(Console.ReadLine()!);
                                    Console.WriteLine("Please select quantity in stock for the product:");
                                    ok = int.TryParse(Console.ReadLine(), out instock);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        Product newProduct = dal!.Product!.Create(name, price, category, instock);
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
                                    ok = int.TryParse(Console.ReadLine(), out id);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        Product product = dal!.Product!.Get(id);
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
                                    IEnumerable<Product> products = dal!.Product!.GetList()!;
                                    foreach (Product product in products)
                                    {
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, In Stock:{4}",
                                            product.ID, product.Name, product.Price, product.Category, product.InStock);
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Please Enter the ID of the product you want to update:");
                                    ok = int.TryParse(Console.ReadLine(), out id);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        Product product = dal!.Product!.Get(id);
                                        Console.WriteLine("Product found!");
                                        Console.WriteLine("ID:{0}, Name:{1}, Price:{2}, Category:{3}, In Stock:{4}",
                                            product.ID, product.Name, product.Price, product.Category, product.InStock);
                                        Console.WriteLine("Please Enter the details of the new product to update:");
                                        Console.WriteLine("Please enter Product Name:");
                                        name = Console.ReadLine()!;
                                        Console.WriteLine("Please Enter Product price:");
                                        ok = double.TryParse(Console.ReadLine(), out price);
                                        if (!ok)
                                            throw new IOException("input is Wrong"); Console.WriteLine("Please enter Product's category:");
                                        Console.WriteLine("0 - Vegetables, 1 - Meat, 2 - Legumes, 3 - DairyProducts, 4 - CleanProducts");
                                        category = (Category)int.Parse(Console.ReadLine()!);
                                        Console.WriteLine("Please select quantity in stock for the product:");
                                        ok = int.TryParse(Console.ReadLine(), out instock);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
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
                                    ok = int.TryParse(Console.ReadLine(), out id);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        dal!.Product!.Delete(id);
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
                            Choice2 = int.Parse(Console.ReadLine()!);
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
                        Choice2 = int.Parse(Console.ReadLine()!);
                        while (Choice2 != 0)
                        {
                            switch (Choice2)
                            {
                                case 1:
                                    int id;
                                    string costumerName, costumerEmail, costumerAdress;
                                    DateTime orderDate, shipDate, deliveryDate;
                                    Console.WriteLine("Please enter Costumer Name:");
                                    costumerName = Console.ReadLine()!;
                                    Console.WriteLine("Please enter Costumer Email:");
                                    costumerEmail = Console.ReadLine()!;
                                    Console.WriteLine("Please enter Costumer Adress:");
                                    costumerAdress = Console.ReadLine()!;
                                    Console.WriteLine("Please enter Order Date:");
                                    bool ok = DateTime.TryParse(Console.ReadLine(), out orderDate);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    Console.WriteLine("Please enter Ship Date:");
                                    ok = DateTime.TryParse(Console.ReadLine(), out shipDate);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    Console.WriteLine("Please enter Delivery Date:");
                                    ok = DateTime.TryParse(Console.ReadLine(), out deliveryDate);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        Order NewOrder = dal!.Order!.Create(costumerName, costumerEmail, costumerAdress, orderDate, shipDate, deliveryDate);
                                        id = dal.Order.Add(NewOrder);
                                        Console.WriteLine("The order has been successfully added with id: {0}", id);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Please Enter the ID of the order to get:");
                                    ok = int.TryParse(Console.ReadLine(), out id);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        Order order = dal!.Order!.Get(id);
                                        Console.WriteLine("Order found!");
                                        Console.WriteLine("ID:{0}, Costumer Name:{1}, Costumer Email:{2}, Costumer Adress:{3}, Order Date:{4},Ship Date:{5}, Delivery Date:{6}",
                                            order.ID, order.CostumerName, order.CostumerEmail, order.CostumerAdress, order.OrderDate, order.ShipDate, order.DeliveryDate);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("The Orders list of the store:");
                                    IEnumerable<Order> orders = dal!.Order!.GetList()!;
                                    orders?.ToList().ForEach(order => Console.WriteLine("ID:{0}, Costumer Name:{1}, Costumer Email:{2}, Costumer Adress:{3}, Order Date:{4},Ship Date:{5}, Delivery Date:{6}",
                                    order.ID, order.CostumerName, order.CostumerEmail, order.CostumerAdress, order.OrderDate, order.ShipDate, order.DeliveryDate));
                                    break;
                                case 4:
                                    Console.WriteLine("Please Enter the ID of the order you want to update:");
                                    ok = int.TryParse(Console.ReadLine(), out id);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        Order order = dal!.Order!.Get(id);
                                        Console.WriteLine("Order found!");
                                        Console.WriteLine("ID:{0}, Costumer Name:{1}, Costumer Email:{2}, Costumer Adress:{3}, Order Date:{4},Ship Date:{5}, Delivery Date:{6}",
                                           order.ID, order.CostumerName, order.CostumerEmail, order.CostumerAdress, order.OrderDate, order.ShipDate, order.DeliveryDate);
                                        Console.WriteLine("Please Enter the details of the new order to update:");
                                        Console.WriteLine("Please enter Costumer Name:");
                                        costumerName = Console.ReadLine()!;
                                        Console.WriteLine("Please enter Costumer Email:");
                                        costumerEmail = Console.ReadLine()!;
                                        Console.WriteLine("Please enter Costumer Adress:");
                                        costumerAdress = Console.ReadLine()!;
                                        Console.WriteLine("Please enter Order Date:");
                                        ok = DateTime.TryParse(Console.ReadLine(), out orderDate);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
                                        Console.WriteLine("Please enter Ship Date:");
                                        ok = DateTime.TryParse(Console.ReadLine(), out shipDate);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
                                        Console.WriteLine("Please enter Delivery Date:");
                                        ok = DateTime.TryParse(Console.ReadLine(), out deliveryDate);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
                                        Order NewOrder = dal.Order.Create(costumerName, costumerEmail, costumerAdress, orderDate, shipDate, deliveryDate);
                                        NewOrder.ID = order.ID;
                                        dal.Order.Update(NewOrder);
                                        Console.WriteLine("The order has been successfully updated!");
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("Please Enter the ID of the order you want to delete:");
                                    ok = int.TryParse(Console.ReadLine(), out id);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        dal!.Order!.Delete(id);
                                        Console.WriteLine("The order has been successfully deleted!");
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
                            Console.WriteLine("DalOrder: Please Choose one choice:");
                            Console.WriteLine("1 - Add a Order to the orders list of the store");
                            Console.WriteLine("2 - Get a Order from the orders list of the store");
                            Console.WriteLine("3 - Get the Order list of the store");
                            Console.WriteLine("4 - Update a Order from the orders list of the store");
                            Console.WriteLine("5 - Delete a Order from the orders list of the store");
                            Console.WriteLine("0 - Exit");
                            Choice2 = int.Parse(Console.ReadLine()!);
                        }
                        break;
                    case 3:
                        Console.WriteLine("DalOrderItem: Please Choose one choice:");
                        Console.WriteLine("1 - Add a Order Item to the order items list of the store");
                        Console.WriteLine("2 - Get a Order Item from the order items list of the store");
                        Console.WriteLine("3 - Get the Order items list of the store");
                        Console.WriteLine("4 - Update a Order Item from the order items list of the store");
                        Console.WriteLine("5 - Delete a Order Item from the order items list of the store");
                        Console.WriteLine("0 - Exit");
                        Choice2 = int.Parse(Console.ReadLine()!);
                        while (Choice2 != 0)
                        {
                            switch (Choice2)
                            {
                                case 1:
                                    int ID,productId, orderId, amount;
                                    double price;
                                    Console.WriteLine("Please enter Product id:");
                                    bool ok = int.TryParse(Console.ReadLine(), out productId);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    Console.WriteLine("Please enter Order id:");
                                    ok = int.TryParse(Console.ReadLine(), out orderId);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    Console.WriteLine("Please enter price:");
                                    ok = double.TryParse(Console.ReadLine(), out price);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    Console.WriteLine("Please enter Amount:");
                                    ok = int.TryParse(Console.ReadLine(), out amount);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        OrderItem NewOrderItem = dal!.OrderItem!.Create(productId, orderId, price, amount);
                                        ID = dal.OrderItem.Add(NewOrderItem);
                                        Console.WriteLine("The order item has been successfully added with ID:{0}",ID);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Please Enter the ID of the order item to get:");
                                    ok = int.TryParse(Console.ReadLine(), out ID);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        OrderItem orderItem = dal!.OrderItem!.Get(ID);
                                        Console.WriteLine("Order item found!");
                                        Console.WriteLine("ID:{0}, Product ID:{1}, Product ID:{2}, Price:{3}, Amount:{4}",
                                            orderItem.ID,orderItem.ProductID, orderItem.ProductID, orderItem.Price, orderItem.Amount);
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 3:
                                        Console.WriteLine("The Order Items list:");
                                        var orderItems = dal!.OrderItem!.GetList();
                                        orderItems!.ToList().ForEach(orderitems => Console.WriteLine("ID:{0}, Product ID:{1}, Product ID:{2}, Price:{3}, Amount:{4}",
                                        orderitems.ID, orderitems.ProductID, orderitems.ProductID, orderitems.Price, orderitems.Amount));
                                    break;
                                case 4:
                                    Console.WriteLine("Please Enter the ID of the order you want to update:");
                                    ok = int.TryParse(Console.ReadLine(), out ID);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        OrderItem orderItem = dal!.OrderItem!.Get(ID);
                                        Console.WriteLine("Order Item found!");
                                        Console.WriteLine("ID:{0}, Product ID:{1}, Product ID:{2}, Price:{3}, Amount:{4}",
                                            orderItem.ID, orderItem.ProductID, orderItem.ProductID, orderItem.Price, orderItem.Amount);
                                        Console.WriteLine("Please Enter the details of the new order item to update:");
                                        Console.WriteLine("Please enter Product id:");
                                        ok = int.TryParse(Console.ReadLine(), out productId);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
                                        Console.WriteLine("Please enter Order id:");
                                        ok = int.TryParse(Console.ReadLine(), out orderId);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
                                        Console.WriteLine("Please enter price:");
                                        ok = double.TryParse(Console.ReadLine(), out price);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
                                        Console.WriteLine("Please enter Amount:");
                                        ok = int.TryParse(Console.ReadLine(), out amount);
                                        if (!ok)
                                            throw new IOException("input is Wrong");
                                        OrderItem NewOrderItem = dal.OrderItem.Create(productId, orderId, price, amount);
                                        NewOrderItem.ID = orderItem.ID;
                                        dal.OrderItem.Update(NewOrderItem);
                                        Console.WriteLine("The order item has been successfully updated!");
                                    }
                                    catch (Exception Error)
                                    {
                                        Console.WriteLine(Error.Message);
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("Please Enter the ID of the order item you want to delete:");
                                    ok = int.TryParse(Console.ReadLine(), out ID);
                                    if (!ok)
                                        throw new IOException("input is Wrong");
                                    try
                                    {
                                        dal!.OrderItem!.Delete(ID);
                                        Console.WriteLine("The order item has been successfully deleted!");
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
                            Console.WriteLine("DalOrderItem: Please Choose one choice:");
                            Console.WriteLine("1 - Add a Order Item to the order items list of the store");
                            Console.WriteLine("2 - Get a Order Item from the order items list of the store");
                            Console.WriteLine("3 - Get the Order items list of the store");
                            Console.WriteLine("4 - Update a Order Item from the order items list of the store");
                            Console.WriteLine("5 - Delete a Order Item from the order items list of the store");
                            Console.WriteLine("0 - Exit");
                            Choice2 = int.Parse(Console.ReadLine()!);
                        }
                        break;
                    default:
                        Console.WriteLine("Please Enter correct number!");
                        break;
                }
                Console.WriteLine("Welcome, Please Choose one choice from the Menu:");
                Console.WriteLine("1 - Check the DalProduct Class");
                Console.WriteLine("2 - Check the DalOrder Class");
                Console.WriteLine("3 - Check the DalOrderItem Class");
                Console.WriteLine("0 - Exit");
                Choice1 = int.Parse(Console.ReadLine()!);
            }
        }
    }
}
