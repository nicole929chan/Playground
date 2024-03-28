using Repository.Repositories;
using Service.Dtos;

namespace Service.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IPriceLogService _priceLogService;

    public ProductService(IProductRepository productRepository, IPriceLogService priceLogService)
    {
        _productRepository = productRepository;
        _priceLogService = priceLogService;
    }
    public async Task<ProductResult?> GetByIdAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return new ProductResult
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

        }
        catch (Exception ex)
        {
            throw new Exception("Error in ProductService.GetByIdAsync", ex);

        }
    }

    public async Task<int> UpdateAsync(ProductUpdate product)
    {
        try
        {
            var entity = await _productRepository.GetByIdAsync(product.Id);
            if (entity == null)
            {
                throw new Exception("Product not found");
            }

            //IsWritable handler = HasChanged;
            //bool changed = handler((decimal)entity.Price, (decimal)product.Price);
            //if (changed)
            //{
            //    var princeLog = _priceLogService.MakePriceLog(product.Id, 1, (decimal)entity.Price, (decimal)product.Price, "Price changed");
            //    await _priceLogService.AddAsync(princeLog);
            //}

            entity.Name = product.Name;
            entity.Price = product.Price;
            entity.Description = product.Description;
            entity.IsDeleted = (bool)product.IsDeleted;
            entity.UpdatedAt = product.UpdatedAt;

            var result = await _productRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in ProductService.UpdateAsync", ex);
        }
    }

    //private bool HasChanged(decimal oldPrice, decimal newPrice)
    //{
    //    return oldPrice != newPrice;
    //}

    //public delegate bool IsWritable(decimal oldPrice, decimal newPrice);
}
