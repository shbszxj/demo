using System;
using System.Reflection;

namespace TDD.Test.Infrastructure
{
    public class RepositoryHelper
    {
        public static void SetFieldWhenReconstitutingFromPersistence(object instance, string fieldName, object newValue)
        {
            Type type = instance.GetType();
            FieldInfo f = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            f.SetValue(instance, newValue);
        }
    }
}
