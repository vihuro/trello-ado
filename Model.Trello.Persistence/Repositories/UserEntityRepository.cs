

using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;

namespace Model.Trello.Persistence.Repositories
{
    public class UserEntityRepository : BaseRepository<UserEntity>, IUserEntityRepository
    {
        public UserEntityRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateUser(UserEntity user)
        {
            Context.Users.Add(user);
        }
    }
}
