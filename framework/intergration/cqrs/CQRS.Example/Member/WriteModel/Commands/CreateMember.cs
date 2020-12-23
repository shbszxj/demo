using CQRSlite.Commands;
using System;

namespace CQRS.Example.Member.WriteModel.Commands
{
    public class CreateMember : ICommand
    {
        public Guid Id { get; set; }
        public int ExpectedVersion { get; set; }

        public readonly string UserName;

        public readonly string Password;

        public CreateMember(Guid id, string name)
        {

        }
    }
}
