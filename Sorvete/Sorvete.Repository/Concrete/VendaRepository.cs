using Dapper;
using Microsoft.Extensions.Configuration;
using Sorvete.Domain.Domain;
using Sorvete.Repository.Interface;

namespace Sorvete.Repository.Concrete
{
    public class VendaRepository : Repository<VendaDomain>, IVendaRepository
    {
        public VendaRepository(IConfiguration config) : base(config)
        {

        }

        public override bool Insert(VendaDomain obj)
        {
            var query = @"BEGIN TRY
	                        BEGIN TRAN
		                        UPDATE Produto SET QuantidadeEstoque = QuantidadeEstoque - @QUANTIDADE_VENDA WHERE id = @ID_PORDUTO
		                        INSERT INTO Venda VALUES (@ID_PORDUTO,GETDATE(),@QUANTIDADE_VENDA)
	                        COMMIT
                        END TRY
                        CATCH
                        BEGIN
	                        ROLLBACK
                        END";

            var parameters = new DynamicParameters();

            parameters.Add("@ID_PORDUTO", obj.IdProduto);
            parameters.Add("@QUANTIDADE_VENDA", obj.QuantidadeVenda);

            Conn.QueryAsync(query, parameters);

            return true;
        }
    }
}
