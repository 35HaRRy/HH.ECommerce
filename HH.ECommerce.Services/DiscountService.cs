using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Entities;
using HH.ECommerce.Services.Contracts;

namespace HH.ECommerce.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepositoryManager _repository;

        public DiscountService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<List<Discount>> GetAllDiscounts()
        {
            var discounts = await _repository.Discount.GetAllDiscounts(trackChanges: false);
            return discounts;
        }

        public async Task<string?> GetDiscount(string type)
        {
            var discount = await _repository.Discount.GetDiscountPercentageByType(type, trackChanges: false);
            if (discount != null)
            { 
                var discountPercentage = _repository.Discount.GetDiscountPercentage(discount);
                if (discountPercentage != null)
                    return discountPercentage;
            }

            return null;
        }

        public async Task<Discount> CreateDiscount(Discount discount)
        {
            _repository.Discount.CreateDiscount(discount);
            await _repository.SaveAsync();

            return discount;
        }
    }
}