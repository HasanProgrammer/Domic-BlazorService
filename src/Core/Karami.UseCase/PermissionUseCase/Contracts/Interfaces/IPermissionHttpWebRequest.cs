using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.SignInUseCase.Commands.Create;
using Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

namespace Karami.UseCase.UserUseCase.Contracts.Interfaces;

public interface IPermissionHttpWebRequest : IHttpWebRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<SignInResponse> ReadAllPaginatedAsync(SignInCommand command, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
}