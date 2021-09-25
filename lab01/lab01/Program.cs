using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice_1
{
    class Program
    {


        class Student
        {


            public string StudentID { get; set; }
            public string FullName { get; set; }
            public float AverageScore { get; set; }
            public string Faculty { get; set; }


            public Student()
            {
            }
            public Student(string id, string name, float score, string faculty)
            {
                StudentID = id;
                FullName = name;
                AverageScore = score;
                Faculty = faculty;
            }

            public void Input()
            {
                Console.Write("Nhập MSSV:");
                StudentID = Console.ReadLine();
                Console.Write("Nhập Họ tên Sinh viên:");
                FullName = Console.ReadLine();
                Console.Write("Nhập Điểm TB:");
                AverageScore = float.Parse(Console.ReadLine());
                Console.Write("Nhập Khoa:");
                Faculty = Console.ReadLine();
            }
            public void Show()
            {
                Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", this.StudentID,
                this.FullName, this.Faculty, this.AverageScore);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<Student> ListStudents = new List<Student>();
            ListStudents.Add(new Student("Sv01", "Trần thị AB", 8, "NHKS"));
            ListStudents.Add(new Student("Sv02", "Trần thị BC", 6, "CNTT"));
            ListStudents.Add(new Student("Sv03", "Trần thị DE", 7, "CNTT"));
            ListStudents.Add(new Student("Sv04", "Trần thị CH", 9, "QTKD"));
            ListStudents.Add(new Student("Sv05", "Trần thị KH", 5, "QTKD"));
            ListStudents.Add(new Student("Sv06", "Trần thị UK", 6, "QTKD"));
            ListStudents.Add(new Student("Sv07", "Trần thị CA", 9, "NHKS"));
            ListStudents.Add(new Student("Sv08", "Trần thị NA", 8, "NHKS"));

            Console.WriteLine("\n ====3====");
            var danhsasch = ListStudents.OrderBy(x => x.AverageScore);
            foreach (var item in danhsasch)
            {
                Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", item.StudentID,
                item.FullName, item.Faculty, item.AverageScore);
            }

            Console.WriteLine("\n ====1====");
            var CNTT = ListStudents.FindAll(x => x.Faculty == "CNTT");
            foreach (var item in CNTT)
            {
                Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", item.StudentID,
                item.FullName, item.Faculty, item.AverageScore);
            }
            Console.WriteLine("\n ====2====");
            var NamDiem = ListStudents.FindAll(x => x.AverageScore >= 5);
            foreach (var item in NamDiem)
            {
                Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", item.StudentID,
                item.FullName, item.Faculty, item.AverageScore);
            }
            Console.WriteLine("\n ====4====");
            var NamDiemCNTT = ListStudents.FindAll(x => x.AverageScore >= 5);
            foreach (var item in NamDiemCNTT)
            {
                if (item.Faculty == "CNTT")
                {


                    Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", item.StudentID,
                    item.FullName, item.Faculty, item.AverageScore);
                }
            }
            Console.WriteLine("\n ====5====");
            var findmax = CNTT.Max(x => x.AverageScore);
            var BeztCNTT = ListStudents.FindAll(y => y.AverageScore == findmax && y.Faculty == "CNTT");

            foreach (var item in BeztCNTT)
            {

                Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", item.StudentID,
            item.FullName, item.Faculty, item.AverageScore);


            }
            Console.ReadKey();
        }
    }
}