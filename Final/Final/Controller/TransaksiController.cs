using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Final.Model.Entity;
using Final.Model.Context;
using Final.Model.Repository;
using System.Windows.Forms;

namespace Final.Controller
{
    public class TransaksiController
    {
        private TransaksiRepository _transaksiRepository;

        public int Create(Transaksi transaksi)
        {
            int result = 0;
            if (string.IsNullOrEmpty(transaksi.TransaksiID))
            {
                MessageBox.Show("ID Transaksi harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(transaksi.PelangganID))
            {
                MessageBox.Show("Nama Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(transaksi.BarangID))
            {
                MessageBox.Show("Alamat Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(transaksi.SupplierID))
            {
                MessageBox.Show("Kontak Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (transaksi.JumlahBarang == null)
            {
                MessageBox.Show("Stok Barang harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(transaksi.TanggalTransaksi))
            {
                MessageBox.Show("Kontak Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _transaksiRepository = new TransaksiRepository(context);
                result = _transaksiRepository.Create(transaksi);
            }
            return result;
        }

        public List<Transaksi> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Transaksi> list = new List<Transaksi>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _transaksiRepository = new TransaksiRepository(context);
                list = _transaksiRepository.ReadByNama(nama);
            }
            return list;
        }
        public List<Transaksi> ReadAll()
        {
            // membuat objek collection
            List<Transaksi> list = new List<Transaksi>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _transaksiRepository = new TransaksiRepository(context);
                list = _transaksiRepository.ReadAll();
            }
            return list;
        }

        public int Update(Transaksi transaksi)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _transaksiRepository = new TransaksiRepository(context);
                result = _transaksiRepository.Update(transaksi);
            }

            return result;
        }

        public int Delete(Transaksi transaksi)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _transaksiRepository = new TransaksiRepository(context);
                result = _transaksiRepository.Delete(transaksi);
            }

            return result;
        }


    }
}
