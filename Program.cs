
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using NotifiTime_API.domain.Interfaces;
using NotifiTime_API.infrastructure.repositories;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace NotifiTime_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Definir política CORS
            IServiceCollection serviceCollection = builder.Services.AddCors(options =>
            {
                options.AddPolicy("PermitirAngular",
                    policy =>
                    {
                        Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder corsPolicyBuilder = policy.WithOrigins("http://localhost:4200") // URL de tu frontend Angular
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            // Usar la política CORS
            app.UseCors("PermitirAngular");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Usar rutas para API
            app.UseRouting();

            app.UseAuthorization(); // si usas autenticación

            app.MapControllers(); // Esto expone los endpoints

            app.Run();
        }
    }
}
