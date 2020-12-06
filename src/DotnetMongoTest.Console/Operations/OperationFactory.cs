using System;
using DotnetMongoTest.ConsoleApp.Enums;
using DotnetMongoTest.ConsoleApp.Interfaces;
using DotnetMongoTest.ConsoleApp.Operations.Students;
using DotnetMongoTest.Infra.Interfaces;

namespace DotnetMongoTest.ConsoleApp.Operations
{
    public class OperationFactory : IOperationFactory
    {
        private readonly IStudentRepository studentRepository;

        public OperationFactory(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IOperationHandler GetOperationHandler(Operation operation)
        {
            return operation switch
            {
                Operation.List => new ListHandler(studentRepository),
                Operation.Detail => new DetailHandler(studentRepository),
                Operation.Add => new AddHandler(studentRepository),
                Operation.Update => new UpdateHandler(studentRepository),
                Operation.Delete => new DeleteHandler(studentRepository),
                _ => throw new NotImplementedException()
            };
        }
    }
}