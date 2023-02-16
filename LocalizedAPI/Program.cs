using dir.masterpan_erp.Bases;
using dir.masterpan_erp.Comunes;
using dir.masterpan_erp.Controllers;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace dir.masterpan_erp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services Configuration
            builder.Services.AddControllers();

            builder.Services.ConfigureLocalization();
            builder.Services.ConfigureHttpContextAccessor();
            builder.Services.ConfigureDomainServices();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            #endregion Services Configuration

            #region App Build
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            };

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            #endregion App Build
            
            app.Run();
        }
    }
}