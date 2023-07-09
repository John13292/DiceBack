using DiceBack.Contracts.Models;

namespace DiceBack.Application.Effects.Querry;

public interface IEffectQuerry
{
    public Task<EffectDto> GetEffectById(int id);
    public Task<IEnumerable<EffectDto>> GetEffects();
    public Task<IEnumerable<EffectDto>> GetPositiveEffects();
    public Task<IEnumerable<EffectDto>> GetNegativeEffects();
}
