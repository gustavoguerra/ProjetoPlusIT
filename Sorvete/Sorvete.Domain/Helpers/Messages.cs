namespace Sorvete.Domain.Helpers
{
    public static class Messages
    {
        public const string ERROR_GENERIC = "Ocorreu um erro ao processar a requisição, favor contate o responsável !";
        public const string ERROR_TOKEN = "Token Invalido";

        //Produto
        public const string PRODUCT_ERROR_DESCRIPTION = "Descrição do produto é invalida";
        public const string PRODUCT_ERROR_QUANTITY = "Quantidade não pode ser negativa";

        //Venda
        public const string SALE_ERROR_PRODUCT = "Produto invalido";
        public const string SALE_ERROR_DATETIME = "A data da venda não pode ser menor que a data atual";
        public const string SALE_ERROR_QUANTITY = "Quantidade de produto deve ser maior que 0";
    }
}
