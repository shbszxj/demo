using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

namespace DesignPattern.Creation.Prototype.DeepCopy
{
    public class DeepCopyThroughSerialization : IDesignPatternDemo
    {
        public string Title => "4.3";

        public string Description => "Prototype - Deep Copy Through Serialization";

        public void Run()
        {
            Foo foo = new Foo { Stuff = 42, Whatever = "abc" };
            var foo2 = foo.DeepCopyXml();
            foo2.Whatever = "xyz";
            WriteLine(foo);
            WriteLine(foo2);
        }
    }

    public class Foo
    {
        public int Stuff;
        public string Whatever;

        public override string ToString()
        {
            return $"{nameof(Stuff)}: {Stuff}, {nameof(Whatever)}: {Whatever}";
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }
}