namespace Fiap.Web
{
    public static class SD
    {
        public static string CursoAPIBase { get; set; }
        public static string CarrinhoAPIBase { get; set; }
        public static string PromocaoAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
