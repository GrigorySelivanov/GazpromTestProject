using AutoMapper;
using Data.DTOs.ProviderDTOs;
using GazpromTestProject.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GazpromTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController(
        IProviderService providerService,
        IMapper mapper) : ControllerBase
    {
        private readonly IProviderService _providerService = providerService;
        private readonly IMapper _mapper = mapper;


        [HttpGet("popular")]
        public async Task<IActionResult> GetPopular()
        {
            var providers = await _providerService.GetPopular();
            var providersDTOs = providers.Select(p => _mapper.Map<PopularProviderGetDTO>(p)).ToList();
            return Ok(providersDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var offer = await _providerService.GetProviderByIdAsync(id, isTraking: false);
            if (offer == null) return NotFound("Поставщик не найден");

            return Ok(_mapper.Map<ProviderGetDTO>(offer));
        }

        [HttpPost]
        public IActionResult Create(ProviderCreateDTO model)
        {
            var provider = _providerService.CreateProvider(model);
            return CreatedAtAction(nameof(Get), new { id = provider.Id }, _mapper.Map<ProviderGetDTO>(provider));
        }
    }
}
