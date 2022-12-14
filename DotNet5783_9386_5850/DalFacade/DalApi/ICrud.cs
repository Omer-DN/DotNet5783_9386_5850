
namespace DalApi
{
    public interface ICrud<T>
    {
        //Basic CRUD methods for All the entities:

        public int Add(T obj);
        public void Update(T obj);
        public void Delete(int id);
        public T Get(int id);
        public IEnumerable<T?>? GetList();
    }
}
