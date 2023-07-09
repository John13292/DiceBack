using DiceBack.Contracts.Models;

namespace DiceBack.Application.Images
{
    public interface IImage
    {
        public Task<IEnumerable<ImageDto>> GetImagesList();
    }
}
