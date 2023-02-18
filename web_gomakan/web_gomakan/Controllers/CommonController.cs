using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace web_gomakan.Controllers
{
    [Route("common")]
    public class CommonController : Controller
    {
        private readonly string URL_API;
        private readonly string BASE_PATH; 
        private IConfiguration  _configuration;

        public CommonController(ILogger<CommonController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            BASE_PATH = "common";
            URL_API = _configuration.GetValue<string>("URL_API_GOMAKAN");
        }
        [HttpGet]
        [Route("get-img/{image}")]
        public IActionResult GetImage(string image)
        {
            try
            {
                var url = URL_API+BASE_PATH+"/get-img"+"?filename="+image;
                
                WebClient myClient = new WebClient();
                byte[] bytes = myClient.DownloadData(url);
                string[] ext = image.Split(".");
                return File(bytes, "image/"+ext.Last());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return Ok();
        }
    }
}