using Microsoft.EntityFrameworkCore;
using UserCrud.Data;
using UserCrud.Models;
using UserCrud.Repositories.Interfaces;

namespace UserCrud.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserCrudDbContext _dbContext;
    public UserRepository(UserCrudDbContext userCrudDbContext)
    {
        _dbContext = userCrudDbContext;
    }
    public async Task<UserModel> SearchById(int id)
    {
        return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserModel> UpdateUser(UserModel user, int id)
    {
        UserModel userById = await SearchById(id);

        if (userById == null)
        {
            throw new Exception($"User for id: {id} not found in database.");
        }

        userById.Name = user.Name;
        userById.Email = user.Email;
        userById.Age = user.Age;

        _dbContext.User.Update(userById);
        await _dbContext.SaveChangesAsync();

        return userById;
    }

    public async Task<List<UserModel>> Users()
    {
        return await _dbContext.User.ToListAsync();
    }

    public async Task<UserModel> AddUser(UserModel user)
    {
        await _dbContext.User.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<bool> Delete(int id)
    {
        UserModel userById = await SearchById(id);

        if (userById == null)
        {
            throw new Exception($"User for id: {id} not found in database.");
        }

        _dbContext.User.Remove(userById);
        await _dbContext.SaveChangesAsync();

        return true;

    }
}