using Karami.UseCase.Commons.DTOs.HTTPs;

namespace Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

public class SignInResponse : BaseResponse
{
    public SignInResponseBody Body { get; set; }
}