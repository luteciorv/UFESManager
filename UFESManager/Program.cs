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
                // Alocar os serviços
                _departmentService = new DepartmentService(_context);
                _studentService = new StudentService(_context);

                bool looping = true;

                Console.WriteLine("===== UFES MANAGER 1.0v =====");

                // Ciclo do programa
                while (looping)
                {
                    Console.Write("\nEscolha uma seção " +
                        "\n1 - Departamentos" +
                        "\n2 - Cursos" +
                        "\n3 - Estudantes" +
                        "\n4 - Disciplinas" +
                        "\n5 - Encerrar aplicação " +
                        "\n\nDigite aqui: ");

                    // Resposta captada
                    int answer = int.Parse(Console.ReadLine());

                    // Caso a resposta seja igual ao
                    switch (answer)
                    {
                        /*
                        // Departamentos
                        case 1:
                            {
                                await DepartmentsAsync();
                                break;
                            }

                        // Cursos
                        case 2:
                            {
                                Courses();
                                break;
                            }
                        */
                        // Estudantes
                        case 3:
                            {
                                await StudentsAsync();
                                break;
                            }
                        /*
                    // Disciplinas
                    case 4:
                        {
                            Subjects();
                            break;
                        }
                    */
                        // Encerrar
                        case 5:
                            {
                                looping = false;
                                break;
                            }


                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }

        #region Departamentos        
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
        #endregion

        #region Cursos

        #endregion

        #region Estudantes
        private static async Task StudentsAsync()
        {
            bool looping = true;
            while (looping)
            {
                Console.Write("\nEscolha uma ação " +
                       "\n1 - Adicionar novo estudante" +
                       "\n2 - Remover estudante" +
                       "\n3 - Exibir um estudante" +
                       "\n4 - Exibir todos os estudantes" +
                       "\n5 - Voltar" +
                       "\n\nDigite aqui: ");

                // Resposta captada
                int answer = int.Parse(Console.ReadLine());

                // Caso a resposta seja igual ao
                switch (answer)
                {
                    // Adicionar um estudante
                    case 1:
                        {
                            await AddStudent();
                            break;
                        }

                    // Remover um estudante
                    case 2:
                        {
                            await RemoveStudent();
                            break;
                        }

                    // Exibir um estudante
                    case 3:
                        {
                            DisplayStudent();
                            break;
                        }

                    // Exibir todos os estudantes
                    case 4:
                        {
                            _studentService.DisplayAllStudents();
                            break;
                        }

                    // Disciplinas
                    case 5:
                        {
                            looping = false;
                            break;
                        }


                    default:
                        {
                            break;
                        }
                }
            }
        }

        private static async Task AddStudent()
        {
            Console.WriteLine("\n-- Digite as informações do novo estudante --");

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
            foreach (string currentId in stringIds)
            {
                subjectsIds.Add(int.Parse(currentId));
            }

            // Pegar o curso do estudante
            Course studentCourse = _context.Course.Where(c => c.CourseId == courseId).FirstOrDefault();
            Student newStudent = new Student(id, name, email, phone, studentCourse);

            // Adicionar as disicplinas
            List<Subject> studentSubjects = _context.Subject.Where(s => subjectsIds.Contains(s.SubjectId)).ToList();
            newStudent.AddSubject(studentSubjects);

            await _studentService.AddStudentAsync(newStudent);
        }

        private static async Task RemoveStudent()
        {
            Console.WriteLine("-- REMOVER ESTUDANTE --");

            // Id
            Console.Write("Digite o Id do estudante: ");
            int id = int.Parse(Console.ReadLine());

            await _studentService.RemoveStudentAsync(id);
        }

        private static void DisplayStudent()
        {
            Console.WriteLine("-- Digite as informações do estudante --");

            // Id
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            _studentService.DisplatStudent(id);
        }
        #endregion

        #region Disciplinas

        #endregion
    }
}
