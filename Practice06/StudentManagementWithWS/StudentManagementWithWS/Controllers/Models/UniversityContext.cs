using Microsoft.EntityFrameworkCore;
using StudentManagementWithWS.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace StudentManagement_
{
    class UniversityContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlServer(@"Server=.;Database=ShoolDB_EFCore;MultipleActiveResultSets=true;Trusted_connection=true;Integrated Security=true;");
        }
        public DbSet<Student> Students { get; set; }
    }
}
