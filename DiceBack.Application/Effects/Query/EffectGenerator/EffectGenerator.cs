using DiceBack.Application.Extensions;
using DiceBack.Contracts.Enums;
using DiceBack.Contracts.Models;

namespace DiceBack.Application.Effects.Query.EffectGenerator;

internal class EffectGenerator : IEffectGenerator
{
    private const int CountEffects = 3;
    private const int MinRandomRate = 1;

    private readonly IEffectQuery _effectQuery;

    public EffectGenerator(IEffectQuery effectQuery)
    {
        _effectQuery = effectQuery;
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
        var effectDto = await _effectQuery.GetEffects();

        if (!effectDto.Any())
        {
            return;
        }

        var effects =
            effectDto
                .Where(x => x.EffectType == effectType);

        for (var i = 0; i < CountEffects; i++)
        {
            var randomEffect = effects.Random(MinRandomRate);

            generatedEffects.Add(randomEffect);
        }
    }
}