using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPattern.Behavioral.Chain.Exercise
{
    public class Exercise : IDesignPatternDemo
    {
        public string Title => "13.3";

        public string Description => "Chain - Exercise";

        public void Run()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            var goblin2 = new Goblin(game);
            var goblin3 = new GoblinKing(game);
            game.Creatures.Add(goblin);
            game.Creatures.Add(goblin2);
            game.Creatures.Add(goblin3);
            WriteLine(goblin);
            WriteLine(goblin2);
            WriteLine(goblin3);
        }
    }

    public enum Statistic
    {
        Attack,
        Defense
    }

    public class StatQuery
    {
        public int Value;
        public Statistic Statistic;

        public StatQuery(Statistic statistic, int value)
        {
            Statistic = statistic;
            Value = value;
        }
    }

    public abstract class Creature
    {
        protected Game game;
        protected readonly int baseAttack, baseDefense;

        protected Creature(Game game, int baseAttack, int baseDefense)
        {
            this.game = game;
            this.baseAttack = baseAttack;
            this.baseDefense = baseDefense;
        }

        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }
        public abstract void Query(object source, StatQuery sq);
    }

    public class Goblin : Creature
    {
        public Goblin(Game game) : base(game, 1, 1)
        {

        }

        protected Goblin(Game game, int baseAttack, int baseDefense) : base(game, baseAttack, baseDefense)
        {

        }

        public override int Defense
        {
            get
            {
                var q = new StatQuery(Statistic.Defense, 0);
                foreach (var c in game.Creatures)
                {
                    c.Query(this, q);
                }
                return q.Value;
            }
        }

        public override int Attack
        {
            get
            {
                var q = new StatQuery(Statistic.Attack, 0);
                foreach (var c in game.Creatures)
                {
                    c.Query(this, q);
                }
                return q.Value;
            }
        }

        public override void Query(object source, StatQuery sq)
        {
            if (ReferenceEquals(source, this))
            {
                switch (sq.Statistic)
                {
                    case Statistic.Attack:
                        sq.Value += baseAttack;
                        break;
                    case Statistic.Defense:
                        sq.Value += baseDefense;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                if (sq.Statistic == Statistic.Defense)
                {
                    sq.Value++;
                }
            }
        }

        public override string ToString()
        {
            return $"Attach = {Attack}, Defense = {Defense}";
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game, 3, 3)
        {

        }

        public override void Query(object source, StatQuery sq)
        {
            if (!ReferenceEquals(source, this) && sq.Statistic == Statistic.Attack)
            {
                sq.Value++; // every goblin gets +1 attack
            }
            else base.Query(source, sq);
        }

        public override string ToString()
        {
            return $"Attach = {Attack}, Defense = {Defense}";
        }
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
    }
}
