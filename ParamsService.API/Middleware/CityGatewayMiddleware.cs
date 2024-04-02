namespace MMCEventsV1.Middlewares
{
    public class CityGatewayMiddleware
    {
        private readonly RequestDelegate _next;

        public CityGatewayMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the request matches the City gateway endpoint
            if (context.Request.Path.StartsWithSegments("/gateway/City"))
            {
                // Reroute the request to the desired destination
                context.Request.Path = "/api/City";
                context.Request.Host = new HostString("localhost", 7047);
                context.Request.Scheme = "https";
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}

