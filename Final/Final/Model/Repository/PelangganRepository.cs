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
    public class PelangganRepository
    {
        private SQLiteConnection _conn;

        public PelangganRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Pelanggan pelanggan)
        {
            int result = 0;
            string sql = @"INSERT INTO Pelanggan (PelangganID, Nama, Alamat, Email, NomorTelepon) VALUES (@id, @nama, @alamat, @email, @nomorTelepon)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", pelanggan.PelangganID);
                cmd.Parameters.AddWithValue("@nama", pelanggan.Nama);
                cmd.Parameters.AddWithValue("@alamat", pelanggan.Alamat);
                cmd.Parameters.AddWithValue("@email", pelanggan.Email);
                cmd.Parameters.AddWithValue("@nomorTelepon", pelanggan.NomorTelepon);
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

        public List<Pelanggan> ReadAll()
        {
            List<Pelanggan> list = new List<Pelanggan>();
            try
            {

                string sql = @"SELECT PelangganID, Nama, Alamat, Email, NomorTelepon FROM Pelanggan";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pelanggan pelanggan = new Pelanggan();
                            pelanggan.PelangganID = reader["PelangganID"].ToString();
                            pelanggan.Nama = reader["Nama"].ToString();
                            pelanggan.Alamat = reader["Alamat"].ToString();
                            pelanggan.Email = reader["Email"].ToString();
                            pelanggan.NomorTelepon = reader["NomorTelepon"].ToString();

                            list.Add(pelanggan);
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

        public List<Pelanggan> ReadByNama(string nama)
        {
            List<Pelanggan> list = new List<Pelanggan>();
            try
            {

                string sql = @"SELECT PelangganID, Nama, Alamat, Email, NomorTelepon FROM Pelanggan";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                Pelanggan pelanggan = new Pelanggan();
                                pelanggan.PelangganID = reader["PelangganID"].ToString();
                                pelanggan.Nama = reader["Nama"].ToString();
                                pelanggan.Alamat = reader["Alamat"].ToString();
                                pelanggan.Email = reader["Email"].ToString();
                                pelanggan.NomorTelepon = reader["NomorTelepon"].ToString();

                                list.Add(pelanggan);
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


        public int Update(Pelanggan pelanggan)
        {
            int result = 0;
            string sql = @"UPDATE Pelanggan SET Nama = @nama, Alamat = @alamat, Email = @email,
                           NomorTelepon = @nomorTelepon WHERE PelangganID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", pelanggan.Nama);
                cmd.Parameters.AddWithValue("@alamat", pelanggan.Alamat);
                cmd.Parameters.AddWithValue("@email", pelanggan.Email);
                cmd.Parameters.AddWithValue("@nomorTelepon", pelanggan.NomorTelepon);
                cmd.Parameters.AddWithValue("@id", pelanggan.PelangganID);

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

        public int Delete(Pelanggan pelanggan)
        {
            int result = 0;
            string sql = @"DELETE FROM Pelanggan WHERE PelangganID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", pelanggan.PelangganID);

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