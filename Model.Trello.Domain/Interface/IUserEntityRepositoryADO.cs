using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface IUserEntityRepositoryADO
    {
        public Task<UserEntity> AddUser(UserEntity entity);
    }
}
