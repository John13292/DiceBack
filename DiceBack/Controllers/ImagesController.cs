using DiceBack.Application.Images;
using DiceBack.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiceBack.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImage _image;

    public ImagesController(IImage image)
    {
        _image = image;
    }

    [HttpGet]
    public async Task<IEnumerable<ImageDto>> GetImagesList()
    {
        return await _image.GetImagesList();
    }
}