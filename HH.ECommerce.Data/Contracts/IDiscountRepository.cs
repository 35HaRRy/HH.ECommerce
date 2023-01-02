using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Contracts
{
    public interface IDiscountRepository
    {
        Task<List<Discount>> GetAllDiscounts(bool trackChanges);
        Task<Discount?> GetDiscountPercentageByType(string type, bool trackChanges);
        void CreateDiscount(Discount discount);
        string? GetDiscountPercentage(Discount discount);
    }
}
