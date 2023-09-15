using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

namespace Karami.UseCase.SignInUseCase.Commands.Create;

public class SignInCommand : ICommand<SignInResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}