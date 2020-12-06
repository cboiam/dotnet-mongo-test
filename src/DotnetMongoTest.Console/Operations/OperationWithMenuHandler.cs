using DotnetMongoTest.ConsoleApp.Interfaces;
using System;

namespace DotnetMongoTest.ConsoleApp.Operations
{
    public abstract class OperationWithMenuHandler : OperationHandler, IMenu
    {
        public abstract void Render();

        public override void Handle()
        {
            Console.Clear();
            Render();
            base.Handle();
        }
    }
}