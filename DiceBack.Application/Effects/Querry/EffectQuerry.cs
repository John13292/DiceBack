using AutoMapper;
using DiceBack.Contracts.Enums;
using DiceBack.Contracts.Models;
using DiceBack.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.Application.Effects.Querry;

internal class EffectQuerry : IEffectQuerry
{
    private readonly DiceBackContext _context;
    private readonly IMapper _mapper;

    public EffectQuerry(DiceBackContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EffectDto?> GetEffectById(int id)
    {
        var effect = 
            await _context
            .Effects
            .FindAsync(id);

        return _mapper.Map<EffectDto>(effect);
    }

    public async Task<IEnumerable<EffectDto>> GetEffects()
    {
        return 
            await _context
                .Effects
                .Select(x => _mapper.Map<EffectDto>(x))
                .ToListAsync();
    }

    public async Task<IEnumerable<EffectDto>> GetNegativeEffects()
    {
        var effects = 
            await _context
            .Effects
            .Where(x => x.EffectType == EffectType.Negative)
            .Select(x => _mapper.Map<EffectDto>(x))
            .ToListAsync();

        return effects;
    }

    public async Task<IEnumerable<EffectDto>> GetPositiveEffects()
    {
        var effects =
            await _context
            .Effects
            .Where(x => x.EffectType == EffectType.Positive)
            .Select(x => _mapper.Map<EffectDto>(x))
            .ToListAsync();

        return effects;
    }
}
