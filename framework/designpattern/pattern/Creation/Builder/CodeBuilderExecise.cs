using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPattern.Creation.Builder.Execise
{
    public class CodeBuilderExecise : IDesignPatternDemo
    {
        public string Title => "2.4";

        public string Description => "Builder Coding Execise";

        public void Run()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            WriteLine(cb);
        }
    }

    public class CodeBuilder
    {
        private string _className;

        private List<(string, string)> _parameters = new List<(string, string)>();

        public CodeBuilder(string className)
        {
            _className = className;
        }

        public CodeBuilder AddField(string paramName, string paramType)
        {
            _parameters.Add((paramName, paramType));
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {_className}");
            sb.AppendLine("{");
            foreach (var parameter in _parameters)
            {
                sb.AppendLine($"  public {parameter.Item2} {parameter.Item1};");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}