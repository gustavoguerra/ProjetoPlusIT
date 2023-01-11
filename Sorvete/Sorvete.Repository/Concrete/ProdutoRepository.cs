using Microsoft.Extensions.Configuration;
using Sorvete.Domain.Domain;
using Sorvete.Repository.Interface;

namespace Sorvete.Repository.Concrete
{
    public class ProdutoRepository : Repository<ProdutoDomain>, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration config) : base(config)
        {

        }
    }
}
