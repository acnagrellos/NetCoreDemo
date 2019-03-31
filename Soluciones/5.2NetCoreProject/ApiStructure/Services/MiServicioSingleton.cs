using System;

namespace ApiStructure.Services
{
    public class MiServicioSingleton : IMiServicioSingleton
    {
        private DateTime _date = DateTime.Now;

        public DateTime GetApiCreateDateTime()
        {
            return _date;
        }
    }
}
