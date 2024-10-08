
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AttendancesController : ControllerBase
{
    IAttendanceService _attendanceService;

    public AttendancesController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAttendances()
    {
        return Ok(await _attendanceService.GetAttendances());
    }

    [HttpPost]
    public async Task<ActionResult> PostAttendance(Attendance attendance)
    {
        if (attendance == null)
        {
            throw new ArgumentNullException(nameof(attendance), "El attendance no puede ser nulo");
        }
        await _attendanceService.PostAttendance(attendance);
        return Ok();
    }
}