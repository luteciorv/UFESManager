using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFESManager.Data;
using UFESManager.Models;

namespace UFESManager.Services
{
    public class DepartmentService
    {
        // Banco de dados
        private readonly UFESManagerContext _context;

        // Método construtor #1
        public DepartmentService(UFESManagerContext context)
        {
            _context = context;
        }

        // Retorna todos os departamentos
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.OrderBy(d => d.DepartmentId).ToListAsync();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.OrderBy(d => d.DepartmentId).ToList();
        }
    }
}
