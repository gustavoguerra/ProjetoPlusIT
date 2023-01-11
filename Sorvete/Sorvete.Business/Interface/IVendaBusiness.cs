using Sorvete.Domain.Domain;

namespace Sorvete.Business.Interface
{
    public interface IVendaBusiness
    {
        void Insert(VendaDomain obj);
        void Remove(VendaDomain obj);
        IEnumerable<VendaDomain> GetAll();
        VendaDomain GetById(int id);
        void Update(VendaDomain obj);
    }
}
