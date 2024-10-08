using Microsoft.EntityFrameworkCore;

public class MeetService : IMeetService
{
    private readonly attendanceContext _context;

    public MeetService(attendanceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Meet>> GetMeets()
    {
        var meets = await _context.Meets.ToListAsync();
        return meets;
    }

    public async Task PostMeet(Meet meet)
    {
        try
        {
            _context.Add(meet);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar el meet: {ex.Message}");
            throw;
        }
    }

}

public interface IMeetService
{
    Task<IEnumerable<Meet>> GetMeets();
    Task PostMeet(Meet meet);
}