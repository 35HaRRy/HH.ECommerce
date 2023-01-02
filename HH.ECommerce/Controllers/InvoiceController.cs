using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;
    
using HH.ECommerce.Entities;
using HH.ECommerce.Entities.DTOs;
using HH.ECommerce.Services.Contracts;

namespace HH.ECommerce.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpGet("{billNumber}")]
        public async Task<IActionResult> GetInvoice(string billNumber)
        {
            if (billNumber == null)
                return BadRequest();

            var invoice = await _invoiceService.GetInvoice(billNumber);
            if (invoice == null) 
                return NotFound();

            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);
            return Ok(invoiceDto.Total);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateInvoiceForACustomer(int customerId, [FromBody] CreateInvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            var discountedSubTotal = await _invoiceService.GenerateInvoiceForACustomer(customerId, invoice);

            return discountedSubTotal.HasValue ? Ok() : NotFound();
        }
    }
}
