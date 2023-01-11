using Sorvete.Business.Interface;
using Sorvete.Domain.Domain;
using Sorvete.Domain.Helpers;
using Sorvete.Repository.Interface;

namespace Sorvete.Business.Concrete
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        protected readonly IProdutoRepository _repository;
        public ProdutoBusiness(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProdutoDomain> GetAll()
        {
            return _repository.GetAll();
        }

        public ProdutoDomain GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(ProdutoDomain obj)
        {
            ValidateObject(obj);
            _repository.insert(obj);
        }

        public void Remove(ProdutoDomain obj)
        {
            _repository.Remove(obj);            
        }

        public void Update(ProdutoDomain obj)
        {
            ValidateObject(obj);
            _repository.Update(obj);            
        }

        private void ValidateObject(ProdutoDomain obj)
        {
            DomainException.When(string.IsNullOrEmpty(obj.DescricaoProduto), Messages.PRODUCT_ERROR_DESCRIPTION);
            DomainException.When(obj.QuantidadeEstoque < 0, Messages.PRODUCT_ERROR_QUANTITY);
        }
    }
}
