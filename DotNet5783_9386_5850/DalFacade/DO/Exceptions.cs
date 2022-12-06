

namespace DO
{
    public class idNotFound :  Exception
    {
        public idNotFound (string error) : base(error) { }
    }

    class idAlreadyExist : Exception
    {
        public idAlreadyExist (string error) : base(error) { }
    }
}
