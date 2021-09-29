using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static ex4.IComparable;
using static ex4.IComparer;

namespace ex4
{
    public class IComparable
    {
        public class Student : IComparable<Student>
        {


            public string StudentID { get; set; }
            public string FullName { get; set; }


            public Student()
            {
            }
            public Student(string id, string name)
            {
                StudentID = id;
                FullName = name;
            }

            public int CompareTo(Student other)
            {
                return this.StudentID.CompareTo(other.StudentID);
            }
        }


    }
    public class IComparer
    {
        public class SortPersonByName : IComparer<Student>
        {
            public int Compare([AllowNull] Student x, [AllowNull] Student y)
            {
                return x.FullName.CompareTo(y.FullName);
            }
        }
    }

    public class main
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<Student> ListStudents = new List<Student>();
            ListStudents.Add(new Student("Sv04", "Nguyễn Văn A"));
            ListStudents.Add(new Student("Sv02", "Nguyễn Văn B"));
            ListStudents.Add(new Student("Sv01", "Trần thị A"));
            ListStudents.Add(new Student("Sv05", "Lê thị C"));
            ListStudents.Add(new Student("Sv06", "Trần Văn E"));
            ListStudents.Add(new Student("Sv07", "Nguyễn Trung G"));
            ListStudents.Add(new Student("Sv03", "Trần Trung F"));
            ListStudents.Add(new Student("Sv00", "Nguyện Thị H"));

            ListStudents.Sort();
            Console.WriteLine("Using IComparable");
            foreach (Student student in ListStudents)
            {
                Console.WriteLine("Name: {0}, ID: {1}", student.FullName, student.StudentID);

            }
            Console.WriteLine("");
            Console.WriteLine("Using IComparer");
            ListStudents.Sort(new SortPersonByName());
            foreach (Student student in ListStudents)
            {
                Console.WriteLine("Name: {0}, ID: {1}", student.FullName, student.StudentID);

            }
        }
    }
}
