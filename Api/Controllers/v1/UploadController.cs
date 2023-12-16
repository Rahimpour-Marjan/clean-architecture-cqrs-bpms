using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.StaticFiles;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> Get(string url)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), url);

            var fileName = System.IO.Path.GetFileName(path);
            var content = await System.IO.File.ReadAllBytesAsync(path);
            new FileExtensionContentTypeProvider()
                .TryGetContentType(fileName, out string contentType);
            return File(content, contentType, fileName);
        }

        [HttpPost("{id}")]
        public IActionResult Post(string id, IFormFile file)
        {
            try
            {
                var folderName = Path.Combine("Resources", "UploadFiles", id);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                if (file.Length > 0)
                {
                    if (file.Length > 30000000)
                        return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                        {
                            Errors = new string[] { "حداکثر سایز مجاز برای فایل 30 مگابایت می باشد!" }
                        });

                    var orginalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    ////var fileNamePure = fileName.Substring(0, fileName.LastIndexOf("."));
                    var extenstion = orginalFileName.Substring(orginalFileName.LastIndexOf("."));

                    var newFileNamePure = Guid.NewGuid() + extenstion;

                    var newFileName = newFileNamePure + extenstion;



                    if (!AllowedExtensions(extenstion.ToLower()))
                        return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                        {
                            Errors = new string[] { "فایل وارد شده مجاز نمی باشد!" }
                        });

                    var fullPath = Path.Combine(pathToSave, newFileName);



                    var whileCounter = 0;
                    while (System.IO.File.Exists(fullPath) && whileCounter < 50)
                    {
                        whileCounter++;

                        var fileCounter = Directory.GetFiles(pathToSave, $"{newFileNamePure}*{extenstion}").Count() + 1;
                        newFileNamePure = $"{newFileNamePure}_{fileCounter}";
                        newFileName = $"{newFileNamePure}{extenstion}";
                        fullPath = Path.Combine(pathToSave, newFileName);
                    }

                    var dbPath = Path.Combine(folderName, newFileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = dbPath.Replace(@"\\", @"\"),
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { "خطا در باگزاری فایل، مجددا تلاش کنید" }
                    });
                }
            }
            catch (Exception ex)
            {
                var type = ex.GetType().Name;
                var message = ex.Message;
                var stackTrace = ex.ToString();

                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { message }
                });
            }
        }

        private bool AllowedExtensions(string extension)
        {
            return extension switch
            {
                ".xls" => true,
                ".xlsx" => true,
                ".doc" => true,
                ".docx" => true,
                ".ppt" => true,
                ".pptx" => true,
                ".accdb" => true,
                ".jpg" => true,
                ".png" => true,
                ".jpeg" => true,
                ".dxf" => true,
                ".pdf" => true,
                _ => false,
            };
        }
    }
}