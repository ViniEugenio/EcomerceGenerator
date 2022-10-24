using EcommerceGenarator.Api.Filters;

namespace EcommerceGenarator.Api.Configurations
{
    public static class FiltersConfiguration
    {

        public static void ConfigureFilters(this IServiceCollection services)
        {

            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidationFilter());
            });

        }

    }
}
