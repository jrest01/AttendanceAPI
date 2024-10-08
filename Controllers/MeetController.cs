
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MeetsController : ControllerBase
{
    private readonly attendanceContext _context;

    public MeetsController(attendanceContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Meet>>> GetMeets()
    {
        return await _context.Meets.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Meet>> PostMeet(Meet meet)
    {
        _context.Meets.Add(meet);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMeets), new { id = meet.MeetId }, meet);
    }
}