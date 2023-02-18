using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace web_gomakan.Services
{
    public class ServiceUtils : Controller
    {
        private HttpClient HttpClient;
        
        public ServiceUtils(HttpClient client)
        {
            HttpClient = client;
        }
        public List<T> GetList<T>(string url)
        {
            var response = HttpClient.GetAsync(url).Result;
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content;
                string rawData = res.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(rawData);
            }
            ValidationException(response.StatusCode, responseMessage);
            throw new HttpRequestException(responseMessage);
        }
        public T GetOne<T>(string url)
        {
            var response = HttpClient.GetAsync(url).Result;
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content;
                string rawData = res.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(rawData);
            }
            ValidationException(response.StatusCode, responseMessage);
            throw new HttpRequestException(responseMessage);
        }
        
        public IActionResult PostJson<TValue>(string url, TValue param)
        {
            var response = HttpClient.PostAsJsonAsync(url, param).Result;
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode) return Ok();
            ValidationException(response.StatusCode, responseMessage);
            throw new HttpRequestException(responseMessage);
        }
        
        private static void ValidationException(HttpStatusCode statusCode, string responseMessage)
        {
            if (statusCode == HttpStatusCode.BadRequest || statusCode == HttpStatusCode.NotFound || statusCode == HttpStatusCode.Unauthorized)
                throw new ValidationException(responseMessage);
        }
    }
}