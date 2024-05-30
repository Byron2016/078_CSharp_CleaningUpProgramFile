namespace _078_CSharp_CleaningUpProgramFile.Startup
{
    public static class MapEndpoints
    {
        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("/User", () => "Hello User");
            app.MapGet("/User/{name}", (string name) => $"Hello {name}");
            return app;
        }

        public static WebApplication MapDogEndpoints(this WebApplication app)
        {
            app.MapGet("/Dog", () => "Good boy");
            app.MapGet("/Dog/{name}", (string name) => $"Hello {name}");
            return app;
        }
    }
}
