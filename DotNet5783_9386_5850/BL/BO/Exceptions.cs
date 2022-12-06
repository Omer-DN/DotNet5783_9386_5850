

namespace BO
{
    public class productOutOfStock : Exception
    {
        public productOutOfStock (string error) : base(error) { }


    }
}
