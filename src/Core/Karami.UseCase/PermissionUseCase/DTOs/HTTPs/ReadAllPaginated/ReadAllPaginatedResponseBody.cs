using Karami.Core.Common.ClassHelpers;
using Karami.UseCase.UserUseCase.DTOs.ViewModels;

namespace Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<PermissionsViewModel> Permissions { get; set; }
}