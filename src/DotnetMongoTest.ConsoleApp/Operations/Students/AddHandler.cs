using System;
using DotnetMongoTest.Infra.Interfaces;
using DotnetMongoTest.Infra.Models;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class AddHandler : OperationWithMenuHandler
    {
        private Student student;

        private readonly IStudentRepository studentRepository;

        public AddHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        protected override void Act()
        {
            studentRepository.Add(student);
        }

        public override void Render()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Student Birth: ");
            var birth = DateTime.Parse(Console.ReadLine());

            Console.Write("Student Semester: ");
            var semester = int.Parse(Console.ReadLine());

            student = new Student
            {
                Name = name, 
                Birth = birth,
                Semester = semester
            };
        }
    }
}