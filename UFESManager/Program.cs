using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFESManager.Data;
using UFESManager.Models;
using UFESManager.Services;

namespace UFESManager
{
    class Program
    {
        private static UFESManagerContext _context;
        private static DepartmentService _departmentService;
        private static StudentService _studentService;        

        static async Task Main(string[] args)
        {
            // Instanciar o context do banco de dados
            using (_context = new UFESManagerContext())
            {
                _departmentService = new DepartmentService(_context);
                _studentService = new StudentService(_context);

                // Ciclo do programa
                while (true)
                {
                    Console.Write("Escolha: \n1 - Adicionar um Estudante \n2 - Exibir todos os estudantes \n3 - Pegar todos os departamentos \n4 - Encerrar aplicação \nDigite aqui: ");
                    int answer = int.Parse(Console.ReadLine());

                    if (answer == 1)
                    {
                        await AddUser();
                    }

                    else if(answer == 2)
                    {
                        DisplayAllStudents();
                    }

                    else if (answer == 3)
                    {
                        await GetAllDepartmentsAsync();
                    }

                    else if (answer == 4)
                    {
                        break;
                    }
                }
            }
        }

        private static async Task AddUser()
        {
            Console.WriteLine("-- Digite as informações do novo estudante --");

            // Id
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            // Nome
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            // Email
            Console.Write("Email: ");
            string email = Console.ReadLine();

            // Telefone
            Console.Write("Telefone: ");
            int phone = int.Parse(Console.ReadLine());

            // Id do curso
            Console.Write("Id do curso: ");
            int courseId = int.Parse(Console.ReadLine());

            // Ids das disciplinas
            Console.Write("Id das disciplinas (Separados por vírgula. Ex: 101, 254, 112) \nDigite aqui: ");
            string[] stringIds = Console.ReadLine().Split(',');
            List<int> subjectsIds = new List<int>();
            foreach(string currentId in stringIds)
            {
                subjectsIds.Add(int.Parse(currentId));
            }

            // Pegar o curso do estudante
            Course studentCourse = _context.Courses.Where(c => c.CourseId == courseId).FirstOrDefault();
            Student newStudent = new Student(id, name, email, phone, studentCourse);

            // Adicionar as disicplinas
            List<Subject> studentSubjects = _context.Subjects.Where(s => subjectsIds.Contains(s.SubjectId)).ToList();
            newStudent.AddSubject(studentSubjects);

            await _studentService.AddStudentAsync(newStudent);
        }

        private static void DisplayAllStudents()
        {
            _studentService.DisplayAllStudents();
        }

        private static async Task GetAllDepartmentsAsync()
        {
            // Pegar todos os departamentos
            List<Department> departments = await _departmentService.GetAllDepartmentsAsync();

            Console.WriteLine("\n-- Exibir todos os departamentos --");

            Console.WriteLine("----------------------------");

            foreach (Department department in departments)
            {
                Console.WriteLine(department);

                Console.WriteLine("----------------------------");
            }
        }
    }
}
