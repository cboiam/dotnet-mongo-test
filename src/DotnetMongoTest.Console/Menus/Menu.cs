using System;
using System.Linq;
using DotnetMongoTest.ConsoleApp.Enums;
using DotnetMongoTest.ConsoleApp.Interfaces;

namespace DotnetMongoTest.ConsoleApp.Menus
{
    public class Menu : IMenu
    {
        private readonly int[] operations = Enum.GetValues(typeof(Operation)) as int[];
        private readonly IOperationFactory operationFactory;

        public Menu(IOperationFactory operationFactory)
        {
            this.operationFactory = operationFactory;
        }

        public void Render()
        {
            Console.Clear();
            RenderOperations();

            try
            {
                var operation = GetOperationFromUser();

                if(operation == Operation.Exit)
                {
                    return;
                }

                var operationHandler = operationFactory.GetOperationHandler(operation);
                operationHandler.Handle();
            }
            catch (Exception ex)
            {
                if (!(ex is ArgumentOutOfRangeException || ex is ArgumentException))
                {
                    throw;
                }

                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
            }
            Render();
        }

        private void RenderOperations()
        {
            foreach (int operation in operations)
            {
                Console.WriteLine($"{operation} - {(Operation)operation}");
            }
        }

        private Operation GetOperationFromUser()
        {
            Console.WriteLine();
            Console.Write("Operation: ");
            var key = Console.ReadKey().KeyChar.ToString();

            if (!int.TryParse(key, out int option))
            {
                throw new ArgumentException($"Invalid operation, it should be a number between {operations.Min()} and {operations.Max()}.", "Operation");
            }

            if (operations.Any(o => o == option))
            {
                return (Operation)option;
            }

            throw new ArgumentOutOfRangeException("Operation", option, $"Invalid operation, select an operation between {operations.Min()} and {operations.Max()}.");
        }
    }
}