using System.Collections.Generic;

namespace libs_gomakan.Models
{
    public class Pesanan
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }
        public int MakananId { get; set; }
        public bool IsActive { get; set; }
        public int PembayaranId { get; set; }
        public virtual Makanan Makanan { get; set; }
    }
}