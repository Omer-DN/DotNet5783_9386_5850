
namespace DalApi
{
    public interface ICrud<T>
    {
        //Basic CRUD methods for All the entities:

        public int Add(T obj);
        public void Update(T obj);
        public void Delete(int id);
        public T? Get(int id);
        public T? GetCond(int id, Func<T?, bool>? condition);
        public IEnumerable<T?>? GetList(Func<T?, bool>? condition = null);
    }
}
