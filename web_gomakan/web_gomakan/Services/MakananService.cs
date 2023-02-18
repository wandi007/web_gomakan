using System.Collections.Generic;
using System.Net.Http;
using libs_gomakan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace web_gomakan.Services
{
    public class MakananService : Controller
    {
        private HttpClient client;
        private string URL;
        private static readonly string BASE_PATH = "makanan";
        private ServiceUtils serviceUtils;

        public MakananService(HttpClient client, string api_url)
        {
            this.client = client;
            URL = api_url;
            serviceUtils = new ServiceUtils(client);
        }

        public List<Makanan> GetList(Dictionary<string, string> query = null)
        {
            var url = URL + BASE_PATH + "/list";
            var requestUri = query == null ? url : QueryHelpers.AddQueryString(url, query);
            return serviceUtils.GetList<Makanan>(requestUri);
        }
        public Makanan GetOne(int id)
        {
            var requestUri = URL + BASE_PATH + "/get/"+id;
            return serviceUtils.GetOne<Makanan>(requestUri);
        }

    }
}