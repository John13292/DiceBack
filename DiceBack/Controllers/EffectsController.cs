#nullable disable
using DiceBack.Application.Effects.Command;
using DiceBack.Application.Effects.Query;
using DiceBack.Application.Effects.Query.EffectGenerator;
using DiceBack.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiceBack.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EffectsController : ControllerBase
{
    private readonly IEffectQuery _effectQuery;
    private readonly IEffectCommand _effectCommand;
    private readonly IEffectGenerator _effectGenerator;

    public EffectsController(IEffectQuery effectQuery, IEffectCommand effectCommand, IEffectGenerator effectGenerator)
    {
        _effectQuery = effectQuery;
        _effectCommand = effectCommand;
        _effectGenerator = effectGenerator;
    }

    // GET: api/Effects
    [HttpGet(nameof(GetEffects))]
    public async Task<IEnumerable<EffectDto>> GetEffects()
    {
        return await _effectQuery.GetEffects();
    }

    // GET: api/Effects/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EffectDto>> GetEffects(int id)
    {
            
        var effect = await _effectQuery.GetEffectById(id);

        if (effect is null)
        {
            return BadRequest();
        }

        return effect;
    }

    [HttpGet(nameof(GetPositiveEffects))]
    public async Task<IEnumerable<EffectDto>> GetPositiveEffects()
    {
        return await _effectQuery.GetPositiveEffects();
    }

    [HttpGet(nameof(GetNegativeEffects))]
    public async Task<IEnumerable<EffectDto>> GetNegativeEffects()
    {
        return await _effectQuery.GetNegativeEffects();
    }

    [HttpPost(nameof(AddEffect))]
    public async Task AddEffect([FromQuery] EffectDto effectDto)
    {
        await _effectCommand.AddEffect(effectDto);
    }

    // PUT: api/Effects/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut(nameof(UpdateEffect))]
    public async Task UpdateEffect(EffectDto effectDto)
    {
        await _effectCommand.PutEffect(effectDto);
    }

    // DELETE: api/Effects/5
    [HttpDelete(nameof(DeleteEffect))]
    public async Task DeleteEffect(int id)
    {
        await _effectCommand.DeleteEffect(id);
    }

    [HttpGet(nameof(GenerateEffects))]
    public async Task<IEnumerable<EffectDto>> GenerateEffects()
    {
        return await _effectGenerator.GenerateEffects();
    }
}