using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

namespace Karami.UseCase.SignInUseCase.Commands.Create;

public class SignInCommandHandler : ICommandHandler<SignInCommand, SignInResponse>
{
    private readonly IUserHttpWebRequest _userHttpWebRequest;

    public SignInCommandHandler(IUserHttpWebRequest userHttpWebRequest) 
        => _userHttpWebRequest = userHttpWebRequest;
    
    [WithValidation]
    public async Task<SignInResponse> HandleAsync(SignInCommand command, CancellationToken cancellationToken) 
        => await _userHttpWebRequest.SignInAsync(command, cancellationToken);
}