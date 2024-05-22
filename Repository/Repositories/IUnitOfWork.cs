using Repository.Entities;

namespace Repository.Repositories;
public interface IUnitOfWork
{
    Task SaveChangesAsync(Purchase purchase, IEnumerable<PurchaseItem> purchaseItem);
}
