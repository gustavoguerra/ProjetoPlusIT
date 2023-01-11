using AutoMapper;
using Sorvete.Application.ViewModel;
using Sorvete.Domain.Domain;

namespace Sorvete.Application.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<ProdutoDomain, ProdutoViewModel>();
            CreateMap<VendaDomain, VendaViewModel>();
        }
    }
}
