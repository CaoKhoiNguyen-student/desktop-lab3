using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    public class StudentService
    {
        public static void LuuFile(string filepath, List<Student> students)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(filepath))
                {
                    foreach(Student s in students)
                    {
                        string dsMonHoc = string.Join(','.ToString(), s.DanhSachMonHoc);
                        string line = string.Join('|'.ToString(), s.MSSV, s.HoTenLot, s.Ten, s.NgaySinh.ToString(), s.GioiTinh, s.Lop, s.CMND, s.SoDienThoai, s.DiaChi, dsMonHoc);
                        sw.WriteLine(line);

                    }
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static List<Student> DocFile(string path)
        {
            List<Student> list = new List<Student>();
            if (!File.Exists(path)) return list;
            try
            {
                using(StreamReader sd = new StreamReader(path))
                {
                    string line;
                    while ((line = sd.ReadLine()) != null)
                    {
                        if(string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split('|');
                        if(parts.Length > 9)
                        {
                            Student s = new Student
                            {
                                MSSV = parts[0],
                                HoTenLot = parts[1],
                                Ten = parts[2],
                                NgaySinh = DateTime.TryParse(parts[3], out DateTime ns) ? ns : DateTime.Now,
                                GioiTinh = parts[4],
                                Lop = parts[5],
                                CMND = parts[6],
                                SoDienThoai = parts[7],
                                DiaChi = parts[8]
                            };
                            //neu co danh sach mon hoc
                            if (parts.Length > 9 && !string.IsNullOrWhiteSpace(parts[9]))
                            {
                                s.DanhSachMonHoc = parts[9]
                                    .Split(',').ToList();
                            }
                            list.Add(s);
                        }
                    }
                }
            }catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}
