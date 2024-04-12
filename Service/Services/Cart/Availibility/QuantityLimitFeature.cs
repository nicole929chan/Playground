namespace Service.Services.Cart.Availibility;

/// <summary>
/// 購買數量限制
/// </summary>
public class QuantityLimitFeature : AvailabilityFeature
{
    public QuantityLimitFeature(IAvailabilityService service) : base(service)
    {
    }
    public override async Task<bool> IsAvailableAsync(int productId, int quantity)
    {
        try
        {
            var limitation = new Dictionary<int, int>
            {
                { 1, 10 },
                { 2, 20 },
                { 3, 0 }
            };

            int limit = limitation.ContainsKey(productId) ? limitation[productId] : 0;

            if (limit == 0 || quantity <= limit)
            {
                isAvailable = await _service.IsAvailableAsync(productId, quantity);
            }
            else
            {
                throw new Exception(string.Format("超過購買數量限制:{0}", limit));
            }

            return await Task.FromResult(isAvailable);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }
}
