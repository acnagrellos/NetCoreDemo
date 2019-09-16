namespace VehiclesConsole.Models
{
    public class Avion : IVehicle
    {
        private int _velocidad;

        public int GetVelocidad()
        {
            return _velocidad;
        }

        public void Acelerar()
        {
            _velocidad += 100;
        }

        public void Frenar()
        {
            _velocidad -= 100;
            if (_velocidad < 0)
            {
                _velocidad = 0;
            }
        }
    }
}
