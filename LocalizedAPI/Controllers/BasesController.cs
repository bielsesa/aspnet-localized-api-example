using Microsoft.AspNetCore.Mvc;
using dir.masterpan_erp.Bases;

namespace dir.masterpan_erp.Controllers
{
    [ApiController]
    [Route("api/bases")]
    public class BasesController : ControllerBase
    {
        private readonly ILogger<BasesController> _logger;
        private readonly BasesService _service;

        public BasesController(ILogger<BasesController> logger, BasesService service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // POST api/bases/string
        [HttpPost("string")]
        public string GetAsString(Base baseObject)
        {
            _logger.LogInformation($"api/bases POST string");
            return _service.GetBaseAsString(baseObject);
        }
    }
}
