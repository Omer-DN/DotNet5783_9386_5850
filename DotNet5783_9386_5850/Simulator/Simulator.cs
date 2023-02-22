namespace Simulator
{
    static public class Simulator
    {
        static readonly BlApi.IBl? bl = BlApi.Factory.Get();

        private static volatile bool isWork = false;


        private static readonly Random random = new(DateTime.Now.Millisecond);

        public static void Activate()
        {
            new Thread(() =>
            {
                isWork = true;
                while (isWork)
                {
                    //int? id = bl?.BoOrder.GetOldestOrder().ID;
                    BO.BoOrder order = bl!.BoOrder!.GetOldestOrder();

                    if (order != null)
                    {
                        int time = random.Next(3, 11);
                        ScreenUpdate!(order.ID, time * 1000, order);
                        Thread.Sleep(1000 * time);
                        if (order.ShipDate == null)
                        {
                            bl?.BoOrder.UpdateShipping(order.ID);
                        }
                        else if (order.DeliveryDate == null)
                        {
                            bl?.BoOrder.UpdateDelivery(order.ID);
                        }
                    }
                    else//return null - no more order to work on, shout down simulator
                    {
                        Wating!();
                        Thread.Sleep(1000);
                    }

                }
            }).Start();
        }
        public static void ShutDown()
        { isWork = false; }


        public delegate void updateDel(int x, int time, BO.BoOrder order);
        public static event updateDel? ScreenUpdate;

        public delegate void noMoreOrders();
        public static event noMoreOrders? Wating;
    }
}