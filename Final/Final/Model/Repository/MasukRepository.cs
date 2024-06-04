using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Final.Model.Context;
using Final.Model.Entity;

namespace Final.Model.Repository
{
    public class MasukRepository
    {
        private SQLiteConnection _conn;

        public MasukRepository(DbContext context)
        {
            _conn = context.Conn;
        }


        public int Create(Masuk login)
        {
            int result = 0;
            string sql = @"INSERT INTO Login (Username, Password) VALUES (@username, @password)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@password", login.Password);

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

        public List<Masuk> ReadAll()
        {
            List<Masuk> list = new List<Masuk>(); // Ganti List<Login> menjadi List<Masuk>
            try
            {
                string sql = @"SELECT Username, Password FROM Login";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Masuk login = new Masuk(); // Ganti Masuk login = new Masuk
                            login.Username = reader["Username"].ToString();
                            login.Password = reader["Password"].ToString();


                            list.Add(login); // Ubah Masuk menjadi login
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

        public List<Masuk> ReadByNama(string nama)
        {
            List<Masuk> list = new List<Masuk>();
            try
            {

                string sql = @"SELECT Username, Password FROM Login";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                Masuk login = new Masuk(); // Ganti Masuk login = new Masuk
                                login.Username = reader["Username"].ToString();
                                login.Password = reader["Password"].ToString();


                                list.Add(login); // Ubah Masuk menjadi login
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

        public int Update(Masuk login)
        {
            int result = 0;
            string sql = @"UPDATE Login SET Password = @password WHERE Username = @username";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@password", login.Password);
                cmd.Parameters.AddWithValue("@username", login.Username);

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

        public int Delete(string username)
        {
            int result = 0;

            string sql = @"DELETE FROM Login WHERE Username = @username";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", username);

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
    }
}