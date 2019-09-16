namespace DIMap.Services
{
    public class MiServicioWithSingletonInjection : IMiServicioWithSingletonInjection
    {
        private readonly IRandomNumberServiceSingleton _randomNumberServiceSingleton;
        public MiServicioWithSingletonInjection(IRandomNumberServiceSingleton randomServiceSingleton)
        {
            _randomNumberServiceSingleton = randomServiceSingleton;
        }

        public int GetRandomNumber()
        {
            return _randomNumberServiceSingleton.GetRandomNumber();
        }
    }
}
