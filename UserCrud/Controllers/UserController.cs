using Microsoft.AspNetCore.Mvc;
using UserCrud.Models;
using UserCrud.Repositories.Interfaces;

namespace UserCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> Users()
    {
        List<UserModel> users = await _userRepository.Users();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<UserModel>>> SearchById(int id)
    {
        UserModel users = await _userRepository.SearchById(id);
        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
    {
        UserModel user = await _userRepository.AddUser(userModel);

        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
    {
        userModel.Id = id;
        UserModel user = await _userRepository.UpdateUser(userModel, id);
        return Ok(user);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserModel>> Delete([FromBody] UserModel userModel, int id)
    {
        bool deleted = await _userRepository.Delete(id);
        return Ok(deleted);
    }
}
