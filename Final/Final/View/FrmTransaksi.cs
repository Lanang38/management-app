using Final.Controller;
using Final.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final.View
{
    public partial class FrmTransaksi : UserControl
    {
        private List<Transaksi> TransaksiList = new List<Transaksi>();
        private List<Pelanggan> PelangganList = new List<Pelanggan>();
        private List<Barang> BarangList = new List<Barang>();
        private List<Supplier> SuppliersList = new List<Supplier>();
        private TransaksiController TransaksiController;
        private PelangganController pelangganController;
        private BarangController barangController;
        private SupplierController supplierController;


        public FrmTransaksi()
        {
            InitializeComponent();
            TransaksiController = new TransaksiController();
            pelangganController = new PelangganController();
            barangController = new BarangController();
            supplierController = new SupplierController();
            InisialisasiListView();
            LoadDataTransaksi();
            ConfigureComboBoxes();
            listTransaksi.SelectedIndexChanged += listTransaksi_SelectedIndexChanged;
            txtJumlah.TextChanged += txtJumlah_TextChanged;

        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
        }
        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtJumlah.Text)) // Periksa jika tidak kosong
            {
                if (int.TryParse(txtJumlah.Text, out int jumlahBarang))
                {
                    if (cmbBarang.SelectedItem != null)
                    {
                        string selectedBarang = cmbBarang.SelectedItem.ToString();

                        Barang selected = BarangList.FirstOrDefault(barang => barang.NamaBarang == selectedBarang);

                        if (selected != null)
                        {
                            int hargaTotal = jumlahBarang * selected.Harga;
                            txtTotal.Text = hargaTotal.ToString();
                        }
                    }
                }
                else
                {
                    // Jika input tidak valid, tampilkan pesan atau lakukan penanganan lainnya
                    MessageBox.Show("Jumlah barang harus dalam bentuk angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void InisialisasiListView()
        {
            listTransaksi.View = System.Windows.Forms.View.Details;
            listTransaksi.FullRowSelect = true;
            listTransaksi.GridLines = true;
            listTransaksi.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            listTransaksi.Columns.Add("ID.", 95, HorizontalAlignment.Center);
            listTransaksi.Columns.Add("Tanggal", 175, HorizontalAlignment.Center);
            listTransaksi.Columns.Add("Barang", 175, HorizontalAlignment.Center);
            listTransaksi.Columns.Add("Pelanggan", 200, HorizontalAlignment.Center);
            listTransaksi.Columns.Add("Supplier", 175, HorizontalAlignment.Center);
            listTransaksi.Columns.Add("Jumlah", 175, HorizontalAlignment.Center);
            listTransaksi.Columns.Add("Harga Total", 175, HorizontalAlignment.Center);
        }
        private void LoadDataTransaksi()
        {
            // kosongkan listview
            listTransaksi.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            TransaksiList = TransaksiController.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var transaksi in TransaksiList)
            {
                var noUrut = listTransaksi.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(transaksi.TransaksiID);
                item.SubItems.Add(DateTime.Parse(transaksi.TanggalTransaksi).ToString("yyyy-MM-dd"));
                item.SubItems.Add(transaksi.BarangID);
                item.SubItems.Add(transaksi.PelangganID);
                item.SubItems.Add(transaksi.SupplierID);
                item.SubItems.Add(transaksi.JumlahBarang.ToString());
                item.SubItems.Add(transaksi.Total.ToString()); // Tambahkan nilai total ke dalam listTransaksi
                listTransaksi.Items.Add(item);
            }
        }
        private void ConfigureComboBoxes()
        {
            cmbPelanggan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBarang.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadPelangganToComboBox();
            LoadBarangToComboBox();
            LoadSupplierToComboBox();
        }

        private void LoadPelangganToComboBox()
        {
            try
            {
                PelangganList = pelangganController.ReadAll();

                cmbPelanggan.Items.Clear(); // Bersihkan ComboBox sebelum memuat data baru

                if (PelangganList != null && PelangganList.Count > 0)
                {
                    foreach (var pelanggan in PelangganList)
                    {
                        cmbPelanggan.Items.Add(pelanggan.Nama); // Tambahkan nama pelanggan ke ComboBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadBarangToComboBox()
        {
            try
            {
                BarangList = barangController.ReadAll();

                cmbBarang.Items.Clear(); // Bersihkan ComboBox sebelum memuat data baru

                if (BarangList != null && BarangList.Count > 0)
                {
                    foreach (var barang in BarangList)
                    {
                        cmbBarang.Items.Add(barang.NamaBarang); // Tambahkan nama barang ke ComboBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadSupplierToComboBox()
        {
            try
            {
                SuppliersList = supplierController.ReadAll();

                cmbSupplier.Items.Clear(); // Bersihkan ComboBox sebelum memuat data baru

                if (SuppliersList != null && SuppliersList.Count > 0)
                {
                    foreach (var supplier in SuppliersList)
                    {
                        cmbSupplier.Items.Add(supplier.NamaSupplier); // Tambahkan nama supplier ke ComboBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void cmbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPelanggan.SelectedItem != null)
            {
                string selectedPelanggan = cmbPelanggan.SelectedItem.ToString();
                Pelanggan selected = PelangganList.FirstOrDefault(pelanggan => pelanggan.Nama == selectedPelanggan);
            }
        }

        private void cmbBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBarang.SelectedItem != null)
            {
                string selectedBarang = cmbBarang.SelectedItem.ToString();

                // Dapatkan barang yang sesuai dari list BarangList
                Barang selected = BarangList.FirstOrDefault(barang => barang.NamaBarang == selectedBarang);

                if (selected != null)
                {
                    // Set nilai harga dan stok ke dalam TextBox yang sesuai
                    txtHarga.Text = selected.Harga.ToString();
                    txtStok.Text = selected.Stok.ToString();
                }
                else
                {
                    MessageBox.Show("Barang tidak ditemukan.");
                }
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedItem != null)
            {
                string selectedSupplier = cmbSupplier.SelectedItem.ToString();
                Supplier selected = SuppliersList.FirstOrDefault(supplier => supplier.NamaSupplier == selectedSupplier);
            }
        }

        // Metode untuk mendapatkan nama pelanggan berdasarkan ID
        public string GetPelangganNameById(string id)
        {
            Pelanggan pelanggan = PelangganList.FirstOrDefault(p => p.PelangganID == id);
            return pelanggan != null ? pelanggan.Nama : string.Empty;
        }

        // Metode untuk mendapatkan nama barang berdasarkan ID
        public string GetBarangNameById(string id)
        {
            Barang barang = BarangList.FirstOrDefault(b => b.BarangID == id);
            return barang != null ? barang.NamaBarang : string.Empty;
        }

        // Metode untuk mendapatkan nama supplier berdasarkan ID
        public string GetSupplierNameById(string id)
        {
            Supplier supplier = SuppliersList.FirstOrDefault(s => s.SupplierID == id);
            return supplier != null ? supplier.NamaSupplier : string.Empty;
        }

        // Event handler saat item dipilih dalam listTransaksi
        private void listTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTransaksi.SelectedItems.Count > 0)
            {
                try
                {
                    var selectedItem = listTransaksi.SelectedItems[0];
                    txtId.Text = selectedItem.SubItems[1].Text;
                    string idPelanggan = selectedItem.SubItems[4].Text;
                    string idBarang = selectedItem.SubItems[3].Text;
                    string idSupplier = selectedItem.SubItems[5].Text;
                    txtJumlah.Text = selectedItem.SubItems[6].Text;
                    var tanggalString = selectedItem.SubItems[2].Text;

                    // Parsing string tanggal dengan format "yyyy-MM-dd"
                    DateTime parsedDate;
                    if (DateTime.TryParseExact(tanggalString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                    {
                        // Jika parsing berhasil, atur nilai dateTimeTanggal
                        dateTimeTanggal.Value = parsedDate;
                    }
                    else
                    {
                        // Jika parsing gagal, tampilkan pesan kesalahan atau lakukan penanganan kesalahan lainnya
                        MessageBox.Show("Format tanggal tidak valid!");
                    }

                    // Dapatkan nama dari ID yang dipilih dalam ComboBox
                    string namaPelanggan = GetPelangganNameById(idPelanggan);
                    string namaBarang = GetBarangNameById(idBarang);
                    string namaSupplier = GetSupplierNameById(idSupplier);

                    // Set nilai ComboBox yang sesuai
                    cmbPelanggan.SelectedItem = namaPelanggan;
                    cmbBarang.SelectedItem = namaBarang;
                    cmbSupplier.SelectedItem = namaSupplier;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Bagian dari fungsi penyimpanan data
       

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                // Mendapatkan stok barang yang dipilih dari list BarangList
                Barang selectedBarang = BarangList.FirstOrDefault(b => b.NamaBarang == cmbBarang.Text);

                if (selectedBarang != null)
                {
                    string id = txtId.Text;
                    string pelanggan = cmbPelanggan.Text;
                    string barang = cmbBarang.Text;
                    string supplier = cmbSupplier.Text;
                    int jmlBarang = int.Parse(txtJumlah.Text);
                    string tanggal = dateTimeTanggal.Value.ToString("yyyy-MM-dd");
                    int hargaTotal = int.Parse(txtTotal.Text);

                    string idPelanggan = PelangganList.FirstOrDefault(p => p.Nama == pelanggan)?.PelangganID;
                    string idBarang = BarangList.FirstOrDefault(b => b.NamaBarang == barang)?.BarangID;
                    string idSupplier = SuppliersList.FirstOrDefault(s => s.NamaSupplier == supplier)?.SupplierID;

                    // Memeriksa apakah jumlah yang dimasukkan melebihi stok yang tersedia
                    if (jmlBarang > selectedBarang.Stok)
                    {
                        MessageBox.Show("Jumlah barang melebihi stok yang tersedia!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Mengurangi stok barang yang dipilih
                        selectedBarang.Stok -= jmlBarang; // Kurangi stok barang dengan jumlah yang diinputkan pada transaksi

                        // Update stok barang yang telah diubah pada database
                        barangController.Update(selectedBarang); // Pastikan ada method Update yang mengubah data barang dalam database

                        Transaksi transaksi = new Transaksi
                        {
                            TransaksiID = id,
                            PelangganID = idPelanggan,
                            BarangID = idBarang,
                            SupplierID = idSupplier,
                            JumlahBarang = jmlBarang,
                            TanggalTransaksi = tanggal,
                            Total = hargaTotal
                        };

                        int result = TransaksiController.Create(transaksi);
                        if (result > 0)
                        {
                            MessageBox.Show("Data Transaksi berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtId.Text = "";
                            cmbPelanggan.SelectedIndex = -1;
                            cmbBarang.SelectedIndex = -1;
                            cmbSupplier.SelectedIndex = -1;
                            txtJumlah.Text = "";
                            dateTimeTanggal.Value = DateTime.Now;
                            LoadDataTransaksi();
                        }
                        else
                        {
                            MessageBox.Show("Data Transaksi gagal disimpan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Barang tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listTransaksi.SelectedItems.Count > 0)
            {
                try
                {
                    var selectedItem = listTransaksi.SelectedItems[0];
                    string idBaru = txtId.Text; // Simpan nomor ID yang baru
                    string idLama = selectedItem.SubItems[1].Text; // Simpan nomor ID yang lama dari item terpilih

                    // Periksa jika nomor ID yang baru tidak sama dengan nomor ID yang lama
                    if (idBaru != idLama)
                    {
                        // Cari nomor ID baru di dalam TransaksiList
                        bool idBaruAda = TransaksiList.Any(t => t.TransaksiID == idBaru);

                        // Jika nomor ID baru sudah ada, berikan peringatan dan hentikan pembaruan
                        if (idBaruAda)
                        {
                            MessageBox.Show("Nomor ID yang baru sudah digunakan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Melanjutkan pembaruan jika nomor ID yang baru tidak ada di database atau sama dengan nomor ID yang lama
                    string pelanggan = cmbPelanggan.Text;
                    string barang = cmbBarang.Text;
                    string supplier = cmbSupplier.Text;
                    int jmlBarang = int.Parse(txtJumlah.Text);
                    string tanggal = dateTimeTanggal.Value.ToString("yyyy-MM-dd");
                    int hargaTotal = int.Parse(txtTotal.Text);

                    string idPelanggan = PelangganList.FirstOrDefault(p => p.Nama == pelanggan)?.PelangganID;
                    string idBarang = BarangList.FirstOrDefault(b => b.NamaBarang == barang)?.BarangID;
                    string idSupplier = SuppliersList.FirstOrDefault(s => s.NamaSupplier == supplier)?.SupplierID;

                    int jmlBarangLama = int.Parse(selectedItem.SubItems[6].Text); // Ambil jumlah barang dari item terpilih sebelumnya
                    int selisihJumlahBarang = jmlBarang - jmlBarangLama;

                    // Simpan stok barang sebelumnya
                    int stokBarangSebelumnya = 0;

                    if (selisihJumlahBarang != 0)
                    {
                        // Dapatkan stok barang yang dipilih dari list BarangList
                        Barang selectedBarang = BarangList.FirstOrDefault(b => b.NamaBarang == cmbBarang.Text);

                        // Jika stok barang ditemukan
                        if (selectedBarang != null)
                        {
                            // Simpan stok barang sebelumnya
                            stokBarangSebelumnya = selectedBarang.Stok;

                            // Lakukan perubahan stok hanya jika edit berhasil
                            selectedBarang.Stok -= selisihJumlahBarang; // Tambah atau kurangi stok barang sesuai perbedaan jumlah barang

                            // Jika jumlah barang setelah diubah menjadi negatif, batalkan perubahan
                            if (selectedBarang.Stok < 0)
                            {
                                MessageBox.Show("Jumlah barang tidak cukup!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                // Kembalikan stok barang ke nilai sebelumnya
                                selectedBarang.Stok = stokBarangSebelumnya;

                                return;
                            }

                            // Update stok barang yang telah diubah pada database
                            barangController.Update(selectedBarang); // Pastikan ada method Update yang mengubah data barang dalam database
                        }
                        else
                        {
                            MessageBox.Show("Barang tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Buat objek transaksi baru dengan data yang telah diperbarui
                    Transaksi transaksi = new Transaksi
                    {
                        TransaksiID = idBaru,
                        PelangganID = idPelanggan,
                        BarangID = idBarang,
                        SupplierID = idSupplier,
                        JumlahBarang = jmlBarang,
                        TanggalTransaksi = tanggal,
                        Total = hargaTotal
                    };

                    // Lakukan update pada data transaksi
                    int result = TransaksiController.Update(transaksi);

                    if (result > 0)
                    {
                        MessageBox.Show("Data Transaksi berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtId.Text = "";
                        cmbPelanggan.SelectedIndex = -1;
                        cmbBarang.SelectedIndex = -1;
                        cmbSupplier.SelectedIndex = -1;
                        txtJumlah.Text = "";
                        dateTimeTanggal.Value = DateTime.Now;

                        // Refresh data setelah mengubah data transaksi
                        LoadDataTransaksi();
                    }
                    else
                    {
                        // Jika update gagal, kembalikan stok barang ke nilai sebelumnya
                        if (selisihJumlahBarang != 0)
                        {
                            Barang selectedBarang = BarangList.FirstOrDefault(b => b.NamaBarang == cmbBarang.Text);
                            if (selectedBarang != null)
                            {
                                selectedBarang.Stok = stokBarangSebelumnya;
                                barangController.Update(selectedBarang);
                            }
                        }

                        MessageBox.Show("Data Transaksi gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}. Pastikan input Stok adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (listTransaksi.SelectedItems.Count > 0)
            {
                try
                {
                    int selectedIndex = listTransaksi.SelectedItems[0].Index;

                    Transaksi transaksiToDelete = TransaksiList[selectedIndex];

                    int result = TransaksiController.Delete(transaksiToDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Barang berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hapus item dari listTransaksi saat data dihapus dari database
                        listTransaksi.Items.RemoveAt(selectedIndex);

                        // Hapus juga dari TransaksiList agar sinkron dengan database (jika menggunakan list tersebut)
                        TransaksiList.RemoveAt(selectedIndex);

                        // Mendapatkan jumlah barang yang dihapus
                        int jumlahBarangDihapus = transaksiToDelete.JumlahBarang;

                        // Mendapatkan ID barang yang dihapus dari transaksi
                        string idBarangDihapus = transaksiToDelete.BarangID;

                        // Mendapatkan barang yang sesuai dengan ID yang dihapus dari transaksi
                        Barang barang = BarangList.FirstOrDefault(b => b.BarangID == idBarangDihapus);

                        // Jika barang ditemukan
                        if (barang != null)
                        {
                            // Tambahkan jumlah barang yang dihapus ke stok barang
                            barang.Stok += jumlahBarangDihapus;

                            // Update stok barang yang telah diubah pada database
                            barangController.Update(barang); // Pastikan ada method Update yang mengubah data barang dalam database
                        }

                        // Bersihkan kontrol input
                        txtId.Text = string.Empty;
                        cmbPelanggan.SelectedIndex = -1;
                        cmbBarang.SelectedIndex = -1;
                        cmbSupplier.SelectedIndex = -1;
                        txtJumlah.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Data Transaksi gagal dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower(); // Get the search keyword

            // Filter the TransaksiList based on the keyword
            var filteredTransaksi = TransaksiList.Where(transaksi =>
                transaksi.TransaksiID.ToLower().Contains(keyword) 
            ).ToList();

            // Clear the listTransaksi ListView
            listTransaksi.Items.Clear();

            // Display the filtered items in the listTransaksi ListView
            foreach (var transaksi in filteredTransaksi)
            {
                var noUrut = listTransaksi.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(transaksi.TransaksiID);
                item.SubItems.Add(DateTime.Parse(transaksi.TanggalTransaksi).ToString("yyyy-MM-dd"));
                item.SubItems.Add(transaksi.BarangID);
                item.SubItems.Add(transaksi.PelangganID);
                item.SubItems.Add(transaksi.SupplierID);
                item.SubItems.Add(transaksi.JumlahBarang.ToString());
                item.SubItems.Add(transaksi.Total.ToString());
                listTransaksi.Items.Add(item);
            }
        }

        private void btnKambali_Click(object sender, EventArgs e)
        {
            // Clear the ListView
            listTransaksi.Items.Clear();

            // Display all the original items in the ListView (from barangList)
            foreach (var transaksi in TransaksiList)
            {
                var noUrut = listTransaksi.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(transaksi.TransaksiID);
                item.SubItems.Add(DateTime.Parse(transaksi.TanggalTransaksi).ToString("yyyy-MM-dd"));
                item.SubItems.Add(transaksi.BarangID);
                item.SubItems.Add(transaksi.PelangganID);
                item.SubItems.Add(transaksi.SupplierID);
                item.SubItems.Add(transaksi.JumlahBarang.ToString());
                item.SubItems.Add(transaksi.Total.ToString());
                listTransaksi.Items.Add(item);
            }
        }
        private void RefreshComboBoxData()
        {
            try
            {
                // Refresh data pelanggan
                LoadPelangganToComboBox();

                // Refresh data barang
                LoadBarangToComboBox();

                // Refresh data supplier
                LoadSupplierToComboBox();

                MessageBox.Show("Data berhasil direfresh!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshComboBoxData();
        }
    }

}
