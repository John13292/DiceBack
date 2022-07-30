using AutoMapper;
using DiceBack.Contracts.Models;
using DiceBack.DataBase;
using DiceBack.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.Application.Effects.Command
{
    internal class EffectCommand : IEffectCommand
    {
        private readonly DiceBackContext _context;
        private readonly IMapper _mapper;

        public EffectCommand(DiceBackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddEffect(EffectDto effectDto)
        {
            effectDto.InsertStamp = DateTime.UtcNow;

            var effect = _mapper.Map<Effect>(effectDto);

            await _context.Effects.AddAsync(effect);
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEffect(int id)
        {
            try
            {
                var effect = await _context.Effects.FindAsync(id);

                if (effect is null)
                {
                    return;
                }

                _context.Effects.Remove(effect);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task PutEffect(EffectDto effectDto)
        {
            try
            {
                var effect = await _context.Effects.FindAsync(effectDto.Id);

                if (effect is null)
                {
                    return;
                }

                effect = _mapper.Map<Effect>(effectDto);

                effect.UpdateStamp = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                var effectId = await _context.Effects.FindAsync(effectDto.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
