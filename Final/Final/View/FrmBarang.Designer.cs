namespace Final.View
{
    partial class FrmBarang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKambali = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.listBarang = new System.Windows.Forms.ListView();
            this.btnCari = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnKambali);
            this.panel2.Controls.Add(this.txtCari);
            this.panel2.Controls.Add(this.listBarang);
            this.panel2.Controls.Add(this.btnCari);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(48, 359);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 248);
            this.panel2.TabIndex = 3;
            // 
            // btnKambali
            // 
            this.btnKambali.BackColor = System.Drawing.Color.Indigo;
            this.btnKambali.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKambali.FlatAppearance.BorderSize = 0;
            this.btnKambali.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.btnKambali.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btnKambali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKambali.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnKambali.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKambali.Location = new System.Drawing.Point(550, 178);
            this.btnKambali.Margin = new System.Windows.Forms.Padding(4);
            this.btnKambali.Name = "btnKambali";
            this.btnKambali.Size = new System.Drawing.Size(127, 34);
            this.btnKambali.TabIndex = 16;
            this.btnKambali.Text = "Tampilkan";
            this.btnKambali.UseVisualStyleBackColor = false;
            this.btnKambali.Click += new System.EventHandler(this.btnKambali_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(125, 178);
            this.txtCari.Multiline = true;
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(418, 34);
            this.txtCari.TabIndex = 15;
            // 
            // listBarang
            // 
            this.listBarang.HideSelection = false;
            this.listBarang.Location = new System.Drawing.Point(28, 35);
            this.listBarang.Name = "listBarang";
            this.listBarang.Size = new System.Drawing.Size(1025, 128);
            this.listBarang.TabIndex = 4;
            this.listBarang.UseCompatibleStateImageBehavior = false;
            this.listBarang.SelectedIndexChanged += new System.EventHandler(this.listBarang_SelectedIndexChanged);
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.Indigo;
            this.btnCari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCari.FlatAppearance.BorderSize = 0;
            this.btnCari.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.btnCari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnCari.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCari.Location = new System.Drawing.Point(26, 178);
            this.btnCari.Margin = new System.Windows.Forms.Padding(4);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(83, 34);
            this.btnCari.TabIndex = 1;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(13, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Detail Barang";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.txtStok);
            this.panel1.Controls.Add(this.txtHarga);
            this.panel1.Controls.Add(this.txtDeskripsi);
            this.panel1.Controls.Add(this.txtNama);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnTambah);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnHapus);
            this.panel1.Location = new System.Drawing.Point(48, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 287);
            this.panel1.TabIndex = 2;
            // 
            // txtStok
            // 
            this.txtStok.Location = new System.Drawing.Point(163, 188);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(592, 22);
            this.txtStok.TabIndex = 14;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(163, 152);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(592, 22);
            this.txtHarga.TabIndex = 13;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Location = new System.Drawing.Point(163, 116);
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(592, 22);
            this.txtDeskripsi.TabIndex = 12;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(163, 80);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(592, 22);
            this.txtNama.TabIndex = 11;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(163, 44);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(592, 22);
            this.txtId.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(44, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Stok";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(44, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Harga";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(44, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Deskripsi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(44, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nama barang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(44, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID barang";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Indigo;
            this.btnTambah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambah.FlatAppearance.BorderSize = 0;
            this.btnTambah.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.btnTambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTambah.Location = new System.Drawing.Point(521, 239);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(4);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(143, 31);
            this.btnTambah.TabIndex = 2;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Indigo;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.Location = new System.Drawing.Point(340, 239);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(143, 31);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Indigo;
            this.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapus.FlatAppearance.BorderSize = 0;
            this.btnHapus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.btnHapus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnHapus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHapus.Location = new System.Drawing.Point(161, 239);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(143, 31);
            this.btnHapus.TabIndex = 0;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // FrmBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBarang";
            this.Size = new System.Drawing.Size(1167, 695);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listBarang;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnKambali;
    }
}
