using Sorvete.Business.Interface;
using Sorvete.Domain.Domain;
using Sorvete.Service.Interface;

namespace Sorvete.Service.Concrete
{
    public class ProdutoService : IProdutoService
    {
        protected readonly IProdutoBusiness _business;

        public ProdutoService(IProdutoBusiness business)
        {
            _business = business;
        }


        public IEnumerable<ProdutoDomain> GetAll()
        {
            return _business.GetAll();
        }

        public ProdutoDomain GetById(int id)
        {
            return _business.GetById(id);
        }

        public void Insert(ProdutoDomain obj)
        {
            _business.Insert(obj);
        }

        public void Remove(ProdutoDomain obj)
        {
            _business.Remove(obj);
        }

        public void Update(ProdutoDomain obj)
        {
            _business.Update(obj);
        }
    }
}
