using Application.Features.Brands.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommand createBrandCommand)
    {
        // MediatR kullanarak komutu gönder
        CreatedBrandResponse response = await Mediator.Send(createBrandCommand);
        return Ok(response);
    }

}
