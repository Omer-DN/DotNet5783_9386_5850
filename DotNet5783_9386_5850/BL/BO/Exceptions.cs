

namespace BO
{
    /// <summary>
    /// List of exceptions
    /// </summary>
    public class productOutOfStock : Exception
    {
        public productOutOfStock (string error) : base(error) { }

    }
    /*public class WrongProductId : Exception
    {
        public WrongProductId(string error) : base(error) { }

    }*/
    public class WrongProductDetails : Exception
    {
        public WrongProductDetails(string error) : base(error) { }

    }
    public class productCantBeDeleted : Exception
    {
        public productCantBeDeleted(string error) : base(error) { }

    }
    public class WrongOrderDetails : Exception
    {
        public WrongOrderDetails(string error) : base(error) { }

    }
    public class WrongOrderToUpdate : Exception
    {
        public WrongOrderToUpdate(string error) : base(error) { }

    }
}
