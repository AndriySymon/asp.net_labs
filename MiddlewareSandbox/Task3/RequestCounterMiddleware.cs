using System;

public class RequestCounterMiddleware
{
    private readonly RequestDelegate _next;
    private static int _requestCount = 0;

    public RequestCounterMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        _requestCount++;
        await _next(context);
        await context.Response.WriteAsync($"\nThe amount of processed requests is {_requestCount}.");
    }
}
