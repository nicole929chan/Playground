namespace WebApi.GitHub.Api;

public class GitHubService
{
    private readonly IHttpClientFactory _factory;

    public GitHubService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<GitHubUser?> GetUserAsync(string username)
    {
        try
        {
            var client = _factory.CreateClient("github");

            GitHubUser? user = await client
                .GetFromJsonAsync<GitHubUser>($"users/{username}");

            return user;
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException("Failed to get user", ex);
        }
    }
}
