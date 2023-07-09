namespace DiceBack.Contracts.Models;

public class ImageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public DateTime InsertStamp { get; set; }
}