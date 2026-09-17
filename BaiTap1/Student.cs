using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaiTap1
{
    public class Student
    {
        public string MSSV { get; set; }
        public string HoTenLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } 
        public string Lop { get; set; }
        public string CMND { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public List<string> DanhSachMonHoc { get; set; }

        public string HoVaTen() {  return this.HoTenLot + this.Ten; }

        public Student() { DanhSachMonHoc = new List<string>(); }

        public Student(string mssv, string hoTenLot, string ten, DateTime ngaySinh,
                       string gioiTinh, string lop, string cmnd, string sdt,
                       string diaChi, List<string> dsMonHoc)
        {
            MSSV = mssv;
            HoTenLot = hoTenLot;
            Ten = ten;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Lop = lop;
            CMND = cmnd;
            SoDienThoai = sdt;
            DiaChi = diaChi;
            DanhSachMonHoc = dsMonHoc ?? new List<string>();
        }

        
        //private string GetEnrollmentYe(string className)
        //{
        //    if (string.IsNullOrWhiteSpace(className)) { return null; }
        //    string res = "";
        //    foreach(var c in className)
        //    {
        //        if (c >= '0' && c <= '9') res += c;
        //        //vì dữ liệu mẫu có dạng CTK44 -> khoá 44 nên chỉ lấy cặp số gần nhau nên break luôn
        //        else if (res.Length > 0) break;
        //    }
        //    return res;
            
        //}


        private string ExtractYearFromClass(string className)
        {
            if (string.IsNullOrWhiteSpace(className)) return "";
            //var match = GetEnrollmentYe(className);
            var match = Regex.Match(className, @"\d+");
            if (match.Success && int.TryParse(match.Value, out int khoasaudi))
            {
                // Quy ước: Khóa 1 bắt đầu từ năm 1977 (Đại học Đà Lạt) hoặc tùy biến công thức khóa học của trường
                int baseYear = 1976 + khoasaudi;
                return (baseYear % 100).ToString("D2");
            }
            return "";
        }

        public bool IsValid(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(MSSV) || MSSV.Length != 7 || !MSSV.All(char.IsDigit))
            {
                errorMessage = "MSSV phải bao gồm đúng 7 chữ số!";
                return false;
            }

            if (!MSSV.Substring(2, 2).Equals("10"))
            {
                errorMessage = "đề bài yêu cầu MSSV có dạng AABBCCC trong đó BB = 10";
            }

            string namLop = ExtractYearFromClass(Lop);
            if (!string.IsNullOrEmpty(namLop) && !MSSV.StartsWith(namLop))
            {
                errorMessage = $"MSSV phải bắt đầu bằng '{namLop}' tương ứng với năm nhập học của lớp {Lop}!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Ten))
            {
                errorMessage = "Tên sinh viên không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(CMND) || CMND.Length != 9 || !CMND.All(char.IsDigit))
            {
                errorMessage = "Số CMND phải bao gồm đúng 9 chữ số!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(SoDienThoai) || SoDienThoai.Length != 10 || !SoDienThoai.All(char.IsDigit))
            {
                errorMessage = "Số điện thoại phải bao gồm đúng 10 chữ số!";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public override string ToString()
        {
            return $"{MSSV} - {HoVaTen()} - Lớp: {Lop}";
        }
    }
}
