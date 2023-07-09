﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using DiceBack.Contracts.Models;
using DiceBack.Application.Effects.Querry;
using DiceBack.Application.Effects.Command;
using DiceBack.Application.Effects.Querry.EffectGenerator;

namespace DiceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffectsController : ControllerBase
    {
        private readonly IEffectQuerry _effectQuerry;
        private readonly IEffectCommand _effectCommand;
        private readonly IEffectGenerator _effectGenerator;

        public EffectsController(IEffectQuerry effectQuerry, IEffectCommand effectCommand, IEffectGenerator effectGenerator)
        {
            _effectQuerry = effectQuerry;
            _effectCommand = effectCommand;
            _effectGenerator = effectGenerator;
        }

        // GET: api/Effects
        [HttpGet("GetEffects")]
        public async Task<IEnumerable<EffectDto>> GetEffects()
        {
            return await _effectQuerry.GetEffects();
        }

        // GET: api/Effects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EffectDto>> GetEffects(int id)
        {
            
            var effect = await _effectQuerry.GetEffectById(id);

            if (effect is null)
            {
                return BadRequest();
            }

            return effect;
        }

        [HttpGet("GetPositiveEffects")]
        [ActionName("GetPositiveEffects")]
        public async Task<IEnumerable<EffectDto>> GetPositiveEffects()
        {
            return await _effectQuerry.GetPositiveEffects();
        }

        [HttpGet("GetNegativeEffects")]
        [ActionName("GetNegativeEffects")]
        public async Task<IEnumerable<EffectDto>> GetNegativeEffects()
        {
            return await _effectQuerry.GetNegativeEffects();
        }

        [HttpPost(nameof(AddEffect))]
        public async Task AddEffect([FromQuery] EffectDto effectDto)
        {
            await _effectCommand.AddEffect(effectDto);
        }

        // PUT: api/Effects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateEffect")]
        public async Task UpdateEffect(EffectDto effectDto)
        {
            await _effectCommand.PutEffect(effectDto);
        }

        // DELETE: api/Effects/5
        [HttpDelete("DeleteEffect")]
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
}
