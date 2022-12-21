

namespace DO
{
    public class IdNotFound :  Exception
    {
        public IdNotFound (string error) : base(error) { }
    }

    public class IdAlreadyExist : Exception
    {
        public IdAlreadyExist (string error) : base(error) { }
    }
}
