using System;
using VehiclesConsole.Models;

namespace VehiclesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle = null;
            Console.WriteLine("¿Que vehículo prefieres? Pulsa 1 para Avion, 2 para coche");
            int.TryParse(
                Console.ReadLine(), 
                out int vehicleOption);

            switch (vehicleOption)
            {
                case 1:
                    vehicle = new Avion();
                    break;
                case 2:
                    vehicle = new Coche();
                    break;
                default:
                    Console.WriteLine("La opcion que ha elegido no es correcta, le asignaremos un coche");
                    vehicle = new Coche();
                    break;
            }

            Menu(vehicle);
        }

        public static void Menu(IVehicle vehicle)
        {
            int option = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine("Este es el menú. Por favor elija una opción:");
                Console.WriteLine("---------------------");
                Console.WriteLine("Para acelerar el coche pulse 1");
                Console.WriteLine("Para frenar el coche pulse 2");
                Console.WriteLine("Para ver la velocidad a la que va pulse 3");
                Console.WriteLine("Para crear un nuevo Avion y eleminar su vehiculo actual pulse 4");
                Console.WriteLine("Para crear un nuevo Coche y eleminar su vehiculo actual pulse 5");
                Console.WriteLine("Para salir pulse 6");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        vehicle.Acelerar();
                        Console.WriteLine("Vehículo acelerado");
                        break;
                    case 2:
                        vehicle.Frenar();
                        Console.WriteLine("Vehículo frenado");
                        break;
                    case 3:
                        Console.WriteLine($"Su velocidad actual es: {vehicle.GetVelocidadWithUnits()}");
                        break;
                    case 4:
                        vehicle = new Avion();
                        Console.WriteLine($"Nuevo Avion creado");
                        break;
                    case 5:
                        vehicle = new Coche();
                        Console.WriteLine($"Nuevo Coche creado");
                        break;
                    default:
                        Console.WriteLine("Esta opción no existe.");
                        break;
                }
            } while (option != 6);
        }
    }
}
