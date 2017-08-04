namespace _02HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            Type classType = typeof(RichSoilLand);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

            Dictionary<string, Func<FieldInfo[]>> fieldsFilters = new Dictionary<string, Func<FieldInfo[]>>()
            {
                {"private", () => classFields.Where(f => f.IsPrivate).ToArray() },
                {"protected", () => classFields.Where(f => f.IsFamily).ToArray() },
                {"public", () => classFields.Where(f => f.IsPublic).ToArray() },
                {"all", () => classFields }
            };
            FieldInfo[] filteredFields;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                filteredFields = fieldsFilters[command]();

                string[] result = filteredFields
                    .Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}")
                    .ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
            }
        }
    }
}
