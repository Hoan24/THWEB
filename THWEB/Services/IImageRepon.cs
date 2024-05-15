using THWEB.Models;

namespace THWEB.Services
{
    public interface IImageRepon
    {
        Image Upload(Image image);
        List<Image> GetImages();
        (byte[], string, string) DownFile(int id);
    }
}
