using Sorvete.Domain.Domain;

namespace Sorvete.Service.Interface
{
    public interface IProdutoService
    {
        void Insert(ProdutoDomain obj);
        void Remove(ProdutoDomain obj);
        IEnumerable<ProdutoDomain> GetAll();
        ProdutoDomain GetById(int id);
        void Update(ProdutoDomain obj);
    }
}
