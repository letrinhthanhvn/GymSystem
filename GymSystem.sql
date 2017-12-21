USE GymSystem
GO

CREATE TABLE NguoiTap
(
	MaNT varchar(10) PRIMARY KEY,
	HoTen nvarchar(100),
	SDT varchar(15),
	NgaySinh date,
	GioiTinh nvarchar(3)
)


CREATE TABLE GoiTap
(
	MaGT nvarchar(100) PRIMARY KEY,
	Gia Int,
	ChuThich nvarchar(1000)
)

CREATE TABLE NvQLHlv
(
	MaNVQL varchar(10) PRIMARY KEY,
	HoTen nvarchar(100),
	SDT varchar(15),
	NgaySinh date, 
	GioiTinh nvarchar(3)
)


CREATE TABLE HLV
(
	MaHLV varchar(10) PRIMARY KEY,
	HoTen nvarchar(100),
	SDT varchar(15),
	NgaySinh date, 
	GioiTinh nvarchar(3),
	MaNVQL varchar(10),
	FOREIGN KEY(MaNVQL) REFERENCES dbo.NvQLHlv(MaNVQL)
)

CREATE TABLE DangKi
(
	MaNT varchar(10),
	MaGT nvarchar(100),
	MaHLV varchar(10) DEFAULT NULL,
	NgayBD date,
	NgayKT date,
	PRIMARY KEY(MaNT,NgayBD),
	FOREIGN KEY(MaNT) REFERENCES dbo.NguoiTap(MaNT),
	FOREIGN KEY(MaGT) REFERENCES dbo.GoiTap(MaGT),
	FOREIGN KEY(MaHLV) REFERENCES dbo.HLV(MaHLV)
)

ALTER TABLE NguoiTap 
ADD CONSTRAINT GioiTinh CHECK(GioiTinh = N'Nam' OR GioiTinh = N'Nữ')

ALTER TABLE HLV 
ADD CONSTRAINT GioiTinh CHECK(HLV.GioiTinh = N'Nam' OR HLV.GioiTinh = N'Nữ')



SELECT * FROM DangKi

SELECT * FROM GoiTap

SELECT * FROM NvQLHlv

CREATE TABLE TaiKhoan
(
	UserName varchar(100) primary key,
	PassWord varchar(100),
	Type varchar(1) DEFAULT 0
)



SELECT GioiTinh,count(GioiTinh) SoLuong FROM NguoiTap
GROUP BY GioiTinh

SELECT DangKi.MaHLV ,HLV.HoTen,count(DangKi.MaHLV) SoLuong FROM DangKi,HLV
WHERE DangKi.MaHLV = HLV.MaHLV
GROUP BY DangKi.MaHLV, HLV.HoTen

SELECT MONTH(NgayBD) AS THÁNG,SUM(GoiTap.Gia) DOANH_THU FROM dbo.DangKi,dbo.GoiTap
WHERE DangKi.MaGT = GoiTap.MaGT
GROUP BY MONTH(DangKi.NgayBD)

SELECT MaGT,count(*) SoNguoiTap FROM dbo.DangKi
GROUP BY MaGT
 

ALTER TABLE NguoiTap
   DROP CONSTRAINT GioiTinh

ALTER TABLE NguoiTap
   ADD CONSTRAINT GioiTinh CHECK(NguoiTap.GioiTinh = N'Nam' OR NguoiTap.GioiTinh = N'Nữ');

SELECT * FROM NguoiTap

ALTER TABLE HLV
   ADD CONSTRAINT GioiTinh CHECK(GioiTinh = N'Nam' OR GioiTinh = N'Nữ');

INSERT INTO NguoiTap
VALUES ('NT43',N'Lê Nam Cường','091230012','1997-11-3',N'BOY')


ALTER TABLE DangKi
   ADD CONSTRAINT DATENgayBD,NgayKT CHECK( = N'Nam' OR GioiTinh = N'Nữ');

SELECT * FROM DangKi

DELETE dbo.DangKi WHERE MaNT = 'NT53' AND NgayBD = '2017-11-11'

ALTER TABLE NguoiTap
   ADD CONSTRAINT NgaySinh CHECK(YEAR(GETDATE()) - YEAR(NgaySinh) >14 );

/* CREATE TRIGGER tg_them_DangKi ON dbo.DangKi 
FOR INSERT
AS 
BEGIN     
    
    DECLARE @MaNT varchar(3) = 'NT1'
	DECLARE @NgayBD1 date = (SELECT NgayBD FROM inserted WHERE MaNT = @MaNT)
	DECLARE @NgayKT1 date = (SELECT NgayKT FROM inserted WHERE MaNT = @MaNT)
    -- inserted là bảng table khi insert vào tbl_monhoc, nói cách khác inserted chính là tbl_monhoc
    -- Tính điểm trung bình cộng các môn học cho từng sinh viên
    DECLARE @ngayBD date = (SELECT NgayBD FROM dbo.DangKi WHERE MaNT=@MaNT)
	DECLARE @ngayKT date = (SELECT NgayKT FROM dbo.DangKi WHERE MaNT=@MaNT)
    -- Tính kết quả nếu điểm trung bình >=5 Đậu ngược lại thì Rớt
    IF ((@NgayBD1 < @NgayBD OR @NgayBD1 > @NgayKT) AND (@NgayKT1 > @NgayKT OR @NgayKT1 < @NgayBD) )
        INSERT INTO dbo.DangKi VALUES(MaNT,MaGT,NgayBD,NgayKT) ('NT1','1 tháng','2017-3-15','2017-4-15')
    ELSE
        print 'Khong them duoc'
END */

CREATE TABLE DangKi_add (
    MaNT varchar(10),
	MaGT nvarchar(100),
	MaHLV varchar(10) DEFAULT NULL,
	NgayBD date,
	NgayKT date,
	PRIMARY KEY(MaNT,NgayBD),	
)

CREATE TRIGGER TG_TestNgayBD_NgayKT ON dbo.DangKi 
FOR INSERT
AS 
If (INSERTED.NgayBD > INSERTED.NgayKT)
 Begin
   Print 'NgayBD ko dc > NgayKT'
   RollBack Tran
 End

 DECLARE @MaNT varchar(10) = 'NT1'

 SELECT * FROM inserted

 if exists (select name from sysobjects where name = 'before_DangKi_add1' and type = 'TR') drop trigger before_DangKi_add1 go

 CREATE TRIGGER before_DangKi_add1 ON DangKi
    FOR insert, update
	AS
BEGIN
/*    declare @ngaybd date
	set @ngaybd =( SELECT NgayBD FROM inserted)
	declare @ngaykt date
	set @ngaykt = (select NgayKT FROM inserted)
*/
DECLARE @Count INT = 0
SELECT @Count = COUNT(*) FROM inserted WHERE (inserted.NgayBD > inserted.NgayKT)	
	if(@Count > 0)
		begin
		print 'ko them dc' 
		rollback TRAN
		end
    
END




CREATE TRIGGER before_DangKi_add2 ON DangKi
    FOR insert, update
	AS
BEGIN

DECLARE @Count INT = 0
SELECT @Count = COUNT(*) FROM DangKi,inserted 
WHERE DangKi.MaNT = inserted.MaNT AND inserted.NgayBD > DangKi.NgayBD AND inserted.NgayBD < DangKi.NgayKT	
	if(@Count > 0)
		begin
		print 'ko them dc' 
		rollback TRAN
		end
    
END


-- Huấn luyện viên đang huấn luyện những người nào
SELECT HLV.HoTen, NT.HoTen, DK.MaGT FROM dbo.NguoiTap AS NT, dbo.DangKi AS DK, dbo.HLV
WHERE NT.MaNT = DK.MaNT
AND HLV.MaHLV = DK.MaHLV
AND HLV.HoTen = N'Lê Anh Tuấn'

SELECT * FROM HLV

-- Người tập đã đăng kí những gói tập nào
SELECT NT.HoTen, DK.MaGT FROM dbo.NguoiTap NT, dbo.DangKi DK
WHERE NT.MaNT = DK.MaNT

AND NT.HoTen = N'Lê Trịnh Thành'

-- ngày hôm đó có những người nào đăng kí tập va so luong
SELECT * FROM dbo.DangKi

SELECT NT.MaNT, NT.HoTen, DK.MaGT FROM dbo.NguoiTap NT, dbo.DangKi DK
WHERE NT.MaNT = DK.MaNT
AND DK.NgayBD = '2017-3-15'

-- các khách  hàng đăng kí các gói tập nào trong tháng
SELECT NT.MaNT, NT.HoTen, DK.MaGT FROM dbo.NguoiTap NT,  dbo.DangKi DK
WHERE NT.MaNT = DK.MaNT
AND MONTH(DK.NgayBD) = 11
AND DK.MaGT = '1 tháng'


