namespace HH.ECommerce.Data.Contracts
{
    public interface IRepositoryManager
    { 
        IDiscountRepository Discount { get; }
        IInvoiceRepository Invoice { get; }
        ICustomerRepository Customer { get; }

        Task SaveAsync(); 
    }
}
