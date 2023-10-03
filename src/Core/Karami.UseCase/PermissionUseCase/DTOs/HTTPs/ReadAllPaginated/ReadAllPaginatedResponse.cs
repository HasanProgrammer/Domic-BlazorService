using Karami.UseCase.Commons.DTOs.HTTPs;

namespace Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}