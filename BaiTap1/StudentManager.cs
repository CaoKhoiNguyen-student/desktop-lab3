using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    public class StudentManager
    {
        private List<Student> listStudents;
        private readonly string filePath;

        public List<Student> ListStudents => listStudents;

        public StudentManager(string path = "students.txt")
        {
            filePath = path;
            listStudents = StudentService.DocFile(filePath);
        }

        // Tự động sao lưu lại tập tin khi có thay đổi
        private void SaveChanges()
        {
            StudentService.LuuFile(filePath, listStudents);
        }

        // a. Thêm hoặc Cập nhật thông tin sinh viên (nếu trùng MSSV thì Cập nhật, chưa có thì Thêm mới)
        public bool AddOrUpdate(Student student, out string message)
        {
            if (!student.IsValid(out message))
            {
                return false;
            }

            var existingStudent = listStudents.FirstOrDefault(s => s.MSSV.Equals(student.MSSV, StringComparison.OrdinalIgnoreCase));

            if (existingStudent != null)
            {
                // Cập nhật thông tin
                existingStudent.HoTenLot = student.HoTenLot;
                existingStudent.Ten = student.Ten;
                existingStudent.NgaySinh = student.NgaySinh;
                existingStudent.GioiTinh = student.GioiTinh;
                existingStudent.Lop = student.Lop;
                existingStudent.CMND = student.CMND;
                existingStudent.SoDienThoai = student.SoDienThoai;
                existingStudent.DiaChi = student.DiaChi;
                existingStudent.DanhSachMonHoc = student.DanhSachMonHoc;
                message = "Cập nhật thông tin sinh viên thành công!";
            }
            else
            {
                // Thêm mới
                listStudents.Add(student);
                message = "Thêm sinh viên mới thành công!";
            }

            SaveChanges();
            return true;
        }

        // b. Tìm kiếm sinh viên theo Tên, Lớp, MSSV
        public List<Student> Search(string mssv = null, string ten = null, string lop = null)
        {
            var query = listStudents.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(mssv))
            {
                query = query.Where(s => s.MSSV.Contains(mssv.Trim()));
            }

            if (!string.IsNullOrWhiteSpace(ten))
            {
                query = query.Where(s => s.Ten.IndexOf(ten.Trim(), StringComparison.OrdinalIgnoreCase) >= 0 ||
                                         s.HoVaTen().IndexOf(ten.Trim(), StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrWhiteSpace(lop))
            {
                query = query.Where(s => s.Lop.Equals(lop.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();
        }

        // c. Xóa 1 sinh viên theo MSSV
        public bool Delete(string mssv)
        {
            var student = listStudents.FirstOrDefault(s => s.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                listStudents.Remove(student);
                SaveChanges();
                return true;
            }
            return false;
        }

        // c. Xóa nhiều sinh viên theo danh sách MSSV
        public int DeleteMultiple(List<string> listMSSV)
        {
            if (listMSSV == null || listMSSV.Count == 0) return 0;

            int count = listStudents.RemoveAll(s => listMSSV.Contains(s.MSSV));
            if (count > 0)
            {
                SaveChanges();
            }
            return count;
        }
    }
}

