using DotnetMongoTest.Infra.Interfaces;
using MongoDB.Bson;
using System;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class DetailHandler : OperationWithMenuHandler
    {
        private readonly IStudentRepository studentRepository;
        private ObjectId id;

        public DetailHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public override void Render()
        {
            Console.Write("Student Id: ");
            id = ObjectId.Parse(Console.ReadLine());
        }

        protected override void Act()
        {
            var student = studentRepository.Detail(id);
            Console.WriteLine($"\n\n{student}\n");
        }
    }
}