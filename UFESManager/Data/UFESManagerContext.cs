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
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}
