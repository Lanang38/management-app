namespace Final.View
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.SignOUT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Nama = new System.Windows.Forms.Label();
            this.Transaksi_btn = new System.Windows.Forms.Button();
            this.Supplier_btn = new System.Windows.Forms.Button();
            this.Barang_btn = new System.Windows.Forms.Button();
            this.Pelanggan_btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dashboard1 = new Final.View.FrmDashboard();
            this.barang1 = new Final.View.FrmBarang();
            this.pelanggan1 = new Final.View.FrmPelanggan();
            this.supplier1 = new Final.View.FrmSupplier();
            this.transaksi1 = new Final.View.FrmTransaksi();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 43);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(429, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Sistem Manajemen Penyimpanan dan Pengelolaan Barang";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(1420, 8);
            this.exit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(20, 21);
            this.exit.TabIndex = 1;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Indigo;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Controls.Add(this.SignOUT);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Nama);
            this.panel2.Controls.Add(this.Transaksi_btn);
            this.panel2.Controls.Add(this.Supplier_btn);
            this.panel2.Controls.Add(this.Barang_btn);
            this.panel2.Controls.Add(this.Pelanggan_btn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 695);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(64, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 140);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.Image = ((System.Drawing.Image)(resources.GetObject("dashboard_btn.Image")));
            this.dashboard_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard_btn.Location = new System.Drawing.Point(15, 225);
            this.dashboard_btn.Margin = new System.Windows.Forms.Padding(4);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(267, 49);
            this.dashboard_btn.TabIndex = 14;
            this.dashboard_btn.Text = "Dashboard";
            this.dashboard_btn.UseVisualStyleBackColor = true;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // SignOUT
            // 
            this.SignOUT.BackColor = System.Drawing.Color.Indigo;
            this.SignOUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignOUT.FlatAppearance.BorderSize = 0;
            this.SignOUT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.SignOUT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.SignOUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignOUT.Image = ((System.Drawing.Image)(resources.GetObject("SignOUT.Image")));
            this.SignOUT.Location = new System.Drawing.Point(15, 636);
            this.SignOUT.Margin = new System.Windows.Forms.Padding(4);
            this.SignOUT.Name = "SignOUT";
            this.SignOUT.Size = new System.Drawing.Size(47, 43);
            this.SignOUT.TabIndex = 8;
            this.SignOUT.UseVisualStyleBackColor = false;
            this.SignOUT.Click += new System.EventHandler(this.SignOUT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(71, 649);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "LOG OUT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Nama
            // 
            this.Nama.Location = new System.Drawing.Point(0, 0);
            this.Nama.Name = "Nama";
            this.Nama.Size = new System.Drawing.Size(100, 23);
            this.Nama.TabIndex = 15;
            // 
            // Transaksi_btn
            // 
            this.Transaksi_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transaksi_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.Transaksi_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.Transaksi_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Transaksi_btn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transaksi_btn.ForeColor = System.Drawing.Color.White;
            this.Transaksi_btn.Image = ((System.Drawing.Image)(resources.GetObject("Transaksi_btn.Image")));
            this.Transaksi_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Transaksi_btn.Location = new System.Drawing.Point(15, 536);
            this.Transaksi_btn.Name = "Transaksi_btn";
            this.Transaksi_btn.Size = new System.Drawing.Size(267, 49);
            this.Transaksi_btn.TabIndex = 12;
            this.Transaksi_btn.Text = "Transaksi";
            this.Transaksi_btn.UseVisualStyleBackColor = true;
            this.Transaksi_btn.Click += new System.EventHandler(this.Transaksi_btn_Click);
            // 
            // Supplier_btn
            // 
            this.Supplier_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Supplier_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.Supplier_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.Supplier_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Supplier_btn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supplier_btn.ForeColor = System.Drawing.Color.White;
            this.Supplier_btn.Image = ((System.Drawing.Image)(resources.GetObject("Supplier_btn.Image")));
            this.Supplier_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Supplier_btn.Location = new System.Drawing.Point(15, 458);
            this.Supplier_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Supplier_btn.Name = "Supplier_btn";
            this.Supplier_btn.Size = new System.Drawing.Size(267, 49);
            this.Supplier_btn.TabIndex = 11;
            this.Supplier_btn.Text = "Supplier";
            this.Supplier_btn.UseVisualStyleBackColor = true;
            this.Supplier_btn.Click += new System.EventHandler(this.Supplier_btn_Click);
            // 
            // Barang_btn
            // 
            this.Barang_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Barang_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.Barang_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.Barang_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Barang_btn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Barang_btn.ForeColor = System.Drawing.Color.White;
            this.Barang_btn.Image = ((System.Drawing.Image)(resources.GetObject("Barang_btn.Image")));
            this.Barang_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Barang_btn.Location = new System.Drawing.Point(15, 379);
            this.Barang_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Barang_btn.Name = "Barang_btn";
            this.Barang_btn.Size = new System.Drawing.Size(267, 49);
            this.Barang_btn.TabIndex = 10;
            this.Barang_btn.Text = "Barang";
            this.Barang_btn.UseVisualStyleBackColor = true;
            this.Barang_btn.Click += new System.EventHandler(this.Barang_btn_Click);
            // 
            // Pelanggan_btn
            // 
            this.Pelanggan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pelanggan_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.Pelanggan_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.Pelanggan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pelanggan_btn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pelanggan_btn.ForeColor = System.Drawing.Color.White;
            this.Pelanggan_btn.Image = ((System.Drawing.Image)(resources.GetObject("Pelanggan_btn.Image")));
            this.Pelanggan_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pelanggan_btn.Location = new System.Drawing.Point(15, 300);
            this.Pelanggan_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Pelanggan_btn.Name = "Pelanggan_btn";
            this.Pelanggan_btn.Size = new System.Drawing.Size(267, 49);
            this.Pelanggan_btn.TabIndex = 9;
            this.Pelanggan_btn.Text = "Pelanggan";
            this.Pelanggan_btn.UseVisualStyleBackColor = true;
            this.Pelanggan_btn.Click += new System.EventHandler(this.Pelanggan_btn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dashboard1);
            this.panel3.Controls.Add(this.barang1);
            this.panel3.Controls.Add(this.pelanggan1);
            this.panel3.Controls.Add(this.supplier1);
            this.panel3.Controls.Add(this.transaksi1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(300, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1167, 695);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(89, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "Welcome";
            // 
            // dashboard1
            // 
            this.dashboard1.BackColor = System.Drawing.Color.Gray;
            this.dashboard1.Location = new System.Drawing.Point(0, 0);
            this.dashboard1.Margin = new System.Windows.Forms.Padding(4);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(1167, 695);
            this.dashboard1.TabIndex = 4;
            // 
            // barang1
            // 
            this.barang1.Location = new System.Drawing.Point(0, 0);
            this.barang1.Margin = new System.Windows.Forms.Padding(4);
            this.barang1.Name = "barang1";
            this.barang1.Size = new System.Drawing.Size(1167, 695);
            this.barang1.TabIndex = 3;
            // 
            // pelanggan1
            // 
            this.pelanggan1.Location = new System.Drawing.Point(0, 0);
            this.pelanggan1.Margin = new System.Windows.Forms.Padding(4);
            this.pelanggan1.Name = "pelanggan1";
            this.pelanggan1.Size = new System.Drawing.Size(1167, 695);
            this.pelanggan1.TabIndex = 2;
            // 
            // supplier1
            // 
            this.supplier1.Location = new System.Drawing.Point(0, 0);
            this.supplier1.Margin = new System.Windows.Forms.Padding(4);
            this.supplier1.Name = "supplier1";
            this.supplier1.Size = new System.Drawing.Size(1167, 695);
            this.supplier1.TabIndex = 1;
            // 
            // transaksi1
            // 
            this.transaksi1.Location = new System.Drawing.Point(0, 0);
            this.transaksi1.Margin = new System.Windows.Forms.Padding(4);
            this.transaksi1.Name = "transaksi1";
            this.transaksi1.Size = new System.Drawing.Size(1167, 695);
            this.transaksi1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1467, 738);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Nama;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Button SignOUT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Transaksi_btn;
        private System.Windows.Forms.Button Supplier_btn;
        private System.Windows.Forms.Button Barang_btn;
        private System.Windows.Forms.Button Pelanggan_btn;
        private System.Windows.Forms.Panel panel3;
        private FrmDashboard dashboard1;
        private FrmBarang barang1;
        private FrmPelanggan pelanggan1;
        private FrmSupplier supplier1;
        private FrmTransaksi transaksi1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}