namespace Task3
{
    public class CustomQueryMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomQueryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("custom"))
            {
                await context.Response.WriteAsync("You've hit a custom middleware!");
            }
            else
            {
                await _next(context);
            }
        }
    }

}
