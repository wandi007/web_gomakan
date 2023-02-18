using System.Collections.Generic;

namespace libs_gomakan.Models
{
    public class Pembayaran
    {
        public int Id { get; set; }
        public int TotalPembayaran { get; set; }
        public string Status { get; set; }
        
        public ICollection<Pesanan> Pesanans { get; set; }
    }
}