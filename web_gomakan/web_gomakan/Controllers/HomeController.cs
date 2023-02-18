using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using libs_gomakan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using web_gomakan.Models;
using web_gomakan.Services;
using libs_gomakan.Registries;

namespace web_gomakan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MakananService _makananService;
        private readonly PesananService _pesanan;
        private readonly IConfiguration _configuration;
        private readonly string URL_API;
        private static HttpClient _client;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _client = new HttpClient();
            URL_API = _configuration.GetValue<string>("URL_API_GOMAKAN");
            _makananService = new MakananService(_client,URL_API);
            _pesanan = new PesananService(_client,URL_API);
        }

        public IActionResult Index(string keyword)
        {
            ViewBag.makanan = new List<Makanan>();
            try
            {
                var param = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(keyword))
                {
                    param.Add("keyword",keyword);
                    List<Makanan> makanan = _makananService.GetList(param);
                    ViewBag.makanan = makanan;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        [Route("makanan/list")]
        public IActionResult ListMakanan(string keyword, int limit =5,int offset = 0)
        {
            try
            {
                var param = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(keyword)) param.Add("keyword",keyword);
                param.Add("limit",limit.ToString());
                param.Add("offset",offset.ToString());
                List<Makanan> makanan = _makananService.GetList(param);
                return Ok(makanan);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Gagal mengambil data"+ e.Message);
            }
        }
        
        [Route("detail/{id}")]
        public IActionResult Detail(int id)
        {
            try
            {
                ViewBag.detail = _makananService.GetOne(id);
                return View();
            }
            catch (Exception e)
            {
                TempData["message"] = "gagal membuka halaman detail "+e.Message;
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("tambah-keranjang")]
        public IActionResult TambahKeranjang(PesananDto data)
        {
            try
            {
                _pesanan.TambahKeranjang(data);
                TempData["message"] = "pesanan berhasil ditambahkan";
                return RedirectToAction("DaftarPesanan");
            }
            catch (Exception e)
            {
                TempData["message"] = "gagal menambahkan kepesanan";
                Console.WriteLine(e);
                return RedirectToAction("Detail", "Home", new {id = data.IdMakanan});
            }
        }

        [HttpGet]
        [Route("daftar-pesanan")]
        public IActionResult DaftarPesanan()
        {
            try
            {
                var param = new Dictionary<string, string>()
                {
                    ["status"] = Registries.StatusNew
                };
                List<Pesanan> pesanan = _pesanan.GetList(param);
                ViewBag.pesanan = pesanan;
                ViewBag.TotalPesanan = pesanan.Select(p=>p.Total).ToArray().Sum();
                return View();
            }
            catch (Exception e)
            {
                TempData["message"] = "gagal membuka halaman, "+e.Message;
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("daftar-pesanan/checkout")]
        public IActionResult CheckoutPesanan()
        {
            try
            {
                var param = new Dictionary<string, string>()
                {
                    ["status"] = Registries.StatusNew
                };
                List<Pesanan> pesanan = _pesanan.GetList(param);
                ViewBag.pesanan = pesanan;
                ViewBag.TotalPesanan = pesanan.Select(p=>p.Total).ToArray().Sum();
                return View();
            }
            catch (Exception e)
            {
                TempData["message"] = "gagal membuka halaman, "+e.Message;
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("bayar")]
        public IActionResult Bayar(PembayaranDto param)
        {
            try
            {
                _pesanan.Bayar(param);
                TempData["message"] = "Pesanan berhasil di bayar";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["message"] = "Pesanan gagal dibayarkan";
                Console.WriteLine(e);
                return RedirectToAction("CheckoutPesanan");
            }
        }
    }
}