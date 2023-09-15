using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.UseCase.Exceptions;

namespace Karami.UseCase.SignInUseCase.Commands.Create;

public class SignInCommandValidator : IValidator<SignInCommand>
{
    public async Task<object> ValidateAsync(SignInCommand input, CancellationToken cancellationToken)
    {
        await Task.Run(() => {

            if(string.IsNullOrEmpty(input.Username))
                throw new UseCaseException("فیلد نام کاربری الزامی می باشد !");
           
            if(string.IsNullOrEmpty(input.Password))
                throw new UseCaseException("فیلد رمز عبور الزامی می باشد !");
            
        });

        return default;
    }
}