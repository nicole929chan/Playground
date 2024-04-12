namespace Service.Services.Cart.Availibility;
public interface IAvailabilityService
{
    Task<bool> IsAvailableAsync(int productId, int quantity);
}
