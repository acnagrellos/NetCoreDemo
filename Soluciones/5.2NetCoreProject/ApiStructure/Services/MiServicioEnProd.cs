namespace ApiStructure.Services
{
    public class MiServicioEnProd : IServiceEnvironment
    {
        public string GetEnvironment() => "Prod";
    }
}
