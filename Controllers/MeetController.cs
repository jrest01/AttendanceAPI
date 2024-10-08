
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MeetsController : ControllerBase
{
    IMeetService _meetService;

    public MeetsController(IMeetService meetService)
    {
        _meetService = meetService;
    }

    [HttpGet]
    public async Task<ActionResult> GetMeets()
    {
        return Ok(await _meetService.GetMeets());
    }

    [HttpPost]
    public async Task<ActionResult> PostMeet(Meet meet)
    {
        if (meet == null)
        {
            throw new ArgumentNullException(nameof(meet), "El meet no puede ser nulo");
        }
        await _meetService.PostMeet(meet);
        return Ok();
    }
}