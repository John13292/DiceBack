using DiceBack.Application.Extensions;
using DiceBack.Contracts.Enums;
using DiceBack.Contracts.Models;

namespace DiceBack.Application.Effects.Querry.EffectGenerator
{
    internal class EffectGenerator : IEffectGenerator
    {
        private const int countEffects = 3;
        private const int minRandomRate = 1;

        private readonly IEffectQuerry _effectQuerry;

        public EffectGenerator(IEffectQuerry effectQuerry)
        {
            _effectQuerry = effectQuerry;
        }

        public async Task<IEnumerable<EffectDto>> GenerateEffects()
        {
            var generatedEffects = new List<EffectDto>();

            await CalculeteEffects(generatedEffects, EffectType.Negative);
            await CalculeteEffects(generatedEffects, EffectType.Positive);

            return generatedEffects;
        }

        private async Task CalculeteEffects(List<EffectDto> generatedEffects, EffectType effectType)
        {
            var effectDto = await _effectQuerry.GetEffects();

            if (!effectDto.Any())
            {
                return;
            }

            var effects =
                effectDto
                .Where(x => x.EffectType == effectType);

            for (int i = 0; i < countEffects; i++)
            {
                var randomEffect = effects.Random(minRandomRate);

                generatedEffects.Add(randomEffect);
            }
        }
    }
}
