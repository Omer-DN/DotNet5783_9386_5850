using BL.BO;


namespace BlApi
{
    public interface IOrder
    {
        public IEnumerable<BoProduct?> GetOrder()
        {
            return new List<BoProduct?>();
        }

    }
}
