using DiceBack.Contracts.Models;

namespace DiceBack.Application.Effects.Query.EffectGenerator;

public interface IEffectGenerator
{
    public Task<IEnumerable<EffectDto>> GenerateEffects();
}