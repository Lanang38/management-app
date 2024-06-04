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
    public partial class FrmBarang : UserControl
    {
        private List<Barang> barangList = new List<Barang>();
        private BarangController controller;

        public FrmBarang()
        {
            InitializeComponent();
            controller = new BarangController();
            InisialisasiListView();
            LoadDataBarang();

            listBarang.SelectedIndexChanged += listBarang_SelectedIndexChanged;
        }
        private void LoadDataBarang()
        {
            // kosongkan listview
            listBarang.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            barangList = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var barang in barangList)
            {
                var noUrut = listBarang.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(barang.BarangID);
                item.SubItems.Add(barang.NamaBarang);
                item.SubItems.Add(barang.Deskripsi);
                item.SubItems.Add(barang.Harga.ToString());
                item.SubItems.Add(barang.Stok.ToString());
                listBarang.Items.Add(item);
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
        private void InisialisasiListView()
        {
            listBarang.View = System.Windows.Forms.View.Details;
            listBarang.FullRowSelect = true;
            listBarang.GridLines = true;
            listBarang.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            listBarang.Columns.Add("ID.", 95, HorizontalAlignment.Center);
            listBarang.Columns.Add("Nama", 175, HorizontalAlignment.Center);
            listBarang.Columns.Add("Deskripsi", 200, HorizontalAlignment.Center);
            listBarang.Columns.Add("Harga", 175, HorizontalAlignment.Center);
            listBarang.Columns.Add("Stok", 120, HorizontalAlignment.Center);

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string nama = txtNama.Text;
                string deskripsi = txtDeskripsi.Text;
                int harga = int.Parse(txtHarga.Text);
                int stok = int.Parse(txtStok.Text); // Pastikan bahwa txtStok.Text berisi nilai yang dapat di-parse ke integer

                Barang barang = new Barang
                {
                    BarangID = id,
                    NamaBarang = nama,
                    Deskripsi = deskripsi,
                    Harga = harga,
                    Stok = stok
                };

                int result = controller.Create(barang);
                if (result > 0)
                {
                    MessageBox.Show("Data Barang berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataBarang(); // Refresh data setelah menambahkan barang baru
                    txtId.Text = "";
                    txtNama.Text = "";
                    txtDeskripsi.Text = "";
                    txtHarga.Text = "";
                    txtStok.Text = "";
                }
                else
                {
                    MessageBox.Show("Data Barang gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Pastikan input Stok adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (listBarang.SelectedItems.Count > 0)
            {
                try
                {
                    // Ambil indeks dari item yang dipilih di ListView
                    int selectedIndex = listBarang.SelectedItems[0].Index;

                    // Ambil Barang yang sesuai dari List<Barang>
                    Barang barangToDelete = barangList[selectedIndex];

                    // Panggil method Delete dengan Barang yang akan dihapus
                    int result = controller.Delete(barangToDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Barang berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataBarang(); // Refresh data setelah menghapus data barang
                        txtId.Text = "";
                        txtNama.Text = "";
                        txtDeskripsi.Text = "";
                        txtHarga.Text = "";
                        txtStok.Text = "";
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
           if (listBarang.SelectedItems.Count > 0)
            {
                try
                {
                    string id = txtId.Text;
                    string nama = txtNama.Text;
                    string deskripsi = txtDeskripsi.Text;
                    int harga = int.Parse(txtHarga.Text);
                    int stok = int.Parse(txtStok.Text);
                    
                    Barang barang = new Barang
                    {
                        BarangID = id,
                        NamaBarang = nama,
                        Deskripsi = deskripsi,
                        Harga = harga,
                        Stok = stok
                    };
                    
                    int result = controller.Update(barang);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Barang berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataBarang();
                        txtId.Text = "";
                        txtNama.Text = "";
                        txtDeskripsi.Text = "";
                        txtHarga.Text = "";
                        txtStok.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Barang gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Pastikan input Stok adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void listBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBarang.SelectedItems.Count > 0)
            {
                var selectedItem = listBarang.SelectedItems[0];
                txtId.Text = selectedItem.SubItems[1].Text;
                txtNama.Text = selectedItem.SubItems[2].Text;
                txtDeskripsi.Text = selectedItem.SubItems[3].Text;
                txtHarga.Text = selectedItem.SubItems[4].Text;
                txtStok.Text = selectedItem.SubItems[5].Text;

            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower(); // Get the search keyword

            // Filter the barangList based on the keyword
            var filteredBarang = barangList.Where(barang =>
                barang.NamaBarang.ToLower().Contains(keyword) ||
                barang.Deskripsi.ToLower().Contains(keyword)
            ).ToList();

            // Clear the ListView
            listBarang.Items.Clear();

            // Display the filtered items in the ListView
            foreach (var barang in filteredBarang)
            {
                var noUrut = listBarang.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(barang.BarangID);
                item.SubItems.Add(barang.NamaBarang);
                item.SubItems.Add(barang.Deskripsi);
                item.SubItems.Add(barang.Harga.ToString());
                item.SubItems.Add(barang.Stok.ToString());
                listBarang.Items.Add(item);
            }

        }

        private void btnKambali_Click(object sender, EventArgs e)
        {
            // Clear the ListView
            listBarang.Items.Clear();

            // Display all the original items in the ListView (from barangList)
            foreach (var barang in barangList)
            {
                var noUrut = listBarang.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(barang.BarangID);
                item.SubItems.Add(barang.NamaBarang);
                item.SubItems.Add(barang.Deskripsi);
                item.SubItems.Add(barang.Harga.ToString());
                item.SubItems.Add(barang.Stok.ToString());
                listBarang.Items.Add(item);
            }
        }
    }
}

