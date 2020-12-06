using DotnetMongoTest.Infra.Interfaces;
using System;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class DetailHandler : OperationWithMenuHandler
    {
        private readonly IStudentRepository studentRepository;
        private string id;

        public DetailHandler(IStudentRepository studentRepository)
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
            var student = studentRepository.Detail(id);

            if(student == null)
            {
                Console.WriteLine(StudentMessages.StudentNotFound);
                return;
            }

            Console.WriteLine($"\n{student}\n");
        }
    }
}