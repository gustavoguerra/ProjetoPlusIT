using AutoMapper;
using Sorvete.Application.ViewModel;
using Sorvete.Domain.Domain;

namespace Sorvete.Application.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ProdutoViewModel, ProdutoDomain>();
            CreateMap<VendaViewModel, VendaDomain>();
        }
    }
}
