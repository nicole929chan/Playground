using Repository.Entities;
using Repository.Repositories;
using Service.Dtos;

namespace Service.Services;
public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IPurchaseItemRepository _purchaseItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PurchaseService(IPurchaseRepository purchaseRepository, IPurchaseItemRepository purchaseItemRepository, IUnitOfWork unitOfWork)
    {
        _purchaseRepository = purchaseRepository;
        _purchaseItemRepository = purchaseItemRepository;
        _unitOfWork = unitOfWork;

    }
    public async Task<PurchaseResult?> GetPurchaseByIdAsync(int id)
    {
        try
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
            {
                return null;
            }

            return new PurchaseResult
            {
                Id = purchase.Id,
                PurchaseNumber = purchase.PurchaseNumber,
                PurchaseDate = purchase.PurchaseDate,
                VendorId = purchase.VendorId,
                TotalAmount = purchase.TotalAmount,
                PurchaseItems = purchase.PurchaseItems.Select(pi => new PurchaseItemResult
                {
                    Id = pi.Id,
                    PurchaseId = pi.PurchaseId,
                    ProductId = pi.ProductId,
                    Quantity = pi.Quantity,
                    Price = pi.Price,
                    Amount = pi.Amount,
                    CreatedAt = pi.CreatedAt,
                    UpdatedAt = pi.UpdatedAt
                }).ToList(),
                CreatedAt = purchase.CreatedAt,
                UpdatedAt = purchase.UpdatedAt
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //public async Task CreatePurchaseAsync(PurchaseCreate purchaseCreate)
    //{
    //    using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
    //    try
    //    {
    //        var purchaseId = 0;
    //        var purchaseItems = new List<PurchaseItem>();
    //        var purchase = new Purchase
    //        {
    //            PurchaseNumber = "ABC-123",
    //            PurchaseDate = purchaseCreate.PurchaseDate,
    //            VendorId = purchaseCreate.VendorId,
    //            Status = "Draft",
    //            TotalAmount = purchaseCreate.PurchaseItems.Sum(pi => pi.Quantity * pi.Price),
    //            CreatedAt = DateTime.Now,
    //            UpdatedAt = DateTime.Now
    //        };

    //        purchaseId = await _purchaseRepository.CreateAsync(purchase);

    //        foreach (var pi in purchaseCreate.PurchaseItems)
    //        {
    //            var purchaseItem = new PurchaseItem
    //            {
    //                PurchaseId = purchaseId,
    //                ProductId = pi.ProductId,
    //                Sku = pi.Sku,
    //                Quantity = pi.Quantity,
    //                Price = pi.Price,
    //                Amount = pi.Quantity * pi.Price,
    //                CreatedAt = DateTime.Now,
    //                UpdatedAt = DateTime.Now
    //            };

    //            purchaseItems.Add(purchaseItem);

    //        }

    //        await _purchaseItemRepository.CreateAsync(purchaseItems);

    //        transaction.Complete();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    public async Task CreatePurchaseAsync(PurchaseCreate purchaseCreate)
    {
        var purchase = new Purchase
        {
            PurchaseNumber = "XYZ-123",
            PurchaseDate = purchaseCreate.PurchaseDate,
            VendorId = purchaseCreate.VendorId,
            Status = "Draft",
            TotalAmount = purchaseCreate.PurchaseItems.Sum(pi => pi.Quantity * pi.Price),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        var purchaseItems = purchaseCreate.PurchaseItems.Select(pi => new PurchaseItem
        {
            ProductId = pi.ProductId,
            Sku = pi.Sku,
            Quantity = pi.Quantity,
            Price = pi.Price,
            Amount = pi.Quantity * pi.Price,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }).ToList();

        purchase.PurchaseItems = purchaseItems;

        await _unitOfWork.SaveChangesAsync(purchase);
    }
}
