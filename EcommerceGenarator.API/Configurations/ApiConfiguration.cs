using EcommerceGenarator.Api.Filters;
using EcommerceGenerator.Application.Validations.Client;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace EcommerceGenarator.Api.Configurations
{
    public static class ApiConfiguration
    {

        public static void ApiConfigure(this IServiceCollection services)
        {

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public static void ApiConfigureBuild(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

        }

    }
}
