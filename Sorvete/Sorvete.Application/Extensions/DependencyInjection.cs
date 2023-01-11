using Sorvete.Application.AutoMapper;
using Sorvete.Business.Concrete;
using Sorvete.Business.Interface;
using Sorvete.Repository.Concrete;
using Sorvete.Repository.Interface;
using Sorvete.Service.Concrete;
using Sorvete.Service.Interface;

namespace Sorvete.Application.Extensions
{
    public static class DependencyInjection
    {

        public static void InjectDependencies(this IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfig.RegisterMappings();
            services.AddSingleton(mapperConfig.CreateMapper());

            DependencyInjectionServices(services);
            DependencyInjectionBusiness(services);
            DependencyInjectionRepository(services);
        }

        private static void DependencyInjectionServices(IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IVendaService, VendaService>();
        }
        private static void DependencyInjectionBusiness(IServiceCollection services)
        {
            services.AddTransient<IProdutoBusiness, ProdutoBusiness>();
            services.AddTransient<IVendaBusiness, VendaBusiness>();
        }

        private static void DependencyInjectionRepository(IServiceCollection services)
        {
            services.AddSingleton<IProdutoRepository, ProdutoRepository>();
            services.AddSingleton<IVendaRepository, VendaRepository>();
        }
    }
}
