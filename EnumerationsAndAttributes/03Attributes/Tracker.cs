using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(m => m.AttributeType == typeof(SoftUniAttribute)))
            {
                object[] attributes = methodInfo.GetCustomAttributes(false);
                foreach (SoftUniAttribute attr in attributes)
                {
                    Console.WriteLine($"{methodInfo.Name} is writen by {attr.Name}");
                }
            }
        }
    }
}

