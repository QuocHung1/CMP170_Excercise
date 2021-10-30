using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text.Json;
using StudentManagementWithWS.Controllers.Models;

namespace StudentManagement_
{
    public class StudentServiceWithFile : IStudentService
    {
        private IList<Student> m_students;
        public StudentServiceWithFile()
        {
            var data = File.ReadAllText(@"D:\CodeVisua\CMP170_Excercies\Practice04\StudentManagement\StudentManagement\Student_Data.json");
            m_students = JsonSerializer.Deserialize<List<Student>>(data);
        }
        public void DeleteStudentById(int id)
        {
            var deletedStudent = LoadStudentById(id);
            if (deletedStudent != null)
            {
                m_students.Remove(deletedStudent);
            }
        }

        public IList<Student> SearchStudent(string keyword, string hutechClass)
        {

            var result = m_students.Where(s => (s.Class == hutechClass || hutechClass == null) && (s.firstname == keyword || s.lastname == keyword || keyword==null ))
                               .OrderBy(s => s.firstname).ToList();

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
            return result;
        }

        public Student LoadStudentById(int id)
        {
            return m_students.FirstOrDefault(x => x.studentId == id);
        }

        public void UpdateOrCreateStudent(Student student)
        {
            if (student.studentId > 0)
            {
                var updateStudent = LoadStudentById(student.studentId);

                updateStudent.lastname = student.lastname;
                updateStudent.firstname = student.firstname;
                updateStudent.Class = student.Class;
                updateStudent.email = student.email;
                updateStudent.gender = student.gender;
                updateStudent.studentId = student.studentId;
            }
            else
            {
                var newStudentId = m_students.Select(s => s.studentId).OrderByDescending(s => s).FirstOrDefault();
                student.studentId = newStudentId + 1;
                m_students.Add(student);
            }
        }
    }
}
