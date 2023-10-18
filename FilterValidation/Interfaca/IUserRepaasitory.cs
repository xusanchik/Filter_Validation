using FilterValidation.Entities;
using FilterValidation.Dto_s;

namespace FilterValidation.Interfaca
{
    public interface IUserRepaasitory
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task UpdateUser(int id, User userDto);
        Task <User>CreateUser(UserDto userDto);
        Task DeleteUser(int id);
    }
}