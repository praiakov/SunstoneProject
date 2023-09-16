using Microsoft.AspNetCore.Mvc;
using Sunstone.Application;
using Sunstone.Domain;

namespace Sunstone.Api.Controllers
{
    [ApiController]
    public class GemstoneController : ControllerBase
    {
        private readonly ICreateGemstoneUseCase _createGemstoneUseCase;
        private readonly IGetGemstoneListUseCase _getGemstoneListUseCase;

        public GemstoneController(ICreateGemstoneUseCase createGemstoneUseCase, IGetGemstoneListUseCase getGemstoneListUseCase)
        {
            _createGemstoneUseCase = createGemstoneUseCase;
            _getGemstoneListUseCase = getGemstoneListUseCase;
        }

        [HttpPost("gemstone")]
        public async Task<IActionResult> CreateGemstone([FromBody] CreateInputModel gemstone)
        {
            var id = await _createGemstoneUseCase.CreateGemstone(gemstone);

            return Ok(new CreateViewModel(id));
        }

        [HttpGet("gemstones")]
        public Task<IEnumerable<Gemstone>> GetGemstoneList() => _getGemstoneListUseCase.GetGemstones();

    }
}
