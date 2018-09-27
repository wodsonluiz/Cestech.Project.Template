using Cestech.Domain.Interfaces;
using Cestech.Domain.Repositories;
using Flunt.Notifications;

namespace Cestech.Domain.Services
{
    public abstract class ServiceBase<T> : Notifiable, IServiceBase<T>
    {
        IRepositoryBase<T> _repositorio;

        public ServiceBase(IRepositoryBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual T Get(int id)
        {
            return _repositorio.Get(id);
        }

        public virtual bool Insert(T entity)
        {
            return _repositorio.Insert(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repositorio.Update(entity);
        }

        public virtual bool Delete(int id)
        {
            return _repositorio.Delete(id);
        }

        public virtual bool Exist(int id)
        {
            return _repositorio.Exist(id);
        }
    }
}
