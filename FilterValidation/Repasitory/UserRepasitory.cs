using FilterValidation.Data;
using FilterValidation.Dto_s;
using FilterValidation.Entities;
using FilterValidation.Interfaca;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FilterValidation.Repasitory;
public class UserRepasitory : IUserRepaasitory
{
    private readonly AppDbContext _appDbContext;
    public UserRepasitory(AppDbContext appDbContext) => _appDbContext = appDbContext;
    public async Task<User> CreateUser(UserDto userDto)
    {
        var user = userDto.Adapt<User>();
        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();
        return user;
    }


    public async Task DeleteUser(int id)
    {
        var getid = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        _appDbContext.Users.Remove(getid);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _appDbContext.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        var getid= await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return getid;
    }

    public async Task<User> GetUserByName(string name)
    {
        var getname = await _appDbContext.Users.Where(n => n.Name == name).FirstOrDefaultAsync();
        return getname;
    }

    public async Task UpdateUser(int id, User userDto)
    {
        var getid = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        getid.Name = userDto.Name;
        getid.Email = userDto.Email;
        getid.Password = userDto.Password;
        getid.Phone = userDto.Phone;
        _appDbContext.Users.Update(getid);
        await _appDbContext.SaveChangesAsync();

    }
}
