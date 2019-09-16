namespace VehiclesConsole.Models
{
    public interface IVehicle
    {
        int GetVelocidad();
        void Frenar();
        void Acelerar();
    }
}
