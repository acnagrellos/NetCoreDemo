namespace ApiStructure.Services
{
    public class MiServicioEnDev : IServiceEnvironment
    {
        public string GetEnvironment() => "Dev";
    }
}
