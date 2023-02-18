using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace api_gomakan.Controllers
{
    [ApiController]
    [Route("common")]
    public class CommonController : ControllerBase
    {
        private static IHostingEnvironment _environment;
        public CommonController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        // GET
        [HttpGet]
        [Route("get-img")]
        public FileContentResult GetImage(string filename)
        {
            string basePath = _environment.ContentRootPath;
            string pathFile = Path.Combine(basePath,"assets","img",filename);
            byte[] img = System.IO.File.ReadAllBytes(pathFile);
            string[] ext = filename.Split(".");
            return File(img,"image/"+ext.Last());
        }
    }
}