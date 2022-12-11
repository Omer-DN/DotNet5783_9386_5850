

namespace BO
{
    /// <summary>
    /// List of exceptions
    /// </summary>
    public class productOutOfStock : Exception
    {
        public productOutOfStock (string error) : base(error) { }

    }

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

    public class NegativeAmount : Exception
    {
        public NegativeAmount(string error) : base(error) { }
    }
        public class ProductDoesNotExist : Exception
    {
        public ProductDoesNotExist(string error) : base(error) { }
    }
    
        public class ProductNotEnoughStock : Exception
    {
        public ProductNotEnoughStock(string error) : base(error) { }
    }
    public class MissingCustomerStreet : Exception
    {
        public MissingCustomerStreet(string error) : base(error) { }
    }
    public class MissingCustomerName : Exception
    {
        public MissingCustomerName(string error) : base(error) { }
    }
        public class EmailAddressProblem : Exception
    {
        public EmailAddressProblem(string error) : base(error) { }
    }
    
        public class MissingEmailAddress : Exception
    {
        public MissingEmailAddress(string error) : base(error) { }
    }
        public class NotExist : Exception
    {
        public NotExist(string error) : base(error) { }
    }

}
