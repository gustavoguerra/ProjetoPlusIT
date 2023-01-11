using Sorvete.Domain.Domain;

namespace Sorvete.Business.Interface
{
    public interface IProdutoBusiness
    {
        void Insert(ProdutoDomain obj);
        void Remove(ProdutoDomain obj);
        IEnumerable<ProdutoDomain> GetAll();
        ProdutoDomain GetById(int id);
        void Update(ProdutoDomain obj);
    }
}
