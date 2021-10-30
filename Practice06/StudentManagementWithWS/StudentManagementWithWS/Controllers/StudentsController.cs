using Microsoft.AspNetCore.Mvc;
using StudentManagement_;
using StudentManagementWithWS.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementWithWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService m_studentService;
        public StudentsController(IStudentService studentService)
        {
            m_studentService = studentService;
        }
        [HttpGet]
        public IActionResult SearchStudent(string keyword, string hutechClass)
        {
            return Ok(m_studentService.SearchStudent(keyword, hutechClass));
        }
        [HttpGet("{id}")]
        public IActionResult LoadStudentbyId(int id)
        {
            return Ok(m_studentService.LoadStudentById(id));
        }
        [HttpPost]
        public IActionResult UpdateOrCreateStudent(Student student)
        {
            m_studentService.UpdateOrCreateStudent(student);
            return Ok();
        }
        [HttpDelete ("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            m_studentService.DeleteStudentById(id);
            return Ok();
        }
    }
}
