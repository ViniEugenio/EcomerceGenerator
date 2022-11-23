using EcommerceGenarator.Api.Filters;

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

            app.UseExceptionHandler("/error/500");
            app.UseStatusCodePagesWithRedirects("/error/{0}");

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
