using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

public class AttendanceService : IAttendanceService
{
    private readonly attendanceContext _context;

    public AttendanceService(attendanceContext attendanceContext)
    {
        _context = attendanceContext;
    }

    public async Task<IEnumerable<Attendance>> GetAttendances()
    {
        var attendances = await _context.Attendances.ToListAsync();
        return attendances;
    }

    public async Task PostAttendance(Attendance attendance)
    {
        try
        {
            _context.Add(attendance);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar el Attendance: {ex.Message}");
            throw;
        }
    }
}

public interface IAttendanceService
{
    Task<IEnumerable<Attendance>> GetAttendances();
    Task PostAttendance(Attendance attendance);
}