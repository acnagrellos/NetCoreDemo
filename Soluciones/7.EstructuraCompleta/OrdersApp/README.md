1. Añadir al proyecto los endpoints correspondientes para poder consultar una lista de productos con un servicio en memoria. Tiene que ser equivalente al de Clientes. Un Producto tendrá las propiedades de: Id, Name, Description, Price.

Para resolver el servicio de Producto hay que seguir el mismo proceso que el que se siguió con el de Clientes. En el proyecto está toda la solución.

2. Añadir al Producto un campo LastUpdate que se actualice cuando se cambie el objeto. Este campo no se debería enviar al API.

Para resolver este apartado hay que ver la diferencia entre el objeto de Dominio y crear un nuevo objeto DTO (Data Transfer Object) que devolver al API. Así, el DTO no tendrá el campo LastUpdate y será devuelto al API sin este campo. 

3. Añadir un middleware para capturar todos los errores que se produzcan en nuestro API y devolver el código de error correspondiente.

El middleware correspondiente lo tenéis en ```ErrorMiddleware```:

```csharp
public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (NotFoundException e)
        {
            context.Response.StatusCode = (int) HttpStatusCode.NotFound;
        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
```