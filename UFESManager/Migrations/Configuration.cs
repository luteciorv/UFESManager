namespace UFESManager.Migrations
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UFESManager.Data;
    using UFESManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.UFESManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UFESManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Verificar se já existe algum dado nas tabelas
            if (context.Departments.Any() || context.Courses.Any() ||
                context.Students.Any() || context.Subjects.Any()) { return; }

            //===== Povoar as tabelas
            //= Departamentos
            IList<Department> departments = new List<Department>();

            Department d1 = new Department(1, "DCAB - Departamento de Ciências Agrárias e Biológicas");
            Department d2 = new Department(2, "DCN - Departamento de Ciências Naturais");
            Department d3 = new Department(3, "DCS - Departamento de Ciências da Saúde");
            Department d4 = new Department(4, "DCEL - Departamento de Computação e Eletrônica");
            Department d5 = new Department(5, "DECH - Departamento de Educação e Ciências Humanas");
            Department d6 = new Department(6, "DETEC - Departamento de Engenharias e Tecnologia");
            Department d7 = new Department(7, "DMA - Departamento de Matemática Aplicada");

            //= Adicionar eles em uma IList
            departments.Add(d1);
            departments.Add(d2);
            departments.Add(d3);
            departments.Add(d4);
            departments.Add(d5);
            departments.Add(d6);
            departments.Add(d7);

            //=== Cursos
            IList<Course> courses = new List<Course>();

            Course c1 = new Course(1, "Agronomia", d1);
            Course c2 = new Course(2, "Biologia", d1);
            Course c3 = new Course(3, "Filosofia", d2);
            Course c4 = new Course(4, "História", d2);
            Course c5 = new Course(5, "Enfermagem", d3);
            Course c6 = new Course(6, "Medicina", d3);
            Course c7 = new Course(7, "Ciência da computação", d4);
            Course c8 = new Course(8, "Engenharia de Petróleo", d4);
            Course c9 = new Course(9, "Pedagogia", d5);
            Course c10 = new Course(10, "Letras", d5);
            Course c11 = new Course(11, "Engenharia Civil", d6);
            Course c12 = new Course(12, "Informática", d6);
            Course c13 = new Course(13, "Matemática", d7);
            Course c14 = new Course(14, "Matemática Aplicada", d7);

            //= Adicionar
            courses.Add(c1);
            courses.Add(c2);
            courses.Add(c3);
            courses.Add(c4);
            courses.Add(c5);
            courses.Add(c6);
            courses.Add(c7);
            courses.Add(c8);
            courses.Add(c9);
            courses.Add(c10);
            courses.Add(c11);
            courses.Add(c12);
            courses.Add(c13);
            courses.Add(c14);

            //=== Disciplinas
            IList<Subject> subjects = new List<Subject>();

            Subject sb1 = new Subject(1001, "Matemática Básica I", 90);
            Subject sb2 = new Subject(1002, "Cálculo I", 90);
            Subject sb3 = new Subject(1003, "Introdução a Anatomia", 90);
            Subject sb4 = new Subject(1004, "Didática", 60);
            Subject sb5 = new Subject(1005, "Algoritmos Numéricos I", 60);
            Subject sb6 = new Subject(1006, "Otimização", 50);
            Subject sb7 = new Subject(1007, "Fundamentos da História e Educação", 50);
            Subject sb8 = new Subject(1008, "Morfossintaxe II", 90);
            Subject sb9 = new Subject(1009, "Citologia", 60);
            Subject sb10 = new Subject(1010, "Ética e Moral I", 60);

            //= Adicionar
            subjects.Add(sb1);
            subjects.Add(sb2);
            subjects.Add(sb3);
            subjects.Add(sb4);
            subjects.Add(sb5);
            subjects.Add(sb6);
            subjects.Add(sb7);
            subjects.Add(sb8);
            subjects.Add(sb9);
            subjects.Add(sb10);

            //=== Estudantes
            IList<Student> students = new List<Student>();

            Student s1 = new Student(1, "Luís", "luis@gmail.com", 90294817, c13);
            Student s2 = new Student(2, "Israel", "junior@gmail.com", 59798982, c13);
            Student s3 = new Student(3, "Marcos", "marcos@gmail.com", 99713453, c1);
            Student s4 = new Student(4, "Fábio", "fabio@gmail.com", 17153405, c2);
            Student s5 = new Student(5, "Júlia", "julia@gmail.com", 73563464, c3);
            Student s6 = new Student(6, "Amanda", "amanda@gmail.com", 15647231, c4);
            Student s7 = new Student(7, "Letícia", "leticia@gmail.com", 20316827, c5);
            Student s8 = new Student(8, "Thaina", "thaina@gmail.com", 88880916, c8);
            Student s9 = new Student(9, "Flávia", "flavia@gmail.com", 21956699, c9);
            Student s10 = new Student(10, "Rodrigo", "rodrigo@gmail.com", 89340993, c11);
            Student s11 = new Student(11, "Lucca", "lucca@gmail.com", 22840620, c12);

            //= Adicionar
            List<Subject> student1Subjects = new List<Subject>() { sb1, sb2, sb6 };
            s1.AddSubject(student1Subjects);
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);
            students.Add(s6);
            students.Add(s7);
            students.Add(s8);
            students.Add(s9);
            students.Add(s10);
            students.Add(s11);                              

            //=== Adicionar ao banco de dados
            // Tabela de departamentos
            context.Departments.AddRange(departments);

            // Tabela de cursos
            context.Courses.AddRange(courses);

            // Tabela de estudantes
            context.Students.AddRange(students);

            // Tabela de disciplinas
            context.Subjects.AddRange(subjects);

            // Salvar as alterações feitas
            context.SaveChanges();
        }
    }
}
