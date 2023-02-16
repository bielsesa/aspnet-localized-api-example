using dir.masterpan_erp.Extensions;
using dir.masterpan_erp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace dir.masterpan_erp.Comunes
{
    public class ComunesService : IComunesService
    {
        private readonly ILogger<ComunesService> _logger;
        private readonly ComunesLocalizationService _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComunesService(ILogger<ComunesService> logger,
                            ComunesLocalizationService localizer,
                            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Returns a Comun object in a human-readable string, in the corresponding CultureName
        /// </summary>
        /// <param name="comunObject"></param>
        /// <returns></returns>
        public string GetComunAsString(Comun comunObject)
        {
            _logger.LogDebug($"GetComunAsString from ComunesService, Base: {comunObject}");

            string result = string.Empty;

            // TODO: Set CultureScope in a higher level, and also use Query.GetCultureInfo to get
            //       the culture names from BusinessCultureName and UserCultureName from query string
            using (new CultureScope(_httpContextAccessor.HttpContext.Request.Headers.GetCultureInfo()))
            {
                result = _localizer["ComunString",
                                     comunObject.Name,
                                     comunObject.Quantity,
                                     comunObject.Value,
                                     comunObject.Quantity * comunObject.Value];
            }

            return result;
        }

        public string GetComunCreationDate(Comun comunObject)
        {
            _logger.LogDebug($"GetComunAsString from ComunesService, Base: {comunObject}");

            string result = string.Empty;

            // TODO: Set CultureScope in a higher level, and also use Query.GetCultureInfo to get
            //       the culture names from BusinessCultureName and UserCultureName from query string
            using (new CultureScope(_httpContextAccessor.HttpContext.Request.Headers.GetCultureInfo()))
            {
                result = _localizer["ComunCreationDate",
                                     DateTime.Today.AddDays(-2),
                                     comunObject.Name];
            }

            return result;
        }
    }
}

