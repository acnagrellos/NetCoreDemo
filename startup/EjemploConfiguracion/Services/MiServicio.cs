using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploConfiguracion.Services
{
    public class MiServicio : IMiServicio
    {
        private IRandomService _randomService;

        public MiServicio(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public int GetRandomNumber()
        {
            return _randomService.GetRandomNumber();
        }
    }
}
