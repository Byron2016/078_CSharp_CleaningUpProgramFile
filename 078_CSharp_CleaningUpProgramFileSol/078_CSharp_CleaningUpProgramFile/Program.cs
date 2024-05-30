using _078_CSharp_CleaningUpProgramFile.Startup;

namespace _078_CSharp_CleaningUpProgramFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.ConfigureSwagger();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapWeatherForecastEndpoints();
            app.MapUserEndpoints();
            app.MapDogEndpoints();

            app.Run();
        }
    }
}
