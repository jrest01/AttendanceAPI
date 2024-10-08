

using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly attendanceContext _context;

    public UserService(attendanceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task PostUsuario(User user)
    {
        try
        {
            _context.Users.Add(user);        // Añadir el usuario a la base de datos
            await _context.SaveChangesAsync(); // Guardar cambios de manera asíncrona
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar el usuario: {ex.Message}");
            throw;
        }
    }
}

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task PostUsuario(User user);
}