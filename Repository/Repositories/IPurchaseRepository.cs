using Repository.Entities;

namespace Repository.Repositories;
public interface IPurchaseRepository
{
    //Task<List<Purchase>> GetAllAsync();
    Task<Purchase?> GetByIdAsync(int id);
    Task<int> CreateAsync(Purchase purchase);
    //Task<int> UpdateAsync(Purchase purchase);
    //Task<int> DeleteAsync(int id);
}
