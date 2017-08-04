namespace _03BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInt);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo field = classFields.First();

            ConstructorInfo[] nonPublicCtors = classType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            ConstructorInfo currentCtor = nonPublicCtors.First();
            BlackBoxInt testBlackBox = (BlackBoxInt)currentCtor.Invoke(new object[] { });

            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('_');
                object[] parameters = new object[] { int.Parse(tokens[1]) };
                string methodName = tokens[0];

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(testBlackBox, parameters);
                Console.WriteLine(field.GetValue(testBlackBox));
            }
        }
    }
}
