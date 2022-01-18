namespace DiceBack.Models
{
    public class Effects
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsNegative { get; set; } = false; 
        public bool IsPositive { get; set; } = false;
        public DateTime InsertStamp { get; set; } = DateTime.Now;
    }
}
