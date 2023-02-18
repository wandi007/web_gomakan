using System.Collections.Generic;
using System.Net.Http;
using libs_gomakan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace web_gomakan.Services
{
    public class PesananService : Controller
    {
        private HttpClient client;
        private string URL;
        private static readonly string BASE_PATH = "pesanan";
        private ServiceUtils serviceUtils;

        public PesananService(HttpClient client, string api_url)
        {
            this.client = client;
            URL = api_url;
            serviceUtils = new ServiceUtils(client);
        }

        public List<Pesanan> GetList(Dictionary<string, string> query = null)
        {
            var url = URL + BASE_PATH + "/list";
            var requestUri = query == null ? url : QueryHelpers.AddQueryString(url, query);
            return serviceUtils.GetList<Pesanan>(requestUri);
        }
        public Pesanan GetOne(int id)
        {
            var requestUri = URL + BASE_PATH + "/get/"+id;
            return serviceUtils.GetOne<Pesanan>(requestUri);
        }
        public IActionResult TambahKeranjang(PesananDto param)
        {
            return serviceUtils.PostJson(URL + BASE_PATH+"/tambah-keranjang", param);
        }

        public IActionResult Bayar(PembayaranDto param)
        {
            return serviceUtils.PostJson(URL + BASE_PATH + "/bayar",param);
        }
    }
}