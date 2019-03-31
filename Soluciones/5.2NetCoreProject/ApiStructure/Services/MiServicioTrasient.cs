using System;

namespace ApiStructure.Services
{
    public class MiServicioTrasient : IMiServicioTrasient
    {
        private DateTime _date;

        public MiServicioTrasient()
        {
            _date = DateTime.Now;
        }

        public DateTime GetNewServiceDate()
        {
            return _date;
        }
    }
}
