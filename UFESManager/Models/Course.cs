using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFESManager.Models
{
    /*
     * Representa os cursos que contém os alunos matriculados neles e também estão
     * associados aos seus respectivos departamentos
     */
    public class Course
    {
        // Atributos
        [Key()]
        public int CourseId { get; set; }
        public string Name { get; set; }

        // Relacionamento => Departamento
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        // Relacionamento => Estudantes
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        // Método construtor #1
        public Course() { }

        // Método construtor #2
        public Course(int courseId, string name, Department department)
        {
            CourseId = courseId;
            Name = name;
            Department = department;
        }

        // Adicionar um estudante no curso atual
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        // Remover um estudante do curso atual
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        // Retorna o total de estudantes do curso atual
        public int TotalOfStudents()
        {
            return Students.Count();
        }
    }
}
