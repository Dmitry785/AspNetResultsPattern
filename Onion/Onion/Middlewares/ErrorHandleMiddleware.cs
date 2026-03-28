namespace Onion.Api.Middlewares;

public class ErrorHandleMiddleware
{
    private readonly RequestDelegate _handler;
    public ErrorHandleMiddleware(RequestDelegate handler)
    {
        _handler = handler;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _handler.Invoke(context);
        }
        catch (ArgumentException argEx)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(argEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
        }
    }
}
