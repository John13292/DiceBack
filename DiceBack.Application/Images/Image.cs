using DiceBack.Contracts.Models;
using DiceBack.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.Application.Images;

public class Image : IImage
{
    private readonly DiceBackContext _context;

    public Image(DiceBackContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ImageDto>> GetImagesList()
    {
        return await _context.Images.ToListAsync();
    }
}
