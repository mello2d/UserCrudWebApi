using System.Threading.Tasks;
using UserCrud.Models;

namespace UserCrud.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> Users();
    Task<UserModel> SearchById(int id);
    Task<UserModel> AddUser(UserModel user);
    Task<UserModel> UpdateUser(UserModel user, int id);
    Task<bool> Delete(int id);
}
