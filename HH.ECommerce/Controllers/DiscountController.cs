using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using HH.ECommerce.Entities;
using HH.ECommerce.Entities.DTOs;
using HH.ECommerce.Services.Contracts;

namespace HH.ECommerce.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var discounts = await _discountService.GetAllDiscounts();
            var discountsDto = _mapper.Map<List<DiscountDto>>(discounts);

            return Ok(discountsDto);
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetDiscount(string type)
        {
            var discount = await _discountService.GetDiscount(type);
            if (discount == null)
                return NotFound();

            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto discountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var discount = _mapper.Map<Discount>(discountDto);
            await _discountService.CreateDiscount(discount);

            return Ok();
        }
    }
}
