using System;
using DotnetMongoTest.ConsoleApp.Interfaces;

namespace DotnetMongoTest.ConsoleApp.Operations
{
    public abstract class OperationHandler : IOperationHandler
    {
        private const string ReturnToMenuMessage = "Press any button to return to main menu.";

        protected abstract void Act();

        public virtual void Handle()
        {
            Act();
            Console.WriteLine(ReturnToMenuMessage);
            Console.ReadKey();
        }
    }
}