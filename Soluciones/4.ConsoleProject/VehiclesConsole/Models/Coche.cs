namespace VehiclesConsole.Models
{
    public class Coche : IVehicle
    {
        private int _velocidad;

        public int GetVelocidad()
        {
            return _velocidad;
        }

        public void Acelerar()
        {
            _velocidad += 20;
        }

        public void Frenar()
        {
            _velocidad -= 20;
            if (_velocidad < 0)
            {
                _velocidad = 0;
            }
        }
    }
}
