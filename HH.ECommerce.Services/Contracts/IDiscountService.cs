using HH.ECommerce.Entities;

namespace HH.ECommerce.Services.Contracts
{
    public interface IDiscountService
    {
        Task<List<Discount>> GetAllDiscounts();
        Task<string?> GetDiscount(string type);
        Task<Discount> CreateDiscount(Discount discount);
    }
}