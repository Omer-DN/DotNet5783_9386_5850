using BlApi;
using DalApi;

namespace BlImplementation
{
    internal class BoOrder : IBoOrder
    {
        /* public IEnumerable<BO.BoOrder?> GetOrders()
         {
             return 
         }*/
        public List<BoOrder>? Items { get; set; }

        private IDal Dal = new(DalList.Dal);
    }
}
