using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final.Controller;
using Final.Model.Entity;

namespace Final.View
{
    public partial class FrmPelanggan : UserControl
    {
        private List<Pelanggan> pelangganList = new List<Pelanggan>();
        private PelangganController controller;
        public FrmPelanggan()
        {
            InitializeComponent();
            controller = new PelangganController();
            InisialisasiListView();
            LoadDataPelanggan();

            listPelanggan.SelectedIndexChanged += listPelanggan_SelectedIndexChanged;
        }
        private void LoadDataPelanggan()
        {
            // kosongkan listview
            listPelanggan.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            pelangganList = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var pelanggan in pelangganList)
            {
                var noUrut = listPelanggan.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pelanggan.PelangganID);
                item.SubItems.Add(pelanggan.Nama);
                item.SubItems.Add(pelanggan.Alamat);
                item.SubItems.Add(pelanggan.Email);
                item.SubItems.Add(pelanggan.NomorTelepon);
                listPelanggan.Items.Add(item);
            }
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
        }
        private bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }
        private void InisialisasiListView()
        {
            listPelanggan.View = System.Windows.Forms.View.Details;
            listPelanggan.FullRowSelect = true;
            listPelanggan.GridLines = true;
            listPelanggan.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            listPelanggan.Columns.Add("ID.", 95, HorizontalAlignment.Center);
            listPelanggan.Columns.Add("Nama", 175, HorizontalAlignment.Center);
            listPelanggan.Columns.Add("Alamat", 200, HorizontalAlignment.Center);
            listPelanggan.Columns.Add("E-Mail", 175, HorizontalAlignment.Center);
            listPelanggan.Columns.Add("No.Telepon", 120, HorizontalAlignment.Center);

        }

        private void listPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPelanggan.SelectedItems.Count > 0)
            {
                var selectedItem = listPelanggan.SelectedItems[0];
                txtId.Text = selectedItem.SubItems[1].Text;
                txtNama.Text = selectedItem.SubItems[2].Text;
                txtAlamat.Text = selectedItem.SubItems[3].Text;
                txtMail.Text = selectedItem.SubItems[4].Text;
                txtNo.Text = selectedItem.SubItems[5].Text;

            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (listPelanggan.SelectedItems.Count > 0)
            {
                try
                {
                    // Ambil indeks dari item yang dipilih di ListView
                    int selectedIndex = listPelanggan.SelectedItems[0].Index;

                    // Ambil Barang yang sesuai dari List<Barang>
                    Pelanggan pelangganToDelete = pelangganList[selectedIndex];

                    // Panggil method Delete dengan Barang yang akan dihapus
                    int result = controller.Delete(pelangganToDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Barang berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataPelanggan(); // Refresh data setelah menghapus data barang
                        txtId.Text = "";
                        txtNama.Text = "";
                        txtAlamat.Text = "";
                        txtMail.Text = "";
                        txtNo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Barang gagal dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu barang untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listPelanggan.SelectedItems.Count > 0)
            {
                try
                {
                    string id = txtId.Text;
                    string nama = txtNama.Text;
                    string alamat = txtAlamat.Text;
                    string mail = txtMail.Text;
                    string nomor = txtNo.Text;

                    if (!IsNumeric(nomor))
                    {
                        MessageBox.Show("Pastikan input Nomor Telepon adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Pelanggan pelanggan = new Pelanggan
                    {
                        PelangganID = id,
                        Nama = nama,
                        Alamat = alamat,
                        Email = mail,
                        NomorTelepon = nomor
                    };

                    int result = controller.Update(pelanggan);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Pelanggan berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataPelanggan();
                        txtId.Text = "";
                        txtNama.Text = "";
                        txtAlamat.Text = "";
                        txtMail.Text = "";
                        txtNo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Pelanggan gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }   
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu barang untuk diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string nama = txtNama.Text;
                string alamat = txtAlamat.Text;
                string mail = txtMail.Text;
                string nomor = txtNo.Text;

                if (!IsNumeric(nomor))
                {
                    MessageBox.Show("Pastikan input Nomor Telepon adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Pelanggan pelanggan = new Pelanggan
                {
                    PelangganID = id,
                    Nama = nama,
                    Alamat = alamat,
                    Email = mail,
                    NomorTelepon = nomor
                };

                int result = controller.Create(pelanggan);
                if (result > 0)
                {
                    MessageBox.Show("Data Pelanggan berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPelanggan(); // Refresh data setelah menambahkan barang baru
                    txtId.Text = "";
                    txtNama.Text = "";
                    txtAlamat.Text = "";
                    txtMail.Text = "";
                    txtNo.Text = "";

                }
                else
                {
                    MessageBox.Show("Data Pelanggan gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKambali_Click(object sender, EventArgs e)
        {
            listPelanggan.Items.Clear();

            // Display all the original items in the ListView (from barangList)
            foreach (var pelanggan in pelangganList)
            {
                var noUrut = listPelanggan.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pelanggan.PelangganID);
                item.SubItems.Add(pelanggan.Nama);
                item.SubItems.Add(pelanggan.Alamat);
                item.SubItems.Add(pelanggan.Email);
                item.SubItems.Add(pelanggan.NomorTelepon);
                listPelanggan.Items.Add(item);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower(); // Get the search keyword

            // Filter the barangList based on the keyword
            var filteredPelanggan = pelangganList.Where(pelanggan =>
                pelanggan.Nama.ToLower().Contains(keyword)
            ).ToList();

            // Clear the ListView
            listPelanggan.Items.Clear();

            // Display the filtered items in the ListView
            foreach (var pelanggan in filteredPelanggan)
            {
                var noUrut = listPelanggan.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pelanggan.PelangganID);
                item.SubItems.Add(pelanggan.Nama);
                item.SubItems.Add(pelanggan.Alamat);
                item.SubItems.Add(pelanggan.Email);
                item.SubItems.Add(pelanggan.NomorTelepon);
                listPelanggan.Items.Add(item);
            }
        }
    }
}
