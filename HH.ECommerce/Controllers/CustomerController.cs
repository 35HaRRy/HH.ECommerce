using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using HH.ECommerce.Entities;
using HH.ECommerce.Entities.DTOs;
using HH.ECommerce.Services.Contracts;

namespace HH.ECommerce.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();
            var customerDto = _mapper.Map<List<CustomerDto>>(customers);

            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomers([FromBody] CreateCustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = _mapper.Map<Customer>(customerDto);
            await _customerService.CreateCustomer(customer); 

            var customerToReturn = _mapper.Map<CustomerDto>(customer);
            return CreatedAtRoute(
                "CustomerId",
                new
                {
                    Id = customerToReturn.CustomerId
                },
                customerToReturn
            ); 
        }

        [HttpGet("{Id:int}", Name = "CustomerId")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            var customer = await _customerService.GetCustomerById(Id);
            if (customer == null)
                return NotFound();

            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var customer = await _customerService.GetCustomerByName(name.Trim().ToLower());
            if (customer == null)
                return NotFound();

            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }
    }
}
