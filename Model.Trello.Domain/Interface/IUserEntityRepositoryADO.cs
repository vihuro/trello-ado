using Model.Trello.Domain.Entities;

namespace Model.Trello.Domain.Interface
{
    public interface IUserEntityRepositoryADO
    {
        Task<UserEntity> AddUser(UserEntity entity);
        Task<List<UserEntity>> GetAllUsers();
        Task<UserEntity> GetUserByName(string name);
    }
}
