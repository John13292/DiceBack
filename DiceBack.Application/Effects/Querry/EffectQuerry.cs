using DiceBack.Contracts.Models;
using DiceBack.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.Application.Effects.Querry;

internal class EffectQuerry : IEffectQuerry
{
    private readonly DiceBackContext _context;

    public EffectQuerry(DiceBackContext context)
    {
        _context = context;
    }

    public async Task<EffectDto?> GetEffectById(int id)
    {
        var effect = 
            await _context
            .Effects
            .FindAsync(id);

        return effect;
    }

    public async Task<IEnumerable<EffectDto>> GetEffects()
    {
        return await _context.Effects.ToListAsync();
    }

    public async Task<IEnumerable<EffectDto>> GetNegativeEffects()
    {
        var effects = 
            await _context
            .Effects
            .Where(x => x.IsNegative)
            .ToListAsync();

        return effects;
    }

    public async Task<IEnumerable<EffectDto>> GetPositiveEffects()
    {
        var effects =
            await _context
            .Effects
            .Where(x => x.IsPositive)
            .ToListAsync();

        return effects;
    }
}
