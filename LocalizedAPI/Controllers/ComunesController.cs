using Microsoft.AspNetCore.Mvc;
using dir.masterpan_erp.Comunes;
using Microsoft.Extensions.Localization;

namespace dir.masterpan_erp.Controllers
{
    [ApiController]
    [Route("api/comunes")]
    public class ComunesController : ControllerBase
    {
        private readonly ILogger<ComunesController> _logger;
        private readonly ComunesService _service;

        public ComunesController(ILogger<ComunesController> logger, ComunesService service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // POST api/comunes/string
        [HttpPost("string")]
        public string GetAsString(Comun comun)
        {
            _logger.LogInformation($"api/comunes POST string");
            return _service.GetComunAsString(comun);
        }

        // POST api/comunes/creation-date
        [HttpPost("creation-date")]
        public string GetComunCreationDate(Comun comun)
        {
            _logger.LogInformation($"api/comunes POST creation-date");
            return _service.GetComunCreationDate(comun);
        }
    }
}
