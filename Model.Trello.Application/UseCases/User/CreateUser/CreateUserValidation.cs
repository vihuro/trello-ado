using FluentValidation;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.User.CreateUser
{
    public class CreateUserValidation : AbstractValidator<CreateUserRequest>
    {
        private readonly IUnitOfWorkADO _unitOfWork;
        private readonly IUserEntityRepositoryADO _userEntityRepositoryADO;

        public CreateUserValidation(IUnitOfWorkADO unitOfWork, 
                                    IUserEntityRepositoryADO userEntityRepositoryADO) 
        {
            _unitOfWork = unitOfWork;
            _userEntityRepositoryADO = userEntityRepositoryADO;

            RuleFor(x => x.Password).NotEmpty().NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                .MustAsync(ValidateName)
                .WithMessage("Username registered!");
        }

        private async Task<bool> ValidateName(CreateUserRequest request, CancellationToken token)
        {
            using var unit = _unitOfWork.BeginTrasaction();

            var user = await _userEntityRepositoryADO.GetUserByName(request.Name);

            if (user == null) return true;



            return false;
        }


    }
}
