using CQRSlite.Commands;

namespace Domain.Delegate.WriteModel.Commands
{
    public class BaseCommand : ICommand
    {
        public int ExpectedVersion { get; set; }
    }
}
