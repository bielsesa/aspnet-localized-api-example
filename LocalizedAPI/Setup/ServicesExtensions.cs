using dir.masterpan_erp.Bases;
using dir.masterpan_erp.Comunes;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace dir.masterpan_erp
{
    public static class ServicesExtensions
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<BasesService>();
            services.AddScoped<ComunesService>();
        }

        public static void ConfigureHttpContextAccessor(this IServiceCollection services) 
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("es-Es"),
                    new CultureInfo("es"),
                    new CultureInfo("en-Us"),
                    new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "es", uiCulture: "es");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
            });

            services.AddSingleton<BasesLocalizationService>();
            services.AddSingleton<ComunesLocalizationService>();
        }
    }
}
