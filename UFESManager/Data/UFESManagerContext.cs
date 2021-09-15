using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFESManager.Models;

namespace UFESManager.Data
{
    public class UFESManagerContext : DbContext
    {
        // Método construtor #1
        public UFESManagerContext() : base("UFES Manager") { }
        
        // Tabelas
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
