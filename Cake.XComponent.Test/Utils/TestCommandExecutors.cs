using Cake.XComponent.Exception;
using Cake.XComponent.Utils;

namespace Cake.XComponent.Test.Utils
{
    internal class OkCommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(string arguments)
        {
        }
    }

    internal class FailingCommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(string arguments)
        {
            throw new XComponentException("");
        }
    }
}
