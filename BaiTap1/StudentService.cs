using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BaiTap1
{
    public class StudentService
    {
        

        public static void LuuFile(string filepath, List<Student> students)
        {
            try
            {
                string ext = GetExtensionFile(filepath).ToLower();

                switch (ext)
                {
                    case ".xml":
                        LuuXml(filepath, students);
                        break;
                    case ".json":
                        LuuJson(filepath, students);
                        break;
                    case ".txt":
                    default:
                        LuuTxt(filepath, students);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi ghi file: " + ex.Message);
            }
        }

        public static List<Student> DocFile(string path)
        {
            List<Student> list = new List<Student>();
            if (!File.Exists(path)) return list;

            try
            {
                string ext = GetExtensionFile(path).ToLower();

                switch (ext)
                {
                    case ".xml":
                        list = DocXml(path);
                        break;
                    case ".json":
                        list = DocJson(path);
                        break;
                    case ".txt":
                    default:
                        list = DocTxt(path);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đọc file: " + ex.Message);
            }

            return list;
        }

        public static string GetExtensionFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;

            for (int i = fileName.Length - 1; i >= 0; i--)
            {
                if (fileName[i] == '.')
                {
                    return fileName.Substring(i);
                }
            }
            return string.Empty;
        }

        

        private static void LuuTxt(string filepath, List<Student> students)
        {
            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
            {
                foreach (Student s in students)
                {
                    string dsMonHoc = s.DanhSachMonHoc != null ? string.Join(",", s.DanhSachMonHoc) : "";
                    string line = string.Join("|",
                        s.MSSV,
                        s.HoTenLot,
                        s.Ten,
                        s.NgaySinh.ToString("yyyy-MM-dd"),
                        s.GioiTinh,
                        s.Lop,
                        s.CMND,
                        s.SoDienThoai,
                        s.DiaChi,
                        dsMonHoc
                    );
                    sw.WriteLine(line);
                }
            }
        }

        private static List<Student> DocTxt(string path)
        {
            List<Student> list = new List<Student>();
            using (StreamReader sd = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = sd.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');
                    if (parts.Length >= 9)
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

                        if (parts.Length > 9 && !string.IsNullOrWhiteSpace(parts[9]))
                        {
                            s.DanhSachMonHoc = parts[9].Split(',').ToList();
                        }

                        list.Add(s);
                    }
                }
            }
            return list;
        }

    

 

        private static void LuuXml(string filepath, List<Student> students)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
            {
                serializer.Serialize(sw, students);
            }
        }

        private static List<Student> DocXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                return (List<Student>)serializer.Deserialize(sr);
            }
        }

 

 

        private static void LuuJson(string filepath, List<Student> students)
        {
            var rootObject = new { sinhvien = students };
            string jsonText = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(filepath, jsonText, Encoding.UTF8);
        }

        private static List<Student> DocJson(string path)
        {
            List<Student> list = new List<Student>();

            using (StreamReader r = new StreamReader(path, Encoding.UTF8))
            {
                string json = r.ReadToEnd();
                var array = (JObject)JsonConvert.DeserializeObject(json);

                if (array != null && array["sinhvien"] != null)
                {
                    var students = array["sinhvien"].Children();

                    foreach (var item in students)
                    {
                        string mssv = item["MSSV"]?.Value<string>();
                        string hoTenLot = item["HoTenLot"]?.Value<string>();
                        string ten = item["Ten"]?.Value<string>();
                        DateTime ngaySinh = item["NgaySinh"] != null ? item["NgaySinh"].Value<DateTime>() : DateTime.Now;
                        string gioiTinh = item["GioiTinh"]?.Value<string>();
                        string lop = item["Lop"]?.Value<string>();
                        string cmnd = item["CMND"]?.Value<string>();
                        string sdt = item["SoDienThoai"]?.Value<string>();
                        string diaChi = item["DiaChi"]?.Value<string>();

                        List<string> dsMonHoc = new List<string>();
                        if (item["DanhSachMonHoc"] != null)
                        {
                            foreach (var mon in item["DanhSachMonHoc"].Children())
                            {
                                dsMonHoc.Add(mon.Value<string>());
                            }
                        }

                        Student s = new Student(mssv, hoTenLot, ten, ngaySinh, gioiTinh, lop, cmnd, sdt, diaChi, dsMonHoc);
                        list.Add(s);
                    }
                }
            }

            return list;
        }

     
    }
}