using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFESManager.Models
{
    /*
     * Representa as disciplinas em que os alunos estão matriculados
     */
    public class Subject
    {
        // Atributos
        [Key()]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }

        // Relacionamento => Estudantes
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        // Método construtor #1
        public Subject() { }

        // Método construtor #2
        public Subject(int subjectId, string name, int workload)
        {
            SubjectId = subjectId;
            Name = name;
            Workload = workload;
        }
        
        // Adicionar um estudante a diciplina atual
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        // Remover um estudante da disciplina atual
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        // Retornar a quantidade total de estudantes matriculados nesta disciplina
        public int TotalOfStudents()
        {
            return Students.Count();
        }

        // Exibir informações da matéria
        public override string ToString()
        {
            return $"[Id: {SubjectId}, Nome: {Name}, Carga horária: {Workload}]";
        }
    }
}
