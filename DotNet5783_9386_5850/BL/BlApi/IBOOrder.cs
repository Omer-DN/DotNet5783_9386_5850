using BL.BO;


namespace BlApi
{
    public interface IBOOrder
    {
        public IEnumerable<BoProduct?> GetOrder()
        {
            return new List<BoProduct?>();
        }

    }
}
