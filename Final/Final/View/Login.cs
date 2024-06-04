using Final.Model.Context;
using Final.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace Final
{
    public partial class Login : Form
    {
        private SQLiteConnection _conn;
        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                string dbName = @"D:\Final2\Final\Database\Final.db";

                string connectionString = string.Format("Data Source={0};FailIfMissing=True", dbName);

                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
            }
            return conn;
        }
        public Login()
        {
            InitializeComponent();
            // Di konstruktor atau pada saat inisialisasi komponen
            login_username.KeyPress += new KeyPressEventHandler(login_username_KeyPress);
            login_password.KeyPress += new KeyPressEventHandler(login_password_KeyPress);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            Regis regisform = new Regis();
            regisform.Show();
            this.Hide();
        }

        private void login_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_ShowPass.Checked ? '\0' : '*';
        }

        private void login_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Menahan karakter 'Enter' agar tidak ditampilkan di TextBox username
                login_password.Focus(); // Pindah fokus ke TextBox password
            }
        }

        private void login_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                login_btn.PerformClick(); // Simulasikan klik pada tombol login
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection _conn = new SQLiteConnection("Data Source=D:\\Final2\\Final\\Database\\Final.db"))
                {
                    if (string.IsNullOrWhiteSpace(login_username.Text) || string.IsNullOrWhiteSpace(login_password.Text))
                    {
                        MessageBox.Show("Nama dan Password harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "SELECT COUNT(*) FROM Masuk WHERE Username = @Username AND Password = @Password";
                    var parameters = new { Username = login_username.Text, Password = login_password.Text };

                    int count = _conn.QueryFirstOrDefault<int>(query, parameters);

                    if (count > 0)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Main mainForm = new Main();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
