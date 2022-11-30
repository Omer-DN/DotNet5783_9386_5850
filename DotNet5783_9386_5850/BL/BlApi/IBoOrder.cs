using BL.BO;


namespace BlApi
{
    public interface IBoOrder
    {
        public IEnumerable<BoProduct?> GetOrder()
        {
            return new List<BoProduct?>();
        }

    }
}
