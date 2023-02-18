using System.Collections.Generic;

namespace libs_gomakan.Models
{
    public class Makanan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<Pesanan> Pesanans { get; set; }
    }
}