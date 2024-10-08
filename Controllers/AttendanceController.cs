
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AttendancesController : ControllerBase
{
    private readonly attendanceContext _context;

    public AttendancesController(attendanceContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
    {
        return await _context.Attendances.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUsuario(Attendance attendance)
    {
        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAttendances), new { id = attendance.AttendanceId }, attendance);
    }
}