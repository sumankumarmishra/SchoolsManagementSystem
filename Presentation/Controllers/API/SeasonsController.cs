﻿namespace Presentation.Controllers.API;

[Authorize]
[Route("api/seasons")]
[ApiController]
public class SeasonsController : ControllerBase
{
    private readonly ISeasonService _seasonService;

    public SeasonsController(ISeasonService seasonService)
    {
        _seasonService = seasonService;
    }

    [HttpGet]
    public IActionResult GetAll([FromHeader] int schoolId, int pageNumber = 1, int pageSize = 10)
    {
        return Ok(_seasonService.GetAll(pageNumber, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromHeader] int schoolId, int id)
    {
        var dto = await _seasonService.GetById(id);
        if (dto.Data is null)
            return BadRequest(ResponseHandler.BadRequest<string>("Not Found Season"));
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Add([FromHeader] int schoolId, AddSeasonDto dto)
    {
        return Ok(await _seasonService.Add(dto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromHeader] int schoolId, int id, UpdateSeasonDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest(ResponseHandler.BadRequest<string>("Id not matched"));
        }
        var result = await _seasonService.Update(dto);
        if (!result.Data)
        {
            return BadRequest(ResponseHandler.BadRequest<string>("Not Updated"));
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromHeader] int schoolId, int id)
    {
        var result = await _seasonService.Delete(id);
        if (!result.Data)
        {
            return BadRequest(ResponseHandler.BadRequest<string>("Not Deleted"));
        }
        return Ok(result);
    }
}
