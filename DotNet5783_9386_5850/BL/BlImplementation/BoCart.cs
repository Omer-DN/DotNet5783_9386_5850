using BlApi;

namespace BlImplementation
{
    internal class BoCart:IBoCart
    {
        private DalApi.IDal Dal = new DalList.Dal.DalList();
        /// <summary>
        /// Adding a product to the shopping cart
        /// </summary>
        /// <param name="cart"></shopping list>
        /// <param name="id"></Product ID>
        /// <returns></Returns the list if it is correct, otherwise throws an exception>
        /// <exception cref="BO.ProductOutOfStock"></exception>
        public BO.BoCart AddItem(BO.BoCart cart, int id)
        {
            DO.Product detailproduct = new DO.Product();
            try
            {
                detailproduct = Dal.Product.Get(id);
            }
            catch (Exception e)
            {
                throw new BO.DataRequestFailed(e.Message);
            }

            if (detailproduct.InStock < 1)
            {
                throw new BO.ProductOutOfStock("Out of stock");
            }

            if (!cart.Items.Exists(x => x.ProductID == id))
            {
                BO.BoOrderItem OrderItem = new BO.BoOrderItem()
                {
                    ProductID = id,
                    Name = detailproduct.Name,
                    Amount = 1,
                    ID = 0,
                    Price = detailproduct.Price,
                    TotalPrice = detailproduct.Price
                };
                cart.Items.Add(OrderItem);
                cart.TotalPrice = detailproduct.Price;
            }
            else
            {
                int i = cart.Items.FindIndex(x => x.ProductID == id);
                if (detailproduct.InStock < cart.Items[i].Amount + 1)
                    throw new BO.ProductOutOfStock("Out of stock");
                cart.Items[i].Amount += 1;
                cart.Items[i].TotalPrice += cart.Items[i].Price;
                cart.TotalPrice += cart.Items[i].Price;
            }
            return cart;
        }

        //    bool findID = false;
        //    foreach (var item in cart.Items)
        //    {
        //        //If the product exists, update the list
        //        if (item.ID == id)
        //        {
        //            DO.Product check_product = Dal.Product.Get(id);
        //            if (check_product.InStock != 0)
        //            {
        //                findID = true;
        //                item.Amount++;
        //                item.TotalPrice += check_product.Price;
        //                cart.TotalPrice += check_product.Price;
        //                break;
        //            }
        //            else
        //                throw new BO.ProductOutOfStock("this product arn't in the stock");
        //        }
        //    }
        //    if (!findID)
        //    {
        //        //If the product is out of stock
        //        DO.Product check_product = Dal.Product.Get(id);
        //        if (check_product.InStock != 0)
        //        {
        //            BO.BoOrderItem newItem = new BO.BoOrderItem();
        //            newItem.ProductID = id;
        //            newItem.Amount = 1;
        //            newItem.ID = BO.BoOrderItem.lastID++;
        //            newItem.Name = check_product.Name;
        //            newItem.Price = check_product.Price;
        //            newItem.TotalPrice = newItem.Price * newItem.Amount;
        //            cart.TotalPrice += check_product.Price;

        //        }
        //    }
        //    return cart;
        //}


        /// <summary>
        /// Updating the quantity of a product in the shopping basket
        /// </summary>
        /// <param name="cart"></shopping list>
        /// <param name="amount"></The amount of mustard in stock>
        /// <param name="id"></Product ID>
        /// <returns></Returns the list if it is correct, otherwise throws an exception>>
        /// <exception cref="BO.NegativeAmount"></exception>
        public BO.BoCart UpdateItem(BO.BoCart cart, int amount, int id)
        {
            int i = cart.Items.FindIndex(x => x.ProductID == id);
            if (i < 0)
            {
                throw new BO.ProductDoesNotExist("product not found");
            }
            else if (cart.Items[i].Amount < amount)
            {
                int newItems = amount - cart.Items[i].Amount;
                for (int k = 0; k < newItems; k++)
                {
                    try
                    {
                        AddItem(cart, id);
                    }
                    catch (Exception e)
                    {
                        throw new BO.WrongOrderToUpdate(e.Message);
                    }
                }
            }
            else if (amount == 0)
            {
                cart.TotalPrice -= cart.Items[i].TotalPrice;
                cart.Items.RemoveAt(i);
            }
            else
            {
                int subItems = cart.Items[i].Amount - amount;
                cart.Items[i].Amount = amount;
                cart.Items[i].TotalPrice -= cart.Items[i].Price * subItems;
                cart.TotalPrice = cart.Items[i].Price * subItems;
            }
            return cart;
        }

        //    foreach (var item in cart.Items)
        //    {
        //        if (item.ID == id)
        //        {
        //            if (item.Amount < amount)
        //            {
        //                item.TotalPrice -= item.Price * item.Amount;
        //                item.Amount = amount;
        //                item.TotalPrice += item.Price * item.Amount;
        //            }
        //            if (item.Amount > amount)
        //            {
        //                item.TotalPrice -= item.Price * item.Amount;
        //                item.Amount = amount;
        //                item.TotalPrice += item.Price * item.Amount;
        //            }
        //            if (amount == 0)
        //            {
        //                item.TotalPrice -= item.Price * item.Amount;
        //                item.Amount = amount;
        //            }
        //            if (amount < 0)
        //                throw new BO.NegativeAmount("can't be a negative amount");
        //        }
        //    }
        //    return cart;
        //}

        /// <summary>
        /// Basket confirmation for order / placing an order
        /// </summary>
        /// <param name="cart"></shopping list>
        /// <param name="costumer"></costumer>
        /// <exception cref="BO.NotExist"></exception>
        /// <exception cref="BO.MissingCustomerName"></exception>
        /// <exception cref="BO.MissingCustomerStreet"></exception>
        /// <exception cref="BO.EmailAddressProblem"></exception>
        public void OrderConfirmation(BO.BoCart cart, string customerName, string customerEmail, string customerAdress)
        {
            BO.BoOrderItem newOrderItem = new BO.BoOrderItem();

            if (customerName == null)
                throw new BO.MissingCustomerName("Name does not exist in the system");

            if (customerAdress == null)
                throw new BO.MissingCustomerStreet("There is no street in the system");

            if (customerEmail == null)
                throw new BO.MissingCustomerStreet("The customer's email address is missing");

            if (!string.Equals(customerEmail[-10], "@gmail.com"))
                throw new BO.EmailAddressProblem("Problem with the customer's email address");
            double TotalPrice_ = 0;
            DO.Product product = new();

            foreach (var item in cart.Items)
            {
                try
                {
                    product = Dal.Product.Get(item.ProductID);

                }
                catch (Exception)
                {
                    throw new BO.NotExist("Product does not exist in the store");
                }

                if (item.Amount <= 0)
                    throw new BO.ProductOutOfStock(item.Name + " must be greater than zero");
                if (product.InStock < item.Amount)
                    throw new BO.ProductOutOfStock($"The product {item.Name} (ID:) {item.ProductID} is out of stock");
                if (item.Price != product.Price)
                    throw new BO.ProductOutOfStock($"price in cart of {item.Name} not match to price in Data Surce");
                if (item.TotalPrice != (item.Amount * product.Price))
                    throw new BO.ProductOutOfStock($"Total price of {item.ProductID} not match to Price and Amount in Cart");
                TotalPrice_ += item.TotalPrice;
            }

            if (TotalPrice_ != cart.TotalPrice)
                throw new BO.WrongOrderDetails("Total price in cart not match to prices and Amont of all item in cart");

            DO.Order order = new()
            {
                CostumerName = customerName,
                CostumerAdress = customerAdress,
                CostumerEmail = customerEmail,
                OrderDate = DateTime.Now,
                ShipDate = null,
                DeliveryDate = null
            };

            try
            {
                //try to add order to data sirce in Dal
                int orderId = Dal.Order.Add(order);
                //create orderItem in Dal and update amount of product
                DO.OrderItem orderItem = new();
                foreach (var item in cart.Items)
                {
                    //create an orderItem for dall and add it
                    orderItem.OrderID = orderId;
                    orderItem.ProductID = item.ProductID;
                    orderItem.Amount = item.Amount;
                    orderItem.Price = item.Price;
                    int orderItemId = Dal.OrderItem.Add(orderItem);
                    //update amount of product in Dak
                    product = Dal.Product.Get(item.ProductID);
                    product.InStock -= item.Amount;
                    Dal.Product.Update(product);
                }
            }
            catch (Exception error)
            {
                throw new BO.WrongProductDetails(error.Message);
            }
        }
    }
}