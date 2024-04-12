namespace Service.Services.Cart.Availibility;
public abstract class AvailabilityFeature : IAvailabilityService
{
    protected readonly IAvailabilityService _service;
    protected bool isAvailable = false;

    public AvailabilityFeature(IAvailabilityService service)
    {
        _service = service;
    }
    public abstract Task<bool> IsAvailableAsync(int productId, int quantity);
}
