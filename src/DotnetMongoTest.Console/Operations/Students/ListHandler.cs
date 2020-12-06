using DotnetMongoTest.Infra.Interfaces;
using System;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public class ListHandler : OperationHandler
    {
        private readonly IStudentRepository studentRepository;

        public ListHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        protected override void Act()
        {
            Console.Clear();
            var students = studentRepository.List();

            foreach (var student in students)
            {
                Console.WriteLine($"\n\n{student}\n");
            }
        }
    }
}