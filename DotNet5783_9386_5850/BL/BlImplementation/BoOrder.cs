using BlApi;


namespace BlImplementation
{
    internal class BoOrder : IBoOrder
    {
        private DalApi.IDal? dal = DalApi.Factory.Get();


        public IEnumerable<BO.BoOrderForList> GetListOfOrders()
        {
            IEnumerable<DO.Order> dataList = new List<DO.Order>();
            dataList = dal?.Order.GetList();
            List<BO.BoOrderForList> newList = new List<BO.BoOrderForList>();
            foreach (var order in dataList)
            {
                BO.BoOrderForList newItem = new BO.BoOrderForList();
                newItem.ID = order.ID;
                newItem.CostumerName = order.CostumerName;

                //check the order status:
                if (order.OrderDate != null && order.ShipDate == null && order.DeliveryDate == null)
                {
                    if (System.DateTime.Now > order.OrderDate) newItem.Status = BO.Enums.OrderStatus.Confirmed;
                }
                if (order.OrderDate != null && order.ShipDate != null && order.DeliveryDate == null)
                {
                    if (System.DateTime.Now > order.ShipDate) newItem.Status = BO.Enums.OrderStatus.Sent;
                }
                if (order.OrderDate != null && order.ShipDate != null && order.DeliveryDate != null)
                {
                    if (System.DateTime.Now > order.DeliveryDate) newItem.Status = BO.Enums.OrderStatus.Delivered; ;
                }

                //count how much items there is in this order, and summarizes thier total price:
                int numOfItems = 0;
                double totalPrice = 0;
                foreach (var productItem in dal?.OrderItem.GetList())
                {
                    if (productItem.OrderID == order.ID)
                    {
                        numOfItems++;
                        totalPrice += productItem.Price;
                    }
                }
                newItem.AmountOfItems = numOfItems;
                newItem.TotalPrice = totalPrice;

                newList.Add(newItem);
            }
            return newList;
        }

        //a private help method to convert and create DO.Order to Bo.Order
        private BO.BoOrder ConvertDOtoBO(DO.Order order)
        {
            BO.BoOrder newOrder = new BO.BoOrder();
            newOrder.Items = new List<BO.BoOrderItem?>();
            newOrder.ID = order.ID;
            newOrder.CostumerName = order.CostumerName;
            newOrder.CostumerEmail = order.CostumerEmail;
            newOrder.CostumerAdress = order.CostumerAdress;

            //check the order status:
            if (order.OrderDate != null && order.ShipDate == null && order.DeliveryDate == null)
            {
                if (System.DateTime.Now > order.OrderDate) newOrder.Status = BO.Enums.OrderStatus.Confirmed;
            }
            if (order.OrderDate != null && order.ShipDate != null && order.DeliveryDate == null)
            {
                if (System.DateTime.Now > order.ShipDate) newOrder.Status = BO.Enums.OrderStatus.Sent;
            }
            if (order.OrderDate != null && order.ShipDate != null && order.DeliveryDate != null)
            {
                if (System.DateTime.Now > order.DeliveryDate) newOrder.Status = BO.Enums.OrderStatus.Delivered; ;
            }
            newOrder.OrderDate = order.OrderDate;
            newOrder.ShipDate = order.ShipDate;
            newOrder.DeliveryDate = order.DeliveryDate;

            //check and create the list of items for the order:
            foreach (var orderItem in dal?.OrderItem.GetList())
            {
                if (orderItem.OrderID == order.ID)
                {
                    BO.BoOrderItem newItem = new BO.BoOrderItem();
                    newItem.ID = orderItem.ID;
                    newItem.Name = dal?.Product.Get(orderItem.ProductID).Name;
                    newItem.ProductID = orderItem.ProductID;
                    newItem.Price = orderItem.Price;
                    newItem.Amount = orderItem.Amount;
                    newItem.TotalPrice = newItem.Price * newItem.Amount;
                    newOrder.Items.Add(newItem);
                    newOrder.TotalPrice +=newItem.TotalPrice;
                }
            }
            return newOrder;
        }
        public BO.BoOrder GetOrder(int id)
        {
            BO.BoOrder newOrder = new BO.BoOrder();
            DO.Order dataOrder = dal.Order.Get(id);
            if (id > 0)
            {
                newOrder = ConvertDOtoBO(dataOrder);
            }
            else
                throw new BO.WrongOrderDetails("Error. the ID is Wrong");
            return newOrder;
        }


        public BO.BoOrder UpdateShipping(int id)
        {
            bool Exist = false;
            DO.Order newDoOrder = new DO.Order();
            BO.BoOrder newBoOrder = new BO.BoOrder();

            //Find the order in the data and save it
            foreach (var order in dal?.Order.GetList())
            {
                if (order.ID == id)
                {
                    Exist = true;
                    if (order.ShipDate == null)
                        newDoOrder = order;
                    else
                        throw new BO.WrongOrderToUpdate("Error. This order has already shipped");
                    break;
                }
            }

            //if found, update the Ship date in the data and create new updated BO.Order
            if (Exist)
            {
                newDoOrder.ShipDate = DateTime.Now;
                dal?.Order.Update(newDoOrder);
                newBoOrder = ConvertDOtoBO(newDoOrder);
            }
            else
                throw new BO.WrongOrderDetails("Error. the order is not Found!");

            //return the updated Order
            return newBoOrder;

        }

        public BO.BoOrder UpdateDelivery(int id)
        {
            bool Exist = false;
            DO.Order newDoOrder = new DO.Order();
            BO.BoOrder newBoOrder = new BO.BoOrder();

            //Find the order in the data and save it
            foreach (var order in dal?.Order.GetList())
            {
                if (order.ID == id)
                {
                    Exist = true;
                    if (order.DeliveryDate == null)
                        newDoOrder = order;
                    else
                        throw new BO.WrongOrderToUpdate("Error. This order has already Delivered");
                    break;
                }
            }
            //if found, update the Delivery date in the data and create new updated BO.Order
            if (Exist)
            {
                newDoOrder.DeliveryDate = DateTime.Now;
                dal?.Order.Update(newDoOrder);
                newBoOrder = ConvertDOtoBO(newDoOrder);
            }
            else
                throw new BO.WrongOrderDetails("Error. the order is not Found!");
            //return the updated Order
            return newBoOrder;
        }

        public BO.BoOrderTracking Track(int id)
        {
            bool Exist = false;
            BO.BoOrder boOrder = new BO.BoOrder();
            BO.BoOrderTracking track = new BO.BoOrderTracking();
            track.trackingSteps = new List<BO.TrackingSteps?>();
            foreach (var order in dal?.Order.GetList())
            {
                if (order.ID == id)
                {
                    Exist = true;
                    boOrder = ConvertDOtoBO(order);
                    track.ID = order.ID;
                    track.Status = boOrder.Status;
                    if (boOrder.OrderDate != null)
                    {
                        BO.TrackingSteps step1 = new BO.TrackingSteps();
                        step1.Time = boOrder.OrderDate;
                        step1.Status = BO.Enums.OrderStatus.Confirmed;
                        track.trackingSteps.Add(step1);
                    }
                    if (boOrder.ShipDate != null)
                    {
                        BO.TrackingSteps step2 = new BO.TrackingSteps();
                        step2.Time = boOrder.ShipDate;
                        step2.Status = BO.Enums.OrderStatus.Sent;
                        track.trackingSteps.Add(step2);
                    }
                    if (boOrder.DeliveryDate != null)
                    {
                        BO.TrackingSteps step3 = new BO.TrackingSteps();
                        step3.Time = boOrder.DeliveryDate;
                        step3.Status = BO.Enums.OrderStatus.Delivered;
                        track.trackingSteps.Add(step3);
                    }
                    break;
                }
            }
            if(!Exist)
            {
                throw new BO.WrongOrderDetails("Error. the order is not Found!");
            }

            return track;
        }

    }

}
