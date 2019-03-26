using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploConfiguracion.Services
{
    public class RandomService : IRandomService
    {
        private int _randomNumber;

        public RandomService()
        {
            var random = new Random();
            _randomNumber = random.Next(100);
        }

        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
