using Service.Dtos;

namespace Service.Services;
public interface IPurchaseService
{
    Task CreatePurchaseAsync(PurchaseCreate purchaseCreate);
    Task<PurchaseResult?> GetPurchaseByIdAsync(int id);
    //Task<List<PurchaseResult>> GetPurchasesAsync();
    //Task<PurchaseResult> UpdatePurchaseAsync(int id, PurchaseDto purchaseDto);
    //Task DeletePurchaseAsync(int id);
}
