namespace VehiclesConsole.Models
{
    public static class IVehicleExtensions
    {
        public static string GetVelocidadWithUnits(this IVehicle vehicle) =>
            $"{vehicle.GetVelocidad()} km/h";
    }
}
