CREATE TABLE DOCGIA
	(
		MaDocGia INT IDENTITY (1,1) PRIMARY KEY,
		TenDocGia NVARCHAR(MAX) NOT NULL,
		MaLoaiDocGia INT NOT NULL,
		NgaySinh SMALLDATETIME NOT NULL,
		DiaChi NVARCHAR(MAX) NOT NULL,
		Email NVARCHAR(MAX) NOT NULL,
		NgayLapThe SMALLDATETIME NOT NULL,
		NgayHetHan SMALLDATETIME NOT NULL,
		TongNo INT NOT NULL
	)
GO

CREATE TABLE LOAIDOCGIA
	(
		MaLoaiDocGia INT IDENTITY (1,1) PRIMARY KEY,
		TenLoaiDocGia NVARCHAR(MAX) NOT NULL,
	)
GO

CREATE TABLE SACH
	(
		MaSach INT IDENTITY (1,1) PRIMARY KEY,
		TenSach NVARCHAR(MAX) NOT NULL,
		MaTheLoai INT NOT NULL,
		NamXuatBan SMALLDATETIME NOT NULL,
		NhaXuatBan NVARCHAR(MAX) NOT NULL,
		NgayNhap SMALLDATETIME NOT NULL,
		TriGia INT NOT NULL,
		SoLuong INT NOT NULL
	)
GO

CREATE TABLE CUONSACH
	(
		MaCuonSach INT IDENTITY (1,1) PRIMARY KEY,
		MaSach INT NOT NULL,
		TinhTrang NVARCHAR(MAX) NOT NULL
	)
GO

CREATE TABLE TACGIA
	(
		MaTacGia INT IDENTITY (1,1) PRIMARY KEY,
		TenTacGia NVARCHAR(MAX) NOT NULL,
	)
GO

CREATE TABLE CTTACGIA
	(
		MaTacGia INT,
		MaSach INT,
		primary key(MaTacGia, MaSach)
	)
GO

CREATE TABLE THELOAI
	(
		MaTheLoai INT IDENTITY (1,1) PRIMARY KEY,
		TenTheLoai NVARCHAR(MAX) NOT NULL,
	)
GO

CREATE TABLE PHIEUMUONTRA
	(
		MaMuonTra INT IDENTITY (1,1) PRIMARY KEY,
		MaCuonSach INT NOT NULL,
		MaDocGia INT NOT NULL,
		NgayMuon SMALLDATETIME NOT NULL,
		NgayTra SMALLDATETIME,
		TienPhat INT NOT NULL,
		SoTienTra INT NOT NULL
	)
GO

CREATE TABLE PHIEUTHU
	(
		MaPhieuThu INT IDENTITY (1,1) PRIMARY KEY,
		MaDocGia INT NOT NULL,
		SoTienThu INT NOT NULL,
		ConLai INT NOT NULL
	)
GO

CREATE TABLE BCMSTTL
	(
		MaBC INT IDENTITY (1,1) PRIMARY KEY,
		Thang INT NOT NULL,
		Nam INT NOT NULL,
		TongSoLuotMuon INT NOT NULL
	)
GO

CREATE TABLE CTBCMSTTL
	(
		MaCTBC INT IDENTITY (1,1) PRIMARY KEY,
		MaBC INT NOT NULL,
		MaTheLoai INT NOT NULL,
		SoLuotMuon INT NOT NULL,
		TyLe FLOAT NOT NULL,
	)
GO

CREATE TABLE BCTKSTT
	(
		MaCuonSach INT NOT NULL,
		Ngay INT NOT NULL,
		Thang INT NOT NULL,
		Nam INT NOT NULL,
		NgayMuon SMALLDATETIME NOT NULL,
		SoNgayTraTre INT NOT NULL,
		primary key(MaCuonSach, Ngay)
	)
GO

CREATE TABLE THAMSO
	(
		MaThamSo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
		TenThamSo NVARCHAR(MAX) NOT NULL,
		GiaTriThamSo INT NOT NULL
	)
GO

ALTER TABLE DOCGIA ADD FOREIGN KEY(MaLoaiDocGia) REFERENCES LOAIDOCGIA(MaLoaiDocGia)

ALTER TABLE SACH ADD FOREIGN KEY(MaTheLoai) REFERENCES THELOAI(MaTheLoai)

ALTER TABLE CTBCMSTTL ADD FOREIGN KEY(MaBC) REFERENCES BCMSTTL(MaBC)

ALTER TABLE CTBCMSTTL ADD FOREIGN KEY(MaTheLoai) REFERENCES THELOAI(MaTheLoai)

ALTER TABLE CTTACGIA ADD FOREIGN KEY(MaSach) REFERENCES SACH(MaSach)

ALTER TABLE CTTACGIA ADD FOREIGN KEY(MaTacGia) REFERENCES TACGIA(MaTacGia)

ALTER TABLE PHIEUTHU ADD FOREIGN KEY(MaDocGia) REFERENCES DOCGIA(MaDocGia)

ALTER TABLE PHIEUMUONTRA ADD FOREIGN KEY(MaDocGia) REFERENCES DOCGIA(MaDocGia)

ALTER TABLE PHIEUMUONTRA ADD FOREIGN KEY(MaCuonSach) REFERENCES CUONSACH(MaCuonSach)

ALTER TABLE CUONSACH ADD FOREIGN KEY(MaSach) REFERENCES Sach(MaSach)

ALTER TABLE CUONSACH ADD CHECK (TinhTrang = N'được mượn' OR TinhTrang = N'có sẵn')



/* insert data */


insert into LOAIDOCGIA values(N'Học sinh')
insert into LOAIDOCGIA values(N'Sinh viên')
insert into LOAIDOCGIA values(N'Tự do')

insert into DOCGIA values(N'Phạm Huỳnh Phúc', 2, '01/01/2000',N'Nam Định', 'email1@gmail.com', '01/01/2021', '01/07/2021', 0)
insert into DOCGIA values(N'Lê Tài', 1, '01/02/2000', N'Quảng Bình', 'email2@gmail.com', '01/02/2021', '01/08/2021', 0)
insert into DOCGIA values(N'Đỗ Thị Thanh Nhã', 2, '01/03/2000', N'Quảng Nam', 'email3@gmail.com', '01/03/2021','01/09/2021', 0)
insert into DOCGIA values(N'Nguyễn Thị Thanh Tuyền', 3, '01/04/1989', N'Bình Dương', 'email14@gmail.com', '01/04/2021', '01/10/2021', 0)


insert into TACGIA values(N'Tác giả 1')
insert into TACGIA values(N'Tác giả 2')
insert into TACGIA values(N'Tác giả 3')
insert into TACGIA values(N'Tác giả 4')
insert into TACGIA values(N'Tác giả 5')
 
insert into THELOAI values(N'Thể loại 1')
insert into THELOAI values(N'Thể loại 2')
insert into THELOAI values(N'Thể loại 3')
insert into THELOAI values(N'Thể loại 4')
insert into THELOAI values(N'Thể loại 5')

insert into SACH values(N'Cấu trúc dữ liệu và giải thuật', 1, '01/01/2000', N'Nhà XB 1', '02/03/2001', 30000, 2)
insert into SACH values(N'Lập trình hướng đối tượng', 2, '01/01/2000', N'Nhà XB 2', '02/03/2001', 25000, 1)
insert into SACH values(N'Xử lý dữ liệu lớn', 3, '01/03/2000', N'Nhà XB 3', '02/01/2002', 35000, 1)
insert into SACH values(N'Học máy thống kê', 4, '01/02/2000', N'Nhà XB 4', '02/01/2002', 30000, 2)
insert into SACH values(N'Nhập môn lập trình', 5, '01/02/2000', N'Nhà XB 5', '02/03/2001', 20000, 1)

insert into CUONSACH values(1, N'có sẵn')
insert into CUONSACH values(1, N'được mượn')
insert into CUONSACH values(2, N'có sẵn')
insert into CUONSACH values(3, N'có sẵn')
insert into CUONSACH values(4, N'có sẵn')
insert into CUONSACH values(4, N'có sẵn')
insert into CUONSACH values(5, N'có sẵn')


insert into CTTACGIA values(1, 1);
insert into CTTACGIA values(2, 2);
insert into CTTACGIA values(3, 3);
insert into CTTACGIA values(4, 3);
insert into CTTACGIA values(5, 3);
insert into CTTACGIA values(4, 4);
insert into CTTACGIA values(5, 4);
insert into CTTACGIA values(5, 5);

insert into PHIEUMUONTRA values(2, 2, '04/03/2021', NULL, 0, 0)
insert into PHIEUMUONTRA values(5, 1, '03/03/2021', '09/03/2021', 2000, 0)


insert into THAMSO values(N'Tuoitoithieu', 18);
insert into THAMSO values(N'Tuoitoida', 55);
insert into THAMSO values(N'Thoihansudung', 6);
insert into THAMSO values(N'KhoangcachXB', 8);
insert into THAMSO values(N'Sosachmuonmax', 5);
insert into THAMSO values(N'Songaymuonmax', 4);
insert into THAMSO values(N'Tienphat1ngay', 1000);

insert into PHIEUTHU values(1, 2000, 0);

