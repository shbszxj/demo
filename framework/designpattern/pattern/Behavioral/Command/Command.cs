using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace DesignPattern.Behavioral.Command
{
    public class Command : IDesignPatternDemo
    {
        public string Title => "14.1";

        public string Description => "Command - Command";

        public void Run()
        {
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000)
            };

            WriteLine(ba);

            foreach (var c in commands)
                c.Call();

            WriteLine(ba);

            foreach (var c in Enumerable.Reverse(commands))
                c.Undo();

            WriteLine(ba);
        }

        class BankAccount
        {
            private int _balance;
            private int _overdraftLimit = -500;

            public void Deposit(int amount)
            {
                _balance += amount;
                WriteLine($"Deposited ${amount}, balance is now {_balance}");
            }

            public bool Withdraw(int amount)
            {
                if (_balance - amount >= _overdraftLimit)
                {
                    _balance -= amount;
                    WriteLine($"Withdrew ${amount}, balance is now {_balance}");
                    return true;
                }
                return false;
            }

            public override string ToString()
            {
                return $"{nameof(_balance)}: {_balance}";
            }
        }

        interface ICommand
        {
            void Call();

            void Undo();
        }

        class BankAccountCommand : ICommand
        {
            private BankAccount _account;

            public enum Action
            {
                Deposit, Withdraw
            }

            private Action _action;
            private int _amount;
            private bool _succeed;

            public BankAccountCommand(BankAccount account, Action action, int amount)
            {
                _account = account;
                _action = action;
                _amount = amount;
            }

            public void Call()
            {
                switch (_action)
                {
                    case Action.Deposit:
                        _account.Deposit(_amount);
                        _succeed = true;
                        break;
                    case Action.Withdraw:
                        _account.Withdraw(_amount);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public void Undo()
            {
                if (!_succeed)
                    return;

                switch (_action)
                {
                    case Action.Deposit:
                        _account.Withdraw(_amount);
                        break;
                    case Action.Withdraw:
                        _account.Deposit(_amount);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
