using AutoMapper;
using MediatR;
using Model.Trello.Domain.Interface;

namespace Model.Trello.Application.UseCases.User.GetAllUser
{
    public class GetAllUserhandle :
            IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
    {
        private readonly IUserEntityRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserhandle(IUserEntityRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var listUsers = await _userRepository.GetList(cancellationToken);

            return _mapper.Map<List<GetAllUserResponse>>(listUsers);
        }
    }
}
