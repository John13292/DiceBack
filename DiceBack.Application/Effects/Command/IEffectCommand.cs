using DiceBack.Contracts.Models;

namespace DiceBack.Application.Effects.Command
{
    public interface IEffectCommand
    {
        public Task AddEffect(EffectDto effectDto);
        public Task PutEffect(EffectDto effectDto);
        public Task DeleteEffect(int id);
    }
}
