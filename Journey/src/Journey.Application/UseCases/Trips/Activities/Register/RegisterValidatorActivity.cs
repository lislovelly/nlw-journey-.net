using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Activities.Register
{
    public class RegisterValidatorActivity : AbstractValidator<RequestRegisterActivityJson>
    {
        public RegisterValidatorActivity()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(ResourceErrorMessage.NAME_EMPTY);
        }
    }
}