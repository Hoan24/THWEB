using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using THWEB.Models;
using THWEB.Services;

namespace THWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ImageController : ControllerBase
    {

        private readonly IImageRepon _imageRepon;
        public ImageController(IImageRepon imageRepon) { _imageRepon = imageRepon; }
        [HttpPost]
        [Route("Upload")]

        [Authorize]
        public IActionResult Upload([FromForm] ImageDTO request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = request.FileExtension,
                   
                    FileDescription = request.FileDescription,
                };
                _imageRepon.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageDTO request)
        {
            var allowExtensions = new string[] { ".jpg", ".jpeg", ",png" };
            if(!allowExtensions.Contains(Path.GetExtension(request.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (request.File.Length > 1040000){
                ModelState.AddModelError("file", "File suze too big ,please upload file <10M");
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var all=_imageRepon.GetImages();
            return Ok(all); 
        }
        [HttpGet]
        [Route("Download")]
        [Authorize]
        public IActionResult Down(int id) 
        {
        var result=_imageRepon.DownFile(id);
            return File(result.Item1,result.Item2,result.Item3);
        }
    }
}
