using DotnetMongoTest.Infra.Interfaces;
using MongoDB.Bson;
using System;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class DeleteHandler : OperationWithMenuHandler
    {
        private readonly IStudentRepository studentRepository;
        private ObjectId id;

        public DeleteHandler(IStudentRepository studentRepository)
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
            studentRepository.Delete(id);
        }
    }
}
