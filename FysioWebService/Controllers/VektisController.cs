using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Core.DomainServices;

namespace FysioWebService.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class VektisController : Controller
    {
        private readonly ILogger<VektisController> _logger;
        private readonly IVektisRepository _vektisRepository;

        public VektisController(ILogger<VektisController> logger, IVektisRepository vektisRepository)
        {
            _logger = logger;
            _vektisRepository = vektisRepository;
        }

        [HttpGet]
        public IEnumerable<Core.Domain.Vektis> Get()
        {
            return _vektisRepository.GetAllList();
        }
    }
}
