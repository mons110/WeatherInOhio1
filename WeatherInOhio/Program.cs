using Domain.Interfaces;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace WeatherInOhio
{
    public class Program
    {
        // task5 стр6 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<InternetShopContext>(
                optionsAction: options => options.UseSqlServer(connectionString: "Server = SKELETAL-COMPUT;Database = InternetShop; Trusted_Connection = True; Encrypt = False;"));
            builder.Services.AddDbContext<InternetShopContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("InternetShopContext"),
        option => option.MigrationsAssembly("DataAccess")
    )
);
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                   Title = "Интернет-магазин Gustavo Fring",
                    Description = "Welcome to ",
                    Contact = new OpenApiContact
                    {
                        Name = "Пример контакта",
                        Url = new Uri("https://ru.wikipedia.org/wiki/%D0%93%D1%83%D1%81_%D0%A4%D1%80%D0%B8%D0%BD%D0%B3#:~:text=%D0%93%D1%83%D1%81%D1%82%D0%B0%D0%B2%D0%BE%20%C2%AB%D0%93%D1%83%D1%81%C2%BB%20%D0%A4%D1%80%D0%B8%D0%BD%D0%B3%20(%D0%B0%D0%BD%D0%B3%D0%BB.%20Gustavo,%D0%B5%D0%B3%D0%BE%20%D0%BF%D1%80%D0%B8%D0%BA%D0%B2%D0%B5%D0%BB%D0%B0%20%C2%AB%D0%9B%D1%83%D1%87%D1%88%D0%B5%20%D0%B7%D0%B2%D0%BE%D0%BD%D0%B8%D1%82%D0%B5%20%D0%A1%D0%BE%D0%BB%D1%83%C2%BB")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Пример лицензии",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}