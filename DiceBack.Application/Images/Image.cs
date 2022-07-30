using AutoMapper;
using DiceBack.Contracts.Models;
using DiceBack.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.Application.Images;

public class Image : IImage
{
    private readonly DiceBackContext _context;
    private readonly IMapper _mapper;

    public Image(DiceBackContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ImageDto>> GetImagesList()
    {
        return
            await _context
                .Images
                .Select(x => _mapper.Map<ImageDto>(x))
                .ToListAsync();
    }
}
