using DotnetMongoTest.Infra.Interfaces;
using System;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class DeleteHandler : OperationWithMenuHandler
    {
        private readonly IStudentRepository studentRepository;
        private string id;

        public DeleteHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public override void Render()
        {
            Console.Write("Student Id: ");
            id = Console.ReadLine();
        }

        protected override void Act()
        {
            var existingStudent = studentRepository.Detail(id);

            if (existingStudent == null)
            {
                Console.WriteLine(StudentMessages.StudentNotFound);
                return;
            }

            studentRepository.Delete(id);
        }
    }
}
