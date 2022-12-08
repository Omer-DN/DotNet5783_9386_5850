using BlApi;

namespace BlImplementation
{
    internal class BoCart : IBoCart
    {
        private DalApi.IDal Dal ;
        /// <summary>
        /// Adding a product to the shopping cart
        /// </summary>
        /// <param name="cart"></shopping list>
        /// <param name="id"></Product ID>
        /// <returns></Returns the list if it is correct, otherwise throws an exception>
        /// <exception cref="BO.productOutOfStock"></exception>
        public BO.BoCart AddItem(BO.BoCart cart, int id)
        {
            bool findID = false;
            foreach (var item in cart.Items)
            {
                //If the product exists, update the list
                if (item.ID == id)
                {
                    DO.Product check_product = Dal.Product.Get(id);
                    if (check_product.InStock != 0)
                    {
                        findID = true;
                        item.Amount++;
                        item.TotalPrice += check_product.Price;
                        cart.TotalPrice += check_product.Price;
                        break;
                    }
                    else
                        throw new BO.productOutOfStock("this product arn't in the stock");
                }
            }
            if (!findID)
            {
                //If the product is out of stock
                DO.Product check_product = Dal.Product.Get(id);
                if(check_product.InStock != 0)
                {
                    BO.BoOrderItem newItem = new BO.BoOrderItem();
                    newItem.ProductID =id;
                    newItem.Amount = 1;
                    newItem.ID = BO.BoOrderItem.lastID++;
                    newItem.Name = check_product.Name;
                    newItem.Price = check_product.Price;
                    newItem.TotalPrice = newItem.Price * newItem.Amount;
                    cart.TotalPrice += check_product.Price;

                }
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
            
            foreach (var item in cart.Items)
            {
                if(item.ID == id)
                {
                    if (item.Amount < amount)
                    {
                        item.TotalPrice -= item.Price * item.Amount;
                        item.Amount = amount;
                        item.TotalPrice += item.Price * item.Amount;
                    }
                    if (item.Amount > amount)
                    {
                        item.TotalPrice -= item.Price * item.Amount;
                        item.Amount = amount;
                        item.TotalPrice += item.Price * item.Amount;
                    }
                    if (amount == 0)
                    {
                        item.TotalPrice -= item.Price * item.Amount;
                        item.Amount = amount;
                    }
                    if(amount < 0)
                        throw new BO.NegativeAmount("can't be a negative amount");
                }
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
        public void OrderConfirmation(BO.BoCart cart, DO.Order costumer)
        {   
            BO.BoOrderItem newOrderItem = new BO.BoOrderItem();

            foreach (var item in cart.Items)
            {
                try
                {
                    DO.Product check_product = Dal.Product.Get(item.ID);

                    if (check_product.InStock < item.Amount)
                    {
                        throw new BO.ProductNotEnoughStock("Not enough of this product in stock");
                       /* newOrderItem.ID = BO.BoOrderItem.lastID++;
                        newOrderItem.ProductID = item.ID;
                        newOrderItem.Amount = item.Amount;
                        newOrderItem.Name = item.Name;
                        newOrderItem.Price = item.Price;
                        newOrderItem.TotalPrice = item.Price * newOrderItem.Amount;
                        cart.TotalPrice += item.Price;*/
                        break;
                    }
                }
                catch (Exception)
                {
                    throw new BO.NotExist("Product does not exist in the store");
                }


                //צריך לעשות בדיקה אם המוצר בכלל לא קיים בחנות
            }
            if (string.IsNullOrEmpty(costumer.CostumerName))
                throw new BO.MissingCustomerName("Name does not exist in the system");

            if(string.IsNullOrEmpty(costumer.CostumerAdress))
                throw new BO.MissingCustomerStreet("There is no street in the system");

            if (string.IsNullOrEmpty(costumer.CostumerEmail))
                throw new BO.MissingCustomerStreet("The customer's email address is missing");

            if (!string.Equals(costumer.CostumerEmail[-10], "@gmail.com"))
                throw new BO.EmailAddressProblem("Problem with the customer's email address");

            DO.Order order = new DO.Order();
            order.OrderDate = DateTime.Now;
            order.ShipDate = DateTime.MinValue;
            order.DeliveryDate = DateTime.MinValue;
            

            
            foreach(var item in cart.Items)
            {
                DO.OrderItem productToOrder = new DO.OrderItem();
                productToOrder.ProductID = item.ID;
                productToOrder.Amount = item.Amount;
                productToOrder.Price += item.Price * item.Amount;
                productToOrder.ID = order.ID;
            
            }
            

        }

        public IEnumerable<BO.BoCart> GetBoCarts()
        {
            throw new NotImplementedException();
        }

        BO.BoOrder IBoCart.AddItem(BO.BoCart item, int id)
        {
            throw new NotImplementedException();
        }

        BO.BoOrder IBoCart.UpdateItem(BO.BoCart item, int amount, int id)
        {
            throw new NotImplementedException();
        }

        public BO.BoOrder OrderConfirmation(BO.BoCart item, int id)
        {
            throw new NotImplementedException();
        }
    }
    
}
