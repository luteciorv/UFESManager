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
     * Representa os alunos associados aos cursos da universidade que apresentam
     * disciplinas atreladas
     */
    public class Student
    {
        // Atributos 
        [Key()]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        // Relacionamento => Cursos
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        // Relacionamento => Disciplinas
        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        // Método construtor #1
        public Student() { }

        // Método construtor #2
        public Student(int studentId, string name, string email, int phone, Course course)
        {
            StudentId = studentId;
            Name = name;
            Email = email;
            Phone = phone;
            Course = course;
        }

        // Adicionar uma disciplina ao estudante atual
        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

        // Adicionar as disciplinas ao estudante atual
        public void AddSubject(List<Subject> subjects)
        {
            foreach(Subject currentSubject in subjects)
            {
                Subjects.Add(currentSubject);
            }            
        }

        // Remover disciplina do estudante atual
        public void RemoveSubject(Subject subject)
        {
            Subjects.Remove(subject);
        }

        // Retornar o total de carga horária do estudante atual
        public int TotalWorkload()
        {
            return Subjects.Select(s => s.Workload).Sum();
        }

        // Exibir informações
        public override string ToString()
        {
            List<Subject> subjects = Subjects.ToList();
            return $"Identificação do estudante: {StudentId} \n" +
                $"Nome: {Name} \n" +
                $"Email: {Email} \n" +
                $"Telefone: {Phone} \n" +
                $"Id do curso: {CourseId} \n" +
                $"Nome do curso: {Course.Name} \n" +
                $"Matérias: {Subjects.ToList().Select(s => s.ToString())}";
        }
    }
}
