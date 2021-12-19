namespace WebAPI_Examples.Dominios
{
    public class Resultado
    {
        public object Dados { get; private set; }
        public Resultado(object dados)
        {
            this.Dados = dados;
        }
    }
}
