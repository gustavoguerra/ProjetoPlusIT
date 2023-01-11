
namespace Sorvete.Domain.Domain
{
    public class VendaDomain : Entity
    {
        public int IdProduto { get; set; }
        public DateTime DataHoraVenda { get; set; }
        public int QuantidadeVenda { get; set; }
    }
}
