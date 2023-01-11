using Sorvete.Domain;

namespace Sorvete.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        bool insert(TEntity obj);
        bool Remove(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        bool Update(TEntity obj);
    }
}
