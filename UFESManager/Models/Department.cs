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
     * Representa os departamentos que contém seus respectivos cursos
     */
    public class Department
    {
        // Atributos
        [Key()]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        
        // Relacionamento => Cursos
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        // Método construtor #1
        public Department() { }

        // Método construtor #2
        public Department(int departmentId, string name)
        {
            DepartmentId = departmentId;
            Name = name;
        }
        
        // Adicionar um curso ao departamento atual
        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        // Remover um curso do departamento atual
        public void RemoveCourse(Course course)
        {
            Courses.Remove(course);
        }

        // Retornar todos os cursos associados a este departamento
        public List<Course> GetAllCourses()
        {
            return Courses.ToList();
        }

        public override string ToString()
        {
            return $"Identificação: {DepartmentId} \nNome: {Name}";
        }
    }
}
