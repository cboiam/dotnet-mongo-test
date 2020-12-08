using DotnetMongoTest.Infra.Interfaces;
using DotnetMongoTest.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

            if (!students.Any())
            {
                Console.WriteLine(StudentMessages.NoStudentsFound);
                return;
            }
            Render(students);
        }

        private void Render(IEnumerable<Student> students)
        {
            Console.WriteLine();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }
    }
}