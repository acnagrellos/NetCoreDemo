namespace DIMap.Services
{
    public class MiServicio : IMiServicio
    {
        private readonly IRandomNumberServiceScoped _randomNumberService;

        public MiServicio(IRandomNumberServiceScoped randomNumberService)
        {
            _randomNumberService = randomNumberService;
        }

        public int GetRandomNumber()
        {
            return _randomNumberService.GetRandomNumber();
        }
    }
}
