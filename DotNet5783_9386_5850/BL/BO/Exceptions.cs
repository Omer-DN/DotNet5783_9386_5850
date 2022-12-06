

namespace BO
{
    /// <summary>
    /// List of exceptions
    /// </summary>
    public class productOutOfStock : Exception
    {
        public productOutOfStock (string error) : base(error) { }


    }
}
