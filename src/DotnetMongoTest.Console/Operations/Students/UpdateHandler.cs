using System;
using DotnetMongoTest.Infra.Interfaces;
using DotnetMongoTest.Infra.Models;
using MongoDB.Bson;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class UpdateHandler : OperationWithMenuHandler
    {
        private readonly Student student = new Student();
        private readonly IStudentRepository studentRepository;

        public UpdateHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public override void Render()
        {
            Console.Write("Student Id: ");
            student.Id = ObjectId.Parse(Console.ReadLine());

            Console.Write("Student Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Student Birth: ");
            student.Birth = DateTime.Parse(Console.ReadLine());

            Console.Write("Student Semester: ");
            student.Semester = int.Parse(Console.ReadLine());
        }

        protected override void Act()
        {
            studentRepository.Update(student);
        }
    }
}