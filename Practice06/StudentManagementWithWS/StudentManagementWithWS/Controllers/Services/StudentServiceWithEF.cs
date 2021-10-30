using StudentManagementWithWS.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagement_
{
    public class StudentServiceWithEF:IStudentService
    {
        public StudentServiceWithEF()
        {
            using (var ctx = new UniversityContext())
            {
                ctx.Database.EnsureCreated();
            }
        }

        public void DeleteStudentById(int id)
        {
            using(var ctx = new UniversityContext())
            {
                var deletedStudent = ctx.Students.Find(id);
                ctx.Students.Remove(deletedStudent);
                ctx.SaveChanges();
            }
        }

        public Student LoadStudentById(int id)
        {
            using (var ctx = new UniversityContext())
            {
                return ctx.Students.FirstOrDefault(s=>s.studentId==id);
            }
        }

        public IList<Student> SearchStudent(string keyword, string hutechClass)
        {
            using (var ctx = new UniversityContext())
            {
                var result = ctx.Students.Where(s => (s.Class == hutechClass || hutechClass == null) && (s.firstname == keyword || s.lastname == keyword || keyword == null))
                               .OrderBy(s => s.firstname).ToList();
                return result;
            }
        }

        public void UpdateOrCreateStudent(Student student)
        {
            using (var ctx = new UniversityContext())
            {
                if (student.studentId >0 )
                {
                    var dbStudent = ctx.Students.Find(student.studentId);

                    dbStudent.lastname = student.lastname;
                    dbStudent.firstname = student.firstname;
                    dbStudent.Class = student.Class;
                    dbStudent.email = student.email;
                    dbStudent.gender = student.gender;
                    dbStudent.studentId = student.studentId;
                }
                else
                {
                    ctx.Students.Add(student);
                }
                ctx.SaveChanges();
            }
        }
    }
}
