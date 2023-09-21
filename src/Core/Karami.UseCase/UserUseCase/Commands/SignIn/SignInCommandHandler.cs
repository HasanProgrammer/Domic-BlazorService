using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

namespace Karami.UseCase.SignInUseCase.Commands.Create;

public class SignInCommandHandler : ICommandHandler<SignInCommand, SignInResponse>
{
    private readonly IRedisCache         _redisCache;
    private readonly IJsonWebToken       _jsonWebToken;
    private readonly IUserHttpWebRequest _userHttpWebRequest;

    public SignInCommandHandler(IUserHttpWebRequest userHttpWebRequest, IRedisCache redisCache, 
        IJsonWebToken jsonWebToken
    )
    {
        _redisCache         = redisCache;
        _jsonWebToken       = jsonWebToken;
        _userHttpWebRequest = userHttpWebRequest;
    }

    [WithValidation]
    public async Task<SignInResponse> HandleAsync(SignInCommand command, CancellationToken cancellationToken)
    {
        var response = await _userHttpWebRequest.SignInAsync(command, cancellationToken);

        if (response.Code == 200)
        {
            var currentUser = _jsonWebToken.GetUsername(response.Body.Token);
            var securityKey = Guid.NewGuid().ToString();

            _redisCache.SetCacheValue(new KeyValuePair<string, string>(currentUser, securityKey));

            response.Body.SecurityKey = securityKey;
        }

        return response;
    }
}