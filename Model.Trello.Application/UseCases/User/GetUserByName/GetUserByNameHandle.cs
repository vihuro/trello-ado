using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.User.GetUserByName
{
    public class GetUserByNameHandle :
        IRequestHandler<GetUserByNameRequest, GetUserByNameResponse>
    {
        private readonly IUnitOfWorkADO _unitOfWorkADO;
        private readonly IUserEntityRepositoryADO _userEntityRepositoryADO;
        private readonly IMapper _mapper;

        public GetUserByNameHandle(IUnitOfWorkADO unitOfWorkADO, 
                                    IUserEntityRepositoryADO userEntityRepositoryADO, 
                                    IMapper mapper)
        {
            _unitOfWorkADO = unitOfWorkADO;
            _userEntityRepositoryADO = userEntityRepositoryADO;
            _mapper = mapper;
        }

        public async Task<GetUserByNameResponse> Handle(GetUserByNameRequest request, CancellationToken cancellationToken)
        {
            _unitOfWorkADO.BeginTrasaction();

            var entity = await _userEntityRepositoryADO.GetUserByName(request.Name);

            return _mapper.Map<GetUserByNameResponse>(entity);
        }
    }
}
