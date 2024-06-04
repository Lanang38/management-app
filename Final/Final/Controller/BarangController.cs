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
    public class BarangController
    {
        private BarangRepository _barangRepository;

        public int Create(Barang barang)
        {
            int result = 0;
            if (string.IsNullOrEmpty(barang.BarangID))
            {
                MessageBox.Show("ID Barang harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(barang.NamaBarang))
            {
                MessageBox.Show("Nama Barang harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(barang.Deskripsi))
            {
                MessageBox.Show("Deskripsi Barang harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (barang.Harga == null)
            {
                MessageBox.Show("Harga Barang harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (barang.Stok == null)
            {
                MessageBox.Show("Stok Barang harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _barangRepository = new BarangRepository(context);
                result = _barangRepository.Create(barang);
            }
            return result;
        }

        public List<Barang> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Barang> list = new List<Barang>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _barangRepository = new BarangRepository(context);
                list = _barangRepository.ReadByNama(nama);
            }
            return list;
        }
        public List<Barang> ReadAll()
        {
            // membuat objek collection
            List<Barang> list = new List<Barang>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _barangRepository = new BarangRepository(context);
                list = _barangRepository.ReadAll();
            }
            return list;
        }

        public int Update(Barang barang)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _barangRepository = new BarangRepository(context);
                result = _barangRepository.Update(barang);
            }

            return result;
        }

        public int Delete(Barang barang)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _barangRepository = new BarangRepository(context);
                result = _barangRepository.Delete(barang);
            }

            return result;
        }


    }
}
