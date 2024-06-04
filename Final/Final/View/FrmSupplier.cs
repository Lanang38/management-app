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
    public partial class FrmSupplier : UserControl
    {
        private List<Supplier> supplierList = new List<Supplier>();
        private SupplierController controller;
        public FrmSupplier()
        {
            InitializeComponent();
            controller = new SupplierController();
            InisialisasiListView();
            LoadDataSupplier();

            listSupplier.SelectedIndexChanged += listSupplier_SelectedIndexChanged;
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
        }
        private void LoadDataSupplier()
        {
            // kosongkan listview
            listSupplier.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            supplierList = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var supplier in supplierList)
            {
                var noUrut = listSupplier.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(supplier.SupplierID);
                item.SubItems.Add(supplier.NamaSupplier);
                item.SubItems.Add(supplier.AlamatSupplier);
                item.SubItems.Add(supplier.KontakSupplier);
                listSupplier.Items.Add(item);
            }
        }
        private bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }

        private void InisialisasiListView()
        {
            listSupplier.View = System.Windows.Forms.View.Details;
            listSupplier.FullRowSelect = true;
            listSupplier.GridLines = true;
            listSupplier.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            listSupplier.Columns.Add("ID.", 95, HorizontalAlignment.Center);
            listSupplier.Columns.Add("Nama", 175, HorizontalAlignment.Center);
            listSupplier.Columns.Add("Alamat", 200, HorizontalAlignment.Center);
            listSupplier.Columns.Add("Kontak", 175, HorizontalAlignment.Center);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text;
                string nama = txtNama.Text;
                string alamat = txtAlamat.Text;
                string kontak = txtKontak.Text;

                if (!IsNumeric(kontak))
                {
                    MessageBox.Show("Pastikan input Nomor Telepon adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Supplier supplier = new Supplier
                {
                    SupplierID = id,
                    NamaSupplier = nama,
                    AlamatSupplier = alamat,
                    KontakSupplier = kontak
                };

                int result = controller.Create(supplier);
                if (result > 0)
                {
                    MessageBox.Show("Data Supplier berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataSupplier();
                    txtId.Text = "";
                    txtNama.Text = "";
                    txtAlamat.Text = "";
                    txtKontak.Text = "";
                }
                else
                {
                    MessageBox.Show("Data Supplier gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Pastikan input No.Telepon adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listSupplier.SelectedItems.Count > 0)
            {
                try
                {
                    string id = txtId.Text;
                    string nama = txtNama.Text;
                    string alamat = txtAlamat.Text;
                    string kontak = txtKontak.Text;

                    if (!IsNumeric(kontak))
                    {
                        MessageBox.Show("Pastikan input Nomor Telepon adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Supplier supplier = new Supplier
                    {
                        SupplierID = id,
                        NamaSupplier = nama,
                        AlamatSupplier = alamat,
                        KontakSupplier = kontak
                    };

                    int result = controller.Update(supplier);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Barang berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataSupplier();
                        txtId.Text = "";
                        txtNama.Text = "";
                        txtAlamat.Text = "";
                        txtKontak.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Barang gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Pastikan input No.Telepon adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (listSupplier.SelectedItems.Count > 0)
            {
                try
                {

                    int selectedIndex = listSupplier.SelectedItems[0].Index;

                    Supplier supplierToDelete = supplierList[selectedIndex];

                    int result = controller.Delete(supplierToDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Supplier berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataSupplier();
                        txtId.Text = "";
                        txtNama.Text = "";
                        txtAlamat.Text = "";
                        txtKontak.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Supplier gagal dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void listSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSupplier.SelectedItems.Count > 0)
            {
                var selectedItem = listSupplier.SelectedItems[0];
                txtId.Text = selectedItem.SubItems[1].Text;
                txtNama.Text = selectedItem.SubItems[2].Text;
                txtAlamat.Text = selectedItem.SubItems[3].Text;
                txtKontak.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            listSupplier.Items.Clear();

            // Display all the original items in the ListView (from barangList)
            foreach (var supplier in supplierList)
            {
                var noUrut = listSupplier.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(supplier.SupplierID);
                item.SubItems.Add(supplier.NamaSupplier);
                item.SubItems.Add(supplier.AlamatSupplier);
                item.SubItems.Add(supplier.KontakSupplier);
                listSupplier.Items.Add(item);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim().ToLower(); // Get the search keyword

            // Filter the barangList based on the keyword
            var filteredSupplier = supplierList.Where(supplier =>
                supplier.NamaSupplier.ToLower().Contains(keyword)
            ).ToList();

            // Clear the ListView
            listSupplier.Items.Clear();

            // Display the filtered items in the ListView
            foreach (var supplier in filteredSupplier)
            {
                var noUrut = listSupplier.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(supplier.SupplierID);
                item.SubItems.Add(supplier.NamaSupplier);
                item.SubItems.Add(supplier.AlamatSupplier);
                item.SubItems.Add(supplier.KontakSupplier);
                listSupplier.Items.Add(item);
            }
        }
    }
}
