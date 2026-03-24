using Application.Features.Transmission.Commands.Create;
using Application.Features.Transmission.Commands.Delete;
using Application.Features.Transmission.Commands.Update;
using Application.Features.Transmission.Queries.GetById;
using Application.Features.Transmission.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateTransmission([FromBody] CreateTransmissionCommand createTransmissionCommand)
    {
        CreatedTransmissionResponse response = await Mediator.Send(createTransmissionCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTransmissionQuery getListTransmissionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTransmissionListItemDTO> response = await Mediator.Send(getListTransmissionQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTransmissionQuery getByIdTransmissionQuery = new() { Id = id };
        GetByIdTransmissionResponse response = await Mediator.Send(getByIdTransmissionQuery);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand updateTransmissionCommand)
    {
        UpdatedTransmissionResponse response = await Mediator.Send(updateTransmissionCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteTransmissionCommand deleteTransmissionCommand = new() { Id = id };
        DeletedTransmissionResponse response = await Mediator.Send(deleteTransmissionCommand);
        return Ok(response);
    }
}
