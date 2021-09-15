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
            bool alreadyRegisted = _context.Student.Where(s => s.StudentId == student.StudentId).Any();

            if (alreadyRegisted) 
            {
                Console.WriteLine("Estudante já matriculado");
                return;
            }

            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            Console.WriteLine("Estudante matriculado com sucesso!");
        }

        // Remove um estudante => Assíncrona
        public async Task RemoveStudentAsync(int studentId)
        {
            // Encontrar o estudante
            Student studentToRemove = _context.Student.Where(s => s.StudentId == studentId).FirstOrDefault();
            
            // Caso não tenha encontrado
            if(studentToRemove == null)
            {
                Console.WriteLine($"Não existe nenhum estudante com o id {studentId}");
                return;
            }

            // Remover
            _context.Student.Remove(studentToRemove);

            // Salvar
            await _context.SaveChangesAsync();
        }

        //Exibir o estudante solicitado
        public void DisplatStudent(int studentId)
        {
            // Encontrar o estudante
            Student student = _context.Student.Where(s => s.StudentId == studentId).FirstOrDefault();

            // Caso não tenha encontrado
            if (student == null)
            {
                Console.WriteLine($"Não existe nenhum estudante com o id {studentId}");
                return;
            }

            Console.WriteLine(student);
        }

        // Exibir todos os estudantes
        public void DisplayAllStudents()
        {
            Console.WriteLine("\n-- TODOS os estudantes --");

            Console.WriteLine("====================");

            foreach(Student currentStudent in _context.Student)
            {
                Console.WriteLine(currentStudent);

                Console.WriteLine("====================");
            }           
        }
    }
}
