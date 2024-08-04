using AutoMapper;
using Data.DTOs.OfferDTOs;
using Data.DTOs.Other;
using GazpromTestProject.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GazpromTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController(
        IOfferService offerService,
        IMapper mapper) : ControllerBase
    {
        private readonly IOfferService _offerService = offerService;
        private readonly IMapper _mapper = mapper;


        [HttpGet("by-filter")]
        public async Task<IActionResult> GetByFilter([FromQuery] SearchQuery query)
        {
            var offers = await _offerService.SortByFilterAsync(query);

            var offersDTOs = offers.Select(o => _mapper.Map<OfferGetDTO>(o)).ToList();
            return Ok(new { offersDTOs, offersDTOs.Count });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var offer = await _offerService.GetOfferByIdAsync(id);
            if (offer == null) return NotFound("Оффер не найден");

            return Ok(_mapper.Map<OfferGetDTO>(offer));
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfferCreateDTO model)
        {
            try
            {
                var offer = await _offerService.CreateOfferAsync(model);
                return CreatedAtAction(nameof(Get), new { id = offer.Id }, _mapper.Map<OfferGetDTO>(offer));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
