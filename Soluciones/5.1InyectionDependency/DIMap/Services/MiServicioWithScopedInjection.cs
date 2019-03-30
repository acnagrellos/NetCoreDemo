using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMap.Services
{
    public class MiServicioWithScopedInjection : IMiServicioWithScopedInjection
    {
        private readonly IRandomNumberServiceScoped _randomNumberServiceScoped;
        public MiServicioWithScopedInjection(IRandomNumberServiceScoped randomNumberServiceScoped)
        {
            _randomNumberServiceScoped = randomNumberServiceScoped;
        }
        public int GetRandomNumber()
        {
            return _randomNumberServiceScoped.GetRandomNumber();
        }
    }
}
