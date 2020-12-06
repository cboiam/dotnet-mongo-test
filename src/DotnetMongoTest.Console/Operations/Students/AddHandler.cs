using System;
using DotnetMongoTest.Infra.Interfaces;
using DotnetMongoTest.Infra.Models;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class AddHandler : OperationWithMenuHandler
    {
        private readonly Student student = new Student();
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
            student.Name = Console.ReadLine();

            Console.Write("Student Birth: ");
            student.Birth = DateTime.Parse(Console.ReadLine());

            Console.Write("Student Semester: ");
            student.Semester = int.Parse(Console.ReadLine());
        }
    }
}