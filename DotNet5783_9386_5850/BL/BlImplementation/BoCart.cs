using BlApi;

namespace BlImplementation
{
    internal class BoCart:IBoCart
    {
        private DalApi.IDal? dal = DalApi.Factory.Get();

        DO.Product detailproduct = new();
        /// <summary>
        /// Adding a product to the shopping cart
        /// </summary>
        /// <param name="cart"></shopping list>
        /// <param name="id"></Product ID>
        /// <returns></Returns the list if it is correct, otherwise throws an exception>
        /// <exception cref="BO.ProductOutOfStock"></exception>
        public BO.BoCart AddItem(BO.BoCart cart, int id)
        {
            try
            {
                detailproduct = dal!.Product!.Get(id);
            }
            catch (Exception e)
            {
                throw new BO.DataRequestFailed(e.Message);
            }

            if (detailproduct.InStock < 1)
            {
                throw new BO.ProductOutOfStock("Out of stock");
            }
            if(cart.Items == null)
            {
                cart.Items = new List<BO.BoOrderItem>()!;
                BO.BoOrderItem BoOrderItem = new BO.BoOrderItem();
                BoOrderItem.Name = detailproduct.Name;
                BoOrderItem.ProductID = id;
                BoOrderItem.Price = detailproduct.Price;
                BoOrderItem.Amount = 1;
                BoOrderItem.TotalPrice = detailproduct.Price;

                cart.Items.Add(BoOrderItem);
                cart.TotalPrice += BoOrderItem.Price;

            }
            else if (!cart.Items.Exists(x => x!.ProductID == id))
            {
                BO.BoOrderItem BoOrderItem = new BO.BoOrderItem();
                BoOrderItem.Name = detailproduct.Name;
                BoOrderItem.ProductID = id;
                BoOrderItem.Price = detailproduct.Price;
                BoOrderItem.Amount = 1;
                BoOrderItem.TotalPrice = detailproduct.Price;

                cart.Items.Add(BoOrderItem);
                cart.TotalPrice += BoOrderItem.Price;
            }
            else
            {
                int i = cart.Items.FindIndex(x => x!.ProductID == id);
                if (detailproduct.InStock < cart.Items[i]!.Amount + 1)
                    throw new BO.ProductOutOfStock("Out of stock");
                cart.Items[i]!.Amount += 1;
                cart.Items[i]!.TotalPrice += cart.Items[i]!.Price;
                cart.TotalPrice += cart.Items[i]!.Price;
            }
            return cart;
        }

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
            int i = cart.Items!.FindIndex(x => x!.ProductID == id);
            if (i < 0)
            {
                throw new BO.ProductDoesNotExist("product not found");
            }
            else if (cart.Items[i]!.Amount < amount)
            {
                int newItems = amount - cart.Items[i]!.Amount;
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
                cart.TotalPrice -= cart.Items[i]!.TotalPrice;
                cart.Items.RemoveAt(i);
            }
            else
            {
                int subItems = cart.Items[i]!.Amount - amount;
                cart.Items[i]!.Amount = amount;
                cart.Items[i]!.TotalPrice -= cart.Items[i]!.Price * subItems;
                cart.TotalPrice = cart.Items[i]!.Price * subItems;
            }
            return cart;
        }

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


            double TotalPrice_ = 0;
            DO.Product product = new();

            foreach (var item in cart.Items!)
            {
                try
                {
                    product = dal!.Product!.Get(item!.ProductID);

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
                DeliveryDate = null,
            };

            try
            {
                //try to add order to data sirce in dal
                int orderId = dal!.Order!.Add(order);
                //create orderItem in dal and update amount of product
                DO.OrderItem orderItem = new();
                foreach (var item in cart.Items)
                {
                    //create an orderItem for dall and add it
                    orderItem.OrderID = orderId;
                    orderItem.ProductID = item!.ProductID;
                    orderItem.Amount = item.Amount;
                    orderItem.Price = item.Price;
                    int orderItemId = dal.OrderItem!.Add(orderItem);
                    //update amount of product in Dak
                    product = dal.Product!.Get(item.ProductID);
                    product.InStock -= item.Amount;
                    dal.Product.Update(product);
                }
            }
            catch (Exception error)
            {
                throw new BO.WrongProductDetails(error.Message);
            }
        }
    }
}