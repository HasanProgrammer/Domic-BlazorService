using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

namespace Karami.UseCase.UserUseCase.Contracts.Interfaces;

public interface IPermissionHttpWebRequest : IHttpWebRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
}