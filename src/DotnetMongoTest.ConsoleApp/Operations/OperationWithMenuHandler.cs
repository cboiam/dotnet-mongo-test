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

            try
            {
                Render();
                base.Handle();
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    RenderError(ex);
                    Handle();
                    return;
                }

                if (ex.InnerException is FormatException)
                {
                    RenderError(ex.InnerException);
                    Handle();
                    return;
                }

                throw;
            }
        }

        private static void RenderError(Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            Console.WriteLine(OperationMessages.ReturnToMenu);
            Console.ReadKey();
        }
    }
}