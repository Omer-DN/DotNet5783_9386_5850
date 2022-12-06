

namespace DO
{
    public class idNotFound :  Exception
    {
        public idNotFound (string error) : base(error) { }
    }

    public class idAlreadyExist : Exception
    {
        public idAlreadyExist (string error) : base(error) { }
    }
}
