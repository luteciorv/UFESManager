using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFESManager.Data;
using UFESManager.Models;

namespace UFESManager.Services
{
    public class StudentService
    {
        // Banco de dados
        private readonly UFESManagerContext _context;

        // Método construtor #1
        public StudentService(UFESManagerContext context)
        {
            _context = context;
        }

        // Adicionar um estudante => Assíncrona
        public async Task AddStudentAsync(Student student)
        {
            // Verificar se o estudante já está matriculado
            bool alreadyRegisted = _context.Students.Where(s => s.StudentId == student.StudentId).Any();

            if (alreadyRegisted) 
            {
                Console.WriteLine("Estudante já matriculado");
                return;
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            Console.WriteLine("Estudante matriculado com sucesso!");
        } 

        // Exibir todos os estudantes
        public void DisplayAllStudents()
        {
            Console.WriteLine("\n-- TODOS os estudantes --");

            Console.WriteLine("====================");

            foreach(Student currentStudent in _context.Students)
            {
                Console.WriteLine(currentStudent);

                Console.WriteLine("====================");
            }           
        }
    }
}
