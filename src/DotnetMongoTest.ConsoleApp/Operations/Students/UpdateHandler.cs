using System;
using DotnetMongoTest.Infra.Interfaces;
using DotnetMongoTest.Infra.Models;

namespace DotnetMongoTest.ConsoleApp.Operations.Students
{
    public partial class UpdateHandler : OperationWithMenuHandler
    {
        private record ConsoleStudent(string Id, string Name, string Birth, string Semester);
        private ConsoleStudent consoleStudent;
        private Student student;

        private readonly IStudentRepository studentRepository;

        public UpdateHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public override void Render()
        {
            Console.Write("Student Id: ");
            var id = Console.ReadLine();

            Console.Write("Student Name: ");
            var name = Console.ReadLine();

            Console.Write("Student Birth: ");
            var birth = Console.ReadLine();

            Console.Write("Student Semester: ");
            var semester = Console.ReadLine();

            consoleStudent = new ConsoleStudent(id, name, birth, semester);
        }

        protected override void Act()
        {
            var existingStudent = studentRepository.Detail(consoleStudent.Id);

            if (existingStudent == null)
            {
                Console.WriteLine(StudentMessages.StudentNotFound);
                return;
            }

            student = existingStudent with
            {
                Name = string.IsNullOrWhiteSpace(consoleStudent.Name) ? existingStudent.Name : consoleStudent.Name,
                Birth = string.IsNullOrWhiteSpace(consoleStudent.Birth) ? existingStudent.Birth : DateTime.Parse(consoleStudent.Birth),
                Semester = string.IsNullOrWhiteSpace(consoleStudent.Semester) ? existingStudent.Semester : int.Parse(consoleStudent.Semester),
            };

            studentRepository.Update(student);
        }
    }
}