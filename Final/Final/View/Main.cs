using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final.View
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignOUT_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login loginFrom = new Login();
                loginFrom.Show();
                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            FrmDashboard dashForm = dashboard1 as FrmDashboard;

            dashboard1.Visible = true;
            barang1.Visible = false;
            pelanggan1.Visible = false;
            supplier1.Visible = false;
            transaksi1.Visible = false;

            if(dashForm != null)
            {
                dashForm.RefreshData();
            }

        }

        private void Pelanggan_btn_Click(object sender, EventArgs e)
        {
            FrmPelanggan pelangganForm = pelanggan1 as FrmPelanggan;

            dashboard1.Visible = false;
            barang1.Visible = false;
            pelanggan1.Visible = true;
            supplier1.Visible = false;
            transaksi1.Visible = false;

            if (pelangganForm != null)
            {
                pelangganForm.RefreshData();
            }
        }

        private void Barang_btn_Click(object sender, EventArgs e)
        {
            FrmBarang barangForm = barang1 as FrmBarang;

            dashboard1.Visible = false;
            barang1.Visible = true;
            pelanggan1.Visible = false;
            supplier1.Visible = false;
            transaksi1.Visible = false;

            if (barangForm != null)
            {
                barangForm.RefreshData();
            }
        }

        private void Supplier_btn_Click(object sender, EventArgs e)
        {
            FrmSupplier supplierForm = supplier1 as FrmSupplier;

            dashboard1.Visible = false;
            barang1.Visible = false;
            pelanggan1.Visible = false;
            supplier1.Visible = true;
            transaksi1.Visible = false;

            if (supplierForm != null)
            {
                supplierForm.RefreshData();
            }
        }

        private void Transaksi_btn_Click(object sender, EventArgs e)
        {
            FrmTransaksi transaksiForm = transaksi1 as FrmTransaksi;

            dashboard1.Visible = false;
            barang1.Visible = false;
            pelanggan1.Visible = false;
            supplier1.Visible = false;
            transaksi1.Visible = true;

            if (transaksiForm != null)
            {
                transaksiForm.RefreshData();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
