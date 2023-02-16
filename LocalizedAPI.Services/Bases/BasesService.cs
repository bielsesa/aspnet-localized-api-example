using dir.masterpan_erp.Extensions;
using dir.masterpan_erp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace dir.masterpan_erp.Bases
{
    public class BasesService : IBasesService
    {
        private readonly ILogger<BasesService> _logger;
        private readonly BasesLocalizationService _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasesService(ILogger<BasesService> logger,
                            BasesLocalizationService localizer,
                            IHttpContextAccessor httpContextAccessor) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Returns a Base object in a human-readable string, in the corresponding CultureName
        /// </summary>
        /// <param name="baseObject"></param>
        /// <returns></returns>
        public string GetBaseAsString(Base baseObject)
        {
            _logger.LogDebug($"GetComunAsString from BasesService, Base: {baseObject}");

            string result = string.Empty;

            // TODO: Set CultureScope in a higher level, and also use Query.GetCultureInfo to get
            //       the culture names from BusinessCultureName and UserCultureName from query string
            using (new CultureScope(_httpContextAccessor.HttpContext.Request.Headers.GetCultureInfo()))
            {
                result = _localizer["BaseString",
                                  baseObject.Name,
                                  baseObject.Color,
                                  baseObject.Description];                
            }

            return result;
        }
    }
}