using System;
using System.Linq;
using System.Threading.Tasks;
using api_gomakan.Data;
using libs_gomakan.Models;
using libs_gomakan.Registries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api_gomakan.Controllers
{
    [ApiController]
    [Route("pesanan")]
    public class PesananController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PesananController> _logger;

        public PesananController(ILogger<PesananController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            Pesanan data = _db.Pesanans.
                Include(p=>p.Makanan).
                Where(p =>p.IsActive == true).
                Where(p => p.Id == id).
                FirstOrDefault();
            return Ok(data);
        }
        
        [HttpGet]
        [Route("list")]
        public IActionResult List(string keyword, string status)
        {
            IQueryable<Pesanan> query = _db.Pesanans.Include(p=>p.Makanan).Where(p=>p.IsActive==true);
            if (!string.IsNullOrEmpty(status)) query = query.Where(p => p.Status == status);
            
            return Ok(query);
        }

        [HttpPost]
        [Route("tambah-keranjang")]
        public async Task<IActionResult> TambahKeranjang(PesananDto pesanan)
        {
            var transaction = _db.Database.BeginTransaction();
            try
            {
                //get total
                int price = _db.Makanans.
                    Where(p =>p.IsActive == true).
                    Where(p => p.Id == pesanan.IdMakanan).
                    Select(x=>x.Price).
                    FirstOrDefault();
                
                //Upsert
                var ExistPesanan = _db.Pesanans.Where(p => p.MakananId == pesanan.IdMakanan)
                    .Where(p=>p.IsActive == true)
                    .Where(p=>p.Status == Registries.StatusNew)
                    .FirstOrDefault();
                if (ExistPesanan != null)
                {
                    int totalQty = ExistPesanan.Qty + pesanan.Qty;
                    ExistPesanan.Qty = totalQty;
                    ExistPesanan.Total = totalQty * price;
                }
                else
                {
                    Pesanan data = new Pesanan();
                    data.MakananId = pesanan.IdMakanan;
                    data.Qty = pesanan.Qty;
                    data.Total = pesanan.Qty * price;
                    data.Status = "NEW";
                    data.IsActive = true;
                    _db.Pesanans.Add(data);
                }
                await _db.SaveChangesAsync();
                transaction.Commit();
                return Ok("Pesanan berhasil ditambahkan");
            }
            catch (Exception e)
            {
                transaction.Rollback();   
                Console.WriteLine(e);
                throw new AggregateException("gagal menyimpan data",e);
            }
        }

        [HttpPost]
        [Route("bayar")]
        public async Task<IActionResult> Bayar(PembayaranDto pembayaranDto)
        {
            var transaction = _db.Database.BeginTransaction();
            try
            {
                Pembayaran pembayaran = new Pembayaran();
                pembayaran.Status = Registries.StatusFinal;
                pembayaran.TotalPembayaran = pembayaranDto.totalPembayaran;
                _db.Pembayarans.Add(pembayaran);
                
                var pesanan = _db.Pesanans.Where(p => p.IsActive == true)
                    .Where(p => p.Status == Registries.StatusNew).ToList();
                
                pesanan.ForEach(p =>
                {
                    p.Status = Registries.StatusFinal;
                    p.PembayaranId = pembayaran.Id;
                });
                
                _db.SaveChanges();
                    
                transaction.Commit();
                return Ok("Pembayaran Berhasil");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e);
                throw new AggregateException("gagal menyimpan data", e);
            }
        }
    }
}