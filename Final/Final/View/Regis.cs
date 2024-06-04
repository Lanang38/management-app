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
    public partial class Regis : Form
    {
        private readonly Final.Model.Context.DbContext dbContext;
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

        public Regis()
        {
            InitializeComponent();
            signup_username.KeyDown += Signup_username_KeyDown;
            signup_password.KeyDown += Signup_password_KeyDown;
            dbContext = new Final.Model.Context.DbContext();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_loginBtn_Click(object sender, EventArgs e)
        {
            Login loginFrom = new Login();
            loginFrom.Show();
            this.Hide();
        }

        private void signup_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_ShowPass.Checked ? '\0' : '*';
        }

        private void Signup_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Menghentikan suara 'ding' bawaan dari sistem
                e.Handled = true; // Menandai event sebagai sudah ditangani
                signup_password.Focus(); // Pindah fokus ke TextBox password
            }
        }

        private void Signup_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                signup_btn.PerformClick(); // Mensimulasikan klik pada tombol sign up
            }
        }


        private void signup_btn_Click(object sender, EventArgs e)
        {
            string username = signup_username.Text;
            string password = signup_password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InsertUserData(username, password))
            {
                MessageBox.Show("Signup successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Data Sudah Ada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InsertUserData(string username, string password)
        {
            try
            {
                using (SQLiteConnection connection = Conn)
                {
                    int rowsAffected = connection.Execute("INSERT INTO Masuk (Username, Password) VALUES (@Username, @Password)",
                        new { Username = username, Password = password });

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

