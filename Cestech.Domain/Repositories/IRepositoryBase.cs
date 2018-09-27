namespace Cestech.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        T Get(int id);

        bool Insert(T entity);

        bool Update(T entity);

        bool Delete(int id);

        bool Exist(int id);
    }
}
