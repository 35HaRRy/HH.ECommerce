using AutoMapper;

using HH.ECommerce.Entities;
using HH.ECommerce.Entities.DTOs;

namespace HH.ECommerce.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(
                    customerCustomerDto => customerCustomerDto.FullName,
                    option => option.MapFrom(customer => string.Join(" ", customer.LastName, customer.MiddleName, customer.FirstName))
                )
                .ForMember(
                    customerCustomerDto => customerCustomerDto.JoinedIn,
                    option => option.MapFrom(c => c.DateCreated.HasValue ? c.DateCreated.Value.ToLongDateString() : "")
                );
                
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<Discount, DiscountDto>();

            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<CreateDiscountDto, Discount>();
        }
    }
}
