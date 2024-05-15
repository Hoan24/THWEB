using THWEB.Data;
using THWEB.Models;

namespace THWEB.Services
{
    public class ReImage : IImageRepon
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbcontext _appDbcontext;
        public ReImage(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, AppDbcontext appDbcontext)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            _appDbcontext = appDbcontext;
        }

        public (byte[], string, string) DownFile(int id)
        {
            try
            {
                var FilebyId=_appDbcontext.images.Where(a=>a.Id == id).FirstOrDefault();
                var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Images ", $"{FilebyId.FileName}{FilebyId.FileExtension}");
                var stream =File.ReadAllBytes(path);
                var filename = FilebyId.FileName + FilebyId.FileExtension;
                return (stream, "application/octet-stream", filename);
            }
            catch(Exception ex) { throw ex; }
        }

        public List<Image> GetImages()
        {
            var i = _appDbcontext.images.Select(a => new Image
            {
                Id = a.Id,
                File = a.File,
                FileName = a.FileName,
                FileDescription = a.FileDescription,
                FileExtension = a.FileExtension,
                FilePath = a.FilePath,
                FileSizeInBytes=a.FileSizeInBytes,
            });
            return i.ToList();
        }

        public Image Upload(Image image)
        {
            var lf = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
                $"{image.FileName}{image.FileExtension}");

            using var stream = new FileStream(lf, FileMode.Create);
            image.File.CopyTo(stream);

            var urlFPath = $"{_contextAccessor.HttpContext.Request.Scheme}{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath=urlFPath;


            _appDbcontext.images.Add(image);
            _appDbcontext.SaveChanges();
            return image;
        }
    }
}
