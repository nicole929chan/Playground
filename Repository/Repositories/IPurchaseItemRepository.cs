using Repository.Entities;

namespace Repository.Repositories;
public interface IPurchaseItemRepository
{
    //Task<List<PurchaseItem>> GetAllAsync();
    //Task<PurchaseItem?> GetByIdAsync(int id);
    Task CreateAsync(List<PurchaseItem> purchaseItems);
    //Task<int> UpdateAsync(PurchaseItem purchaseItem);
    //Task<int> DeleteAsync(int id);
}
