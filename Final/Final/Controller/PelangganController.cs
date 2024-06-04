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
    public class PelangganController
    {
        private PelangganRepository _pelangganRepository;

        public int Create(Pelanggan pelanggan)
        {
            int result = 0;
            if (string.IsNullOrEmpty(pelanggan.PelangganID))
            {
                MessageBox.Show("ID Pelanggan harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pelanggan.Nama))
            {
                MessageBox.Show("Nama Pelanggan harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pelanggan.Alamat))
            {
                MessageBox.Show("Alamat Pelanggan harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pelanggan.Email))
            {
                MessageBox.Show("Email Pelanggan harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pelanggan.NomorTelepon))
            {
                MessageBox.Show("Nomor Telepon Pelanggan harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _pelangganRepository = new PelangganRepository(context);
                result = _pelangganRepository.Create(pelanggan);
            }
            
            return result;
        }

        public List<Pelanggan> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Pelanggan> list = new List<Pelanggan>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _pelangganRepository = new PelangganRepository(context);
                list = _pelangganRepository.ReadByNama(nama);
            }
            return list;
        }
        public List<Pelanggan> ReadAll()
        {
            // membuat objek collection
            List<Pelanggan> list = new List<Pelanggan>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _pelangganRepository = new PelangganRepository(context);
                list = _pelangganRepository.ReadAll();
            }   
            return list;
        }

        public int Update(Pelanggan pelanggan)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _pelangganRepository = new PelangganRepository(context);
                result = _pelangganRepository.Update(pelanggan);
            }

            return result;
        }

        public int Delete(Pelanggan pelanggan)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _pelangganRepository = new PelangganRepository(context);
                result = _pelangganRepository.Delete(pelanggan);
            }

            return result;
        }


    }
}
