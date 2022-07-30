namespace DiceBack.Entities
{
    public class Effect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsNegative { get; set; }
        public bool IsPositive { get; set; }
        public DateTime? UpdateStamp { get; set; }
        public DateTime? InsertStamp { get; set; }
    }
}