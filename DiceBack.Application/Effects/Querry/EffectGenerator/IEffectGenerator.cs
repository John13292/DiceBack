using DiceBack.Contracts.Models;

namespace DiceBack.Application.Effects.Querry.EffectGenerator
{
    public interface IEffectGenerator
    {
        public Task<IEnumerable<EffectDto>> GenerateEffects();
    }
}
