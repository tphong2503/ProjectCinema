# Kế hoạch: Sửa Sidebar và Tích hợp Database

## Mục tiêu
1. **Sửa lỗi hiển thị Sidebar** - text bị lặp lại nhiều lần
2. **Kết nối SQL Server** - lấy dữ liệu thực từ database

---

## Vấn đề Sidebar

Từ screenshot, sidebar hiển thị text "Xin chào, Qu" lặp lại nhiều lần. Đây có thể là do:
- Controls bị overlap/chồng lên nhau trong Designer
- Paint event không được clear đúng cách

---

## Proposed Changes

### 1. Sửa lỗi Sidebar

#### [MODIFY] [frmDashBoard.cs](file:///d:/TAILIEU/Project_cinema/ProjectCinema/ProjectCinema/frmDashBoard.cs)
- Kiểm tra và xóa các controls trùng lặp
- Thêm DoubleBuffered để tránh flicker

---

### 2. Tích hợp Database

#### Database Schema (đã có)
- **Connection**: `.\SQLEXPRESS` / `CinemaManagement`
- **DbContext**: `DashBoard` class trong `Modals/DashBoard.cs`

#### Entities chính:
| Entity | Mô tả |
|--------|-------|
| `HoaDon` | Hóa đơn (TongTien, ThanhTien, NgayLap) |
| `SuatChieu` | Suất chiếu (NgayChieu, GioChieu, GiaVe, TrangThai) |
| `Phim` | Phim (TenPhim, ThoiLuong, DanhGia) |
| `PhongChieu` | Phòng chiếu (TenPhong, SoGhe) |
| `Ve` | Vé (GiaVe, TrangThai) |

#### [MODIFY] [frmDashBoard.cs](file:///d:/TAILIEU/Project_cinema/ProjectCinema/ProjectCinema/frmDashBoard.cs)
- Thêm method `LoadDashboardData()` để lấy dữ liệu từ DB
- Cập nhật cards với dữ liệu thực:
  - **Doanh thu hôm nay**: SUM(HoaDon.ThanhTien) WHERE NgayLap = today
  - **Suất chiếu còn lại**: COUNT(SuatChieu) WHERE NgayChieu = today AND TrangThai = "Chưa chiếu"
  - **Tỷ lệ lấp đầy**: (Tổng vé đã bán / Tổng ghế) * 100
- Cập nhật DataGridView `dgvUpcomingShows` với suất chiếu sắp tới
- Cập nhật danh sách "Phim đang hot"

---

## Verification Plan

### Build Test
```bash
dotnet build
```

### Runtime Test
1. Chạy ứng dụng
2. Kiểm tra Sidebar hiển thị đúng
3. Kiểm tra các cards hiển thị dữ liệu từ database
4. Kiểm tra bảng suất chiếu sắp tới
