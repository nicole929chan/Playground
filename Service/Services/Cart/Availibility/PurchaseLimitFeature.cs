namespace Service.Services.Cart.Availibility;

/// <summary>
/// 購買次數限制
/// </summary>
public class PurchaseLimitFeature : AvailabilityFeature
{
    public PurchaseLimitFeature(IAvailabilityService service) : base(service)
    {
    }
    public override async Task<bool> IsAvailableAsync(int productId, int quantity)
    {
        try
        {
            // 如何讀到訂單(客戶)及其購買品項

            bool purchased = false;


            if (!purchased)
            {
                isAvailable = await _service.IsAvailableAsync(productId, quantity);
            }
            else
            {
                throw new Exception("商品限制購買一次");
            }

            return await Task.FromResult(isAvailable);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }
}
