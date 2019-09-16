1. Crea una aplicacion de consola con un menu donde puedas elegir un vehiculo. Los vehiculos tendrán una propiedad que será su velocidad. También tendrán dos métodos, uno de frenar y otro de acelerar. En el menú podremos elegir coche. Los vehiculos tendrán dos métodos que serán acelerar y frenar. Para el coche acelerar sumará a su velocidad 20 km/h. El avión avanzará 100 Km/h.

El menu de la aplicación te permitirá frenar con el vehículo que tengas seleccionado o acelerar con el mismo. Asi mismo podrás consultar su velocidad.

El problema del ejercicio se soluciona usando un interfaz para manejar los dos Vehículos, ya que sus métodos son iguales. Por ello en la solución del ejercicio se ha creado el interfaz IVehicle

```csharp
public interface IVehicle
{
    int GetVelocidad();
    void Frenar();
    void Acelerar();
}
```

Después, en el Menú donde realizamos las acciones en lugar de usar la clase del objeto en sí, pasamos un interfaz. Esto nos abstrae del vehículo que estamos usando y nos permite tener un código más claro:

```csharp

public static void Menu(IVehicle vehicle)
{
    ....

    switch (option) 
    {
        ...
        case 1:
            vehicle.Acelerar();
            break;
        ....
    }
}
```

2. Crea un método de extension que te devuelva la velocidad del vehículo en un string acompañado de sus unidades. Si la velocidad vale 20 el método deberá retornar 20 km/h.

Para el segundo ejercicio, tenemos que crear un método de extensión de la interfaz, para que lo podamos usar en el menú en dicha abstracción. Para ello podemos crear una clase estática en un fichero de extensions:

```csharp
public static class IVehicleExtensions
{
    public static string GetVelocidadWithUnits(this IVehicle vehicle) =>
        $"{vehicle.GetVelocidad()} km/h";
}
```