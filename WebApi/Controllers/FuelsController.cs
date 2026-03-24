using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetById;
using Application.Features.Fuels.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateFuel([FromBody] CreateFuelCommand createFuelCommand)
    {
        CreatedFuelResponse response = await Mediator.Send(createFuelCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFuelQuery getListFuelQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFuelListItemDTO> response = await Mediator.Send(getListFuelQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdFuelQuery getByIdFuelQuery = new() { Id = id };
        GetByIdFuelResponse response = await Mediator.Send(getByIdFuelQuery);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
    {
        UpdatedFuelResponse response = await Mediator.Send(updateFuelCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteFuelCommand deleteFuelCommand = new() { Id = id };
        DeletedFuelResponse response = await Mediator.Send(deleteFuelCommand);
        return Ok(response);
    }
}
