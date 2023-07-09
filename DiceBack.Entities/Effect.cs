using DiceBack.Contracts.Enums;

namespace DiceBack.Entities
{
    public class Effect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public EffectType EffectType { get; set; }
        public DateTime? UpdateStamp { get; set; }
        public DateTime? InsertStamp { get; set; }
    }
}