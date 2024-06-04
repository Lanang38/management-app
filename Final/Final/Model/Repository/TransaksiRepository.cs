using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Final.Model.Context;
using Final.Model.Entity;

namespace Final.Model.Repository
{
    public class TransaksiRepository
    {
        private SQLiteConnection _conn;
        public TransaksiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Transaksi transaksi)
        {
            int result = 0;
            string sql = @"INSERT INTO Transaksi (TransaksiID, PelangganID, BarangID, SupplierID, JumlahBarang, TanggalTransaksi, Total) 
                           VALUES (@transaksiId, @pelangganId, @barangId, @supplierId, @jumlahBarang, @tanggal, @total)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@transaksiId", transaksi.TransaksiID);
                cmd.Parameters.AddWithValue("@pelangganId", transaksi.PelangganID);
                cmd.Parameters.AddWithValue("@barangId", transaksi.BarangID);
                cmd.Parameters.AddWithValue("@supplierId", transaksi.SupplierID);
                cmd.Parameters.AddWithValue("@jumlahBarang", transaksi.JumlahBarang);
                cmd.Parameters.AddWithValue("@tanggal", transaksi.TanggalTransaksi);
                cmd.Parameters.AddWithValue("@total", transaksi.Total);


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

        public List<Transaksi> ReadAll()
        {
            List<Transaksi> list = new List<Transaksi>();
            try
            {
                string sql = @"SELECT TransaksiID, PelangganID, BarangID, SupplierID, JumlahBarang, TanggalTransaksi, Total FROM Transaksi";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaksi transaksi = new Transaksi();

                            transaksi.TransaksiID = reader["TransaksiID"].ToString();
                            transaksi.PelangganID = reader["PelangganID"].ToString();
                            transaksi.BarangID = reader["BarangID"].ToString();
                            transaksi.SupplierID = reader["SupplierID"].ToString();
                            transaksi.JumlahBarang = Convert.ToInt32(reader["JumlahBarang"]);
                            transaksi.TanggalTransaksi = reader["TanggalTransaksi"].ToString();
                            transaksi.Total = Convert.ToInt32(reader["Total"]);


                            list.Add(transaksi);
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
        public List<Transaksi> ReadByNama(string nama)
        {
            List<Transaksi> list = new List<Transaksi>();
            try
            {

                string sql = @"SELECT TransaksiID, PelangganID, BarangID, SupplierID, JumlahBarang, TanggalTransaksi, Total FROM Transaksi";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                Transaksi transaksi = new Transaksi();

                                transaksi.TransaksiID = reader["TransaksiID"].ToString();
                                transaksi.PelangganID = reader["PelangganID"].ToString();
                                transaksi.BarangID = reader["BarangID"].ToString();
                                transaksi.SupplierID = reader["SupplierID"].ToString();
                                transaksi.JumlahBarang = Convert.ToInt32(reader["JumlahBarang"]);
                                transaksi.TanggalTransaksi = reader["TanggalTransaksi"].ToString();
                                transaksi.Total = Convert.ToInt32(reader["Total"]);



                                list.Add(transaksi);
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


        public int Update(Transaksi transaksi)
        {
            int result = 0;
            string sql = @"UPDATE Transaksi SET PelangganID = @pelangganId, BarangID = @barangId, SupplierID = @supplierId,
                   JumlahBarang = @jumlahBarang, TanggalTransaksi = @tanggal, Total = @total WHERE TransaksiID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@pelangganId", transaksi.PelangganID);
                cmd.Parameters.AddWithValue("@barangId", transaksi.BarangID);
                cmd.Parameters.AddWithValue("@supplierId", transaksi.SupplierID);
                cmd.Parameters.AddWithValue("@jumlahBarang", transaksi.JumlahBarang);
                cmd.Parameters.AddWithValue("@tanggal", transaksi.TanggalTransaksi);
                cmd.Parameters.AddWithValue("@total", transaksi.Total);
                cmd.Parameters.AddWithValue("@id", transaksi.TransaksiID);

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

        public int Delete(Transaksi transaksi)
        {
            int result = 0;
            string sql = @"DELETE FROM Transaksi WHERE TransaksiID = @transaksiId";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@transaksiId", transaksi.TransaksiID);

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