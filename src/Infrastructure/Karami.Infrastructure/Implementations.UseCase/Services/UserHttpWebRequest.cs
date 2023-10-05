using System.Net.Http.Headers;
using System.Text;
using Karami.Core.Infrastructure.Extensions;
using Karami.UseCase.UserUseCase.Commands.Create;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.HTTPs.SignIn;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class UserHttpWebRequest : IUserHttpWebRequest
{
    private readonly HttpClient _httpClient;
    
    public UserHttpWebRequest()
    {
        _httpClient = new HttpClient(new HttpClientHandler());
    }
    
    public async Task<SignInResponse> SignInAsync(SignInCommand command, CancellationToken cancellationToken)
    {
        var payload = new StringContent(command.Serialize(), Encoding.UTF8, "application/json");
        
        var request =
            await _httpClient.PatchAsync("http://localhost:5000/api/v1/user/signin", payload, cancellationToken);

        var result = await request.Content.ReadAsStringAsync(cancellationToken);

        return result.DeSerialize<SignInResponse>();
    }

    public void Dispose() => _httpClient.Dispose();
}