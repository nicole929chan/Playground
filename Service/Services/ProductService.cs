using Repository.Repositories;
using Service.Dtos;

namespace Service.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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
}
