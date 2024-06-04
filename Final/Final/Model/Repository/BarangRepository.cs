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
    public class BarangRepository
    {
        private SQLiteConnection _conn;

        public BarangRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Barang barang)
        {
            int result = 0;
            string sql = @"INSERT INTO Barang (BarangID, NamaBarang, Deskripsi, Harga, Stok) VALUES (@id, @nama, @deskripsi, @harga, @stok)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", barang.BarangID);
                cmd.Parameters.AddWithValue("@nama", barang.NamaBarang);
                cmd.Parameters.AddWithValue("@deskripsi", barang.Deskripsi);
                cmd.Parameters.AddWithValue("@harga", barang.Harga);
                cmd.Parameters.AddWithValue("@stok", barang.Stok);
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

        public List<Barang> ReadAll()
        {
            List<Barang> list = new List<Barang>();
            try
            {

                string sql = @"SELECT BarangID, NamaBarang, Deskripsi, Harga, Stok FROM Barang";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Barang barang = new Barang();
                            barang.BarangID = reader["BarangID"].ToString();
                            barang.NamaBarang = reader["NamaBarang"].ToString();
                            barang.Deskripsi = reader["Deskripsi"].ToString();
                            barang.Harga = Convert.ToInt32(reader["Harga"]);
                            barang.Stok = Convert.ToInt32(reader["Stok"]);

                            list.Add(barang);
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

        public List<Barang> ReadByNama(string nama)
        {
            List<Barang> list = new List<Barang>();
            try
            {

                string sql = @"SELECT BarangID, NamaBarang, Deskripsi, Harga, Stok FROM Barang WHERE NamaBarang LIKE @nama";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                Barang barang = new Barang();
                                barang.BarangID = reader["BarangID"].ToString();
                                barang.NamaBarang = reader["NamaBarang"].ToString();
                                barang.Deskripsi = reader["Deskripsi"].ToString();
                                barang.Harga = Convert.ToInt32(reader["Harga"]);
                                barang.Stok = Convert.ToInt32(reader["Stok"]);

                                list.Add(barang);
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
        public int Update(Barang barang)
        {
            int result = 0;
            string sql = @"UPDATE Barang SET NamaBarang = @nama, Deskripsi = @deskripsi, Harga = @harga, Stok = @stok WHERE BarangID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", barang.NamaBarang);
                cmd.Parameters.AddWithValue("@deskripsi", barang.Deskripsi);
                cmd.Parameters.AddWithValue("@harga", barang.Harga);
                cmd.Parameters.AddWithValue("@stok", barang.Stok);
                cmd.Parameters.AddWithValue("@id", barang.BarangID);

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

        public int Delete(Barang barang)
        {
            int result = 0;
            string sql = @"DELETE FROM Barang WHERE BarangID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", barang.BarangID);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result; // Tambahkan kembalikan nilai result di sini
        }

    }
}