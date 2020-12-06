using System;
using DotnetMongoTest.ConsoleApp.Interfaces;

namespace DotnetMongoTest.ConsoleApp.Operations
{
    public abstract class OperationHandler : IOperationHandler
    {
        protected abstract void Act();

        public virtual void Handle()
        {
            Act();
            Console.WriteLine(OperationMessages.ReturnToMenu);
            Console.ReadKey();
        }
    }
}