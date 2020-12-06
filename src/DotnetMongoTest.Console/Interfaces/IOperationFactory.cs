using DotnetMongoTest.ConsoleApp.Enums;

namespace DotnetMongoTest.ConsoleApp.Interfaces
{
    public interface IOperationFactory
    {
        IOperationHandler GetOperationHandler(Operation operation);
    }
}