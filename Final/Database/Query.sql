CREATE TABLE "Barang" (
	"BarangID"	INTEGER NOT NULL UNIQUE,
	"Deskripsi"	TEXT,
	"Harga DECIMAL"	TEXT,
	"Stok INT"	TEXT,
	PRIMARY KEY("BarangID")
);
CREATE TABLE "Pelanggan" (
	"PelangganID"	INTEGER NOT NULL UNIQUE,
	"Nama"	TEXT NOT NULL,
	"Alamat"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	"NomorTelepon"	TEXT NOT NULL,
	PRIMARY KEY("PelangganID")
);