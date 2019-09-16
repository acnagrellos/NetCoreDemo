1. A�adir al proyecto los endpoints correspondientes para poder consultar una lista de productos con un servicio en memoria. Tiene que ser equivalente al de Clientes. Un Producto tendr� las propiedades de: Id, Name, Description, Price.

Para resolver el servicio de Producto hay que seguir el mismo proceso que el que se sigui� con el de Clientes. En el proyecto est� toda la soluci�n.

2. A�adir al Producto un campo LastUpdate que se actualice cuando se cambie el objeto. Este campo no se deber�a enviar al API.

Para resolver este apartado hay que ver la diferencia entre el objeto de Dominio y crear un nuevo objeto DTO (Data Transfer Object) que devolver al API. As�, el DTO no tendr� el campo LastUpdate y ser� devuelto al API sin este campo. 

3. A�adir un middleware para capturar todos los errores que se produzcan en nuestro API y devolver el c�digo de error correspondiente.

El middleware correspondiente lo ten�is en ```ErrorMiddleware```:

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