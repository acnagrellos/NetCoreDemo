using System;

namespace ApiStructure.Services
{
    public class MiServicioScoped : IMiServicioScoped
    {
        private DateTime _date;

        public MiServicioScoped()
        {
            _date = DateTime.Now;
        }

        public DateTime GetRequestDate()
        {
            return _date;
        }
    }
}
