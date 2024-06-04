using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Final.Model.Entity;
using Final.Model.Context;

namespace Final.Model.Repository
{
    public class SupplierRepository
    {
        private SQLiteConnection _conn;

        public SupplierRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Supplier supplier)
        {
            int result = 0;
            string sql = @"INSERT INTO Supplier (SupplierID, NamaSupplier, AlamatSupplier, KontakSupplier) VALUES (@id, @nama, @alamat, @kontak)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", supplier.SupplierID);
                cmd.Parameters.AddWithValue("@nama", supplier.NamaSupplier);
                cmd.Parameters.AddWithValue("@alamat", supplier.AlamatSupplier);
                cmd.Parameters.AddWithValue("@kontak", supplier.KontakSupplier);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }

            }
            return result;
        }

        public List<Supplier> ReadAll()
        {
            List<Supplier> list = new List<Supplier>();
            try
            {
                string sql = @"SELECT SupplierID, NamaSupplier, AlamatSupplier, KontakSupplier FROM Supplier";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();
                            supplier.SupplierID = reader["SupplierID"].ToString();
                            supplier.NamaSupplier = reader["NamaSupplier"].ToString();
                            supplier.AlamatSupplier = reader["AlamatSupplier"].ToString();
                            supplier.KontakSupplier = reader["KontakSupplier"].ToString();

                            list.Add(supplier);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }

        public List<Supplier> ReadByNama(string nama)
        {
            List<Supplier> list = new List<Supplier>();
            try
            {

                string sql = @"SELECT SupplierID, NamaSupplier, AlamatSupplier, KontakSupplier FROM Supplier";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                Supplier supplier = new Supplier();
                                supplier.SupplierID = reader["SupplierID"].ToString();
                                supplier.NamaSupplier = reader["NamaSupplier"].ToString();
                                supplier.AlamatSupplier = reader["AlamatSupplier"].ToString();
                                supplier.KontakSupplier = reader["KontakSupplier"].ToString();

                                list.Add(supplier);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }
            return list;
        }

        public int Update(Supplier supplier)
        {
            int result = 0;
            string sql = @"UPDATE Supplier SET NamaSupplier = @nama, AlamatSupplier = @alamat, KontakSupplier = @kontak WHERE SupplierID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", supplier.NamaSupplier);
                cmd.Parameters.AddWithValue("@alamat", supplier.AlamatSupplier);
                cmd.Parameters.AddWithValue("@kontak", supplier.KontakSupplier);
                cmd.Parameters.AddWithValue("@id", supplier.SupplierID);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }

            }
            return result;
        }

        public int Delete(Supplier supplierId)
        {
            int result = 0;
            string sql = @"DELETE FROM Supplier WHERE SupplierID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", supplierId.SupplierID);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }

            }
            return result;
        }
    }
}