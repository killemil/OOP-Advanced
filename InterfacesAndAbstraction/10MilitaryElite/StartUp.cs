namespace _10MilitaryElite
{
    using _10MilitaryElite.Intefaces;
    using _10MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static IList<ISoldier> army;

        public static void Main()
        {
            army = new List<ISoldier>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] tokens = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                tokens = tokens.Skip(1).ToArray();

                if (command == "Private")
                {
                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    double salary = double.Parse(tokens[3]);

                    army.Add(new Private(id, firstName, lastName, salary));

                }
                else if (command == "LeutenantGeneral")
                {
                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    double salary = double.Parse(tokens[3]);
                    IList<ISoldier> privates = ExtractPrivate(tokens.Skip(4).ToList());

                    army.Add(new LeutenantGeneral(id, firstName, lastName, salary, privates));
                }
                else if (command == "Engineer")
                {
                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    double salary = double.Parse(tokens[3]);

                    if (tokens[4] != "Airforces" && tokens[4] != "Marines")
                    {
                        continue;
                    }

                    IList<IRepair> parts = ExtractParts(tokens.Skip(5).ToList());
                    army.Add(new Engineer(id, firstName, lastName, salary,tokens[4], parts));
                }
                else if (command == "Commando")
                {
                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    double salary = double.Parse(tokens[3]);

                    if (tokens[4] != "Airforces" && tokens[4] != "Marines")
                    {
                        continue;
                    }

                    IList<IMission> missions = ExtractMisions(tokens.Skip(5).ToList());
                    army.Add(new Commando(id, firstName, lastName, salary, tokens[4], missions));
                }
                else if (command == "Spy")
                {
                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    int codeNumber = int.Parse(tokens[3]);

                    army.Add(new Spy(id, firstName, lastName, codeNumber));
                }
            }

            foreach (var soldier in army)
            {
                Console.WriteLine(soldier);
            }
        }

        private static IList<IMission> ExtractMisions(IList<string> list)
        {
            IList<IMission> missions = new List<IMission>();

            for (int i = 0; i < list.Count - 1; i += 2)
            {
                if (list[i + 1] != "inProgress" && list[i + 1] != "Finished")
                {
                    continue;
                }
                missions.Add(new Mission(list[i], list[i + 1]));
            }

            return missions;
        }

        private static IList<IRepair> ExtractParts(IList<string> list)
        {
            IList<IRepair> parts = new List<IRepair>();

            for (int i = 0; i < list.Count - 1; i += 2)
            {
                //VALIDATION
                parts.Add(new Repair(list[i], int.Parse(list[i + 1])));
            }

            return parts;
        }

        private static IList<ISoldier> ExtractPrivate(IList<string> list)
        {
            var result = new List<ISoldier>();

            foreach (var soldier in list)
            {
                result.Add(army.First(s => s.Id == int.Parse(soldier)));
            }

            return result;
        }
    }
}
