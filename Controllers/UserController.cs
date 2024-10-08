
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _userService.GetUsers());
    }

    [HttpPost]
    public async Task<IActionResult> PostUsuario(User user)
    {

        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo");
        }
        await _userService.PostUsuario(user);
        return Ok();
    }


}