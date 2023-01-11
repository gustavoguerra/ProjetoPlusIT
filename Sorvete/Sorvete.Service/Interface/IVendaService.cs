using Sorvete.Domain.Domain;

namespace Sorvete.Service.Interface
{
    public interface IVendaService
    {
        void Insert(VendaDomain obj);
        void Remove(VendaDomain obj);
        IEnumerable<VendaDomain> GetAll();
        VendaDomain GetById(int id);
        void Update(VendaDomain obj);
    }
}
