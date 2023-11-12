using FluentValidation;

namespace Model.Trello.Application.UseCases.User.CreateUser
{
    public class CreateUserValidation : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidation() 
        {
            RuleFor(x => x.Password).NotEmpty().NotNull();

            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
