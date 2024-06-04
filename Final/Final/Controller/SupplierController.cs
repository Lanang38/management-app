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
    public class SupplierController
    {
        private SupplierRepository _supplierRepository;

        public int Create(Supplier supplier)
        {
            int result = 0;
            if (string.IsNullOrEmpty(supplier.SupplierID))
            {
                MessageBox.Show("ID Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(supplier.NamaSupplier))
            {
                MessageBox.Show("Nama Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(supplier.AlamatSupplier))
            {
                MessageBox.Show("Alamat Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(supplier.KontakSupplier))
            {
                MessageBox.Show("Kontak Supplier harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _supplierRepository = new SupplierRepository(context);
                result = _supplierRepository.Create(supplier);
            }
            return result;
        }

        public List<Supplier> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Supplier> list = new List<Supplier>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _supplierRepository = new SupplierRepository(context);
                list = _supplierRepository.ReadByNama(nama);
            }
            return list;
        }
        public List<Supplier> ReadAll()
        {
            // membuat objek collection
            List<Supplier> list = new List<Supplier>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _supplierRepository = new SupplierRepository(context);
                list = _supplierRepository.ReadAll();
            }
            return list;
        }

        public int Update(Supplier supplier)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _supplierRepository = new SupplierRepository(context);
                result = _supplierRepository.Update(supplier);
            }

            return result;
        }

        public int Delete(Supplier supplier)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _supplierRepository = new SupplierRepository(context);
                result = _supplierRepository.Delete(supplier);
            }

            return result;
        }
    }
}
