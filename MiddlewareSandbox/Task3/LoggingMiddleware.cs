namespace Task3
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"Method: {context.Request.Method}, Path: {context.Request.Path}");
            await _next(context);
        }
    }
}
