using Microsoft.EntityFrameworkCore;

using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Entities;

namespace HH.ECommerce.Data.Repositories
{
    public class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationContext context) : base(context) { }

        public void CreateDiscount(Discount discount) => Create(discount);

        public string? GetDiscountPercentage(Discount discount)
        {
            if (discount.IsRatePercentage)
                return $"{discount.Rate}%";

            return null;
        }

        public async Task<List<Discount>> GetAllDiscounts(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(d => d.Name)
            .ToListAsync();

        public async Task<Discount?> GetDiscountPercentageByType(string type, bool trackChanges) => await FindByCondition(
            d => d.Type
                .Trim()
                .ToLower()
                .Equals(type.Trim().ToLower()),
            trackChanges
        )
        .SingleOrDefaultAsync();
    }
}
