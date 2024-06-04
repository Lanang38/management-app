using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Model.Entity
{
    public class Barang
    {
        public string BarangID { get; set; }
        public string NamaBarang { get; set; }
        public string Deskripsi { get; set; }
        public int Harga { get; set; }
        public int Stok { get; set; }
    }
}
