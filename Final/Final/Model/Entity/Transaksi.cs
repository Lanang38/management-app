using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Model.Entity
{
    public class Transaksi
    {
        public string TransaksiID { get; set; }
        public string PelangganID { get; set; }
        public string BarangID { get; set; }
        public string SupplierID { get; set; }
        public int JumlahBarang { get; set; }
        public string TanggalTransaksi { get; set; }
        public int Total { get; set; }
    }
}
