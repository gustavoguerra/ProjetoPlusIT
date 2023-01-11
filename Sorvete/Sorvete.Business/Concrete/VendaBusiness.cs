using Sorvete.Business.Interface;
using Sorvete.Domain.Domain;
using Sorvete.Domain.Helpers;
using Sorvete.Repository.Interface;

namespace Sorvete.Business.Concrete
{
    public class VendaBusiness : IVendaBusiness
    {
        protected readonly IVendaRepository _repository;
        public VendaBusiness(IVendaRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<VendaDomain> GetAll()
        {
            return _repository.GetAll();
        }

        public VendaDomain GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(VendaDomain obj)
        {
            ValidateObject(obj);
            _repository.insert(obj);
        }

        public void Remove(VendaDomain obj)
        {
            _repository.Remove(obj);
        }

        public void Update(VendaDomain obj)
        {
            ValidateObject(obj);
            _repository.Update(obj);
        }

        private void ValidateObject(VendaDomain obj)
        {
            DomainException.When(string.IsNullOrEmpty(obj.IdProduto), Messages.SALE_ERROR_PRODUCT);
            DomainException.When(obj.DataHoraVenda < DateTime.Now, Messages.SALE_ERROR_DATETIME);
            DomainException.When(obj.QuantidadeVenda <= 0, Messages.SALE_ERROR_QUANTITY);
        }
    }
}
