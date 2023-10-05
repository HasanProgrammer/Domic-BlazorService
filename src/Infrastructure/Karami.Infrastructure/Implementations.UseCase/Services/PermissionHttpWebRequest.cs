using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class PermissionHttpWebRequest : IPermissionHttpWebRequest
{
    private readonly HttpClient  _httpClient;
    private readonly IRedisCache _redisCache;
    
    public PermissionHttpWebRequest(IRedisCache redisCache)
    {
        _httpClient = new HttpClient(new HttpClientHandler());
        _redisCache = redisCache;
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery query, 
        CancellationToken cancellationToken
    )
    {
        var url = $"http://localhost:5000/api/v1/permission/read-all-paginated?" +
                  $"PageNumber{query.PageNumber}&CountPerPage={query.CountPerPage}";
        
        if(_httpClient.DefaultRequestHeaders.Authorization is null)
            _httpClient.DefaultRequestHeaders.Add("Authorization",
                $"Bearer {_redisCache.GetCacheValue(query.CurrentUser)}"
            );
        
        var request = await _httpClient.GetAsync(url, cancellationToken);

        var result = await request.Content.ReadAsStringAsync(cancellationToken);

        return result.DeSerialize<ReadAllPaginatedResponse>();
    }

    public void Dispose() => _httpClient.Dispose();
}