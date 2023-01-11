using Sorvete.Business.Interface;
using Sorvete.Domain.Domain;
using Sorvete.Service.Interface;

namespace Sorvete.Service.Concrete
{
    public class VendaService : IVendaService
    {
        protected readonly IVendaBusiness _business;

        public VendaService(IVendaBusiness business)
        {
            _business = business;
        }

        public IEnumerable<VendaDomain> GetAll()
        {
            return _business.GetAll();            
        }

        public VendaDomain GetById(int id)
        {
            return _business.GetById(id);
        }

        public void Insert(VendaDomain obj)
        {            
            _business.Insert(obj);        
        }

        public void Remove(VendaDomain obj)
        {
            _business.Remove(obj);
        }

        public void Update(VendaDomain obj)
        {
            _business.Update(obj);
        }
    }
}
