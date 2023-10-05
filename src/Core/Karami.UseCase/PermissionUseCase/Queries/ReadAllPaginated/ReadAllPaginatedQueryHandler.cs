using Karami.Core.Common.ClassHelpers;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.ViewModels;

namespace Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryHandler :
    IQueryHandler<ReadAllPaginatedQuery, PaginatedCollection<PermissionsViewModel>>
{
    private readonly IPermissionHttpWebRequest _httpWebRequest;

    public ReadAllPaginatedQueryHandler(IPermissionHttpWebRequest httpWebRequest)
    {
        _httpWebRequest = httpWebRequest;
    }

    public async Task<PaginatedCollection<PermissionsViewModel>> HandleAsync(ReadAllPaginatedQuery query, 
        CancellationToken cancellationToken
    )
    {
        var result = await _httpWebRequest.ReadAllPaginatedAsync(query, cancellationToken);

        return result.Body.Permissions;
    }
}