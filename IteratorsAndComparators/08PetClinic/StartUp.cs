namespace _08PetClinic
{
    using _08PetClinic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, Pet> allPets = new Dictionary<string, Pet>();
        private static Dictionary<string, Clinic> allClinics = new Dictionary<string, Clinic>();

        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> commandTokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = commandTokens[0];
                commandTokens.RemoveAt(0);
                switch (command)
                {
                    case "Create":
                        CreateEntity(commandTokens);
                        break;
                    case "Add":
                        AddPetToClinic(commandTokens);
                        break;
                    case "Release":
                        ReleasePetFromClinic(commandTokens);
                        break;
                    case "HasEmptyRooms":
                        CheckForEmptyRooms(commandTokens);
                        break;
                    case "Print":
                        PrintClinicInfor(commandTokens);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintClinicInfor(List<string> commandTokens)
        {
            string clinicName = commandTokens[0];
            Clinic currentClinic = allClinics[clinicName];
            string result = null;
            if (commandTokens.Count == 1)
            {
                result = currentClinic.Print();
            }
            else
            {
                int roomIndex = int.Parse(commandTokens[1]) - 1;
                result = currentClinic.Print(roomIndex);
            }

            Console.WriteLine(result);
        }

        private static void CheckForEmptyRooms(List<string> commandTokens)
        {
            string clinicName = commandTokens[0];
            Clinic currentClinic = allClinics[clinicName];

            Console.WriteLine(currentClinic.HasEmptyRooms());
        }

        private static void ReleasePetFromClinic(List<string> commandTokens)
        {
            string clinicName = commandTokens[0];
            Clinic currentClinic = allClinics[clinicName];

            Console.WriteLine(currentClinic.TryReleasePet());
        }

        private static void AddPetToClinic(List<string> commandTokens)
        {
            string petName = commandTokens[0];
            string clinicName = commandTokens[1];

            Pet currentPet = allPets[petName];
            Clinic currentClinic = allClinics[clinicName];

            if (currentClinic.TryAddPet(currentPet))
            {
                Console.WriteLine(true);
                allPets.Remove(petName);
                return;
            }

            Console.WriteLine(false);
        }

        private static void CreateEntity(List<string> commandTokens)
        {
            string entityType = commandTokens[0];
            if (entityType == "Pet")
            {
                string name = commandTokens[1];
                int age = int.Parse(commandTokens[2]);
                string kind = commandTokens[3];
                allPets.Add(name, new Pet(name, age, kind));
            }
            else if (entityType == "Clinic")
            {
                string name = commandTokens[1];
                int rooms = int.Parse(commandTokens[2]);
                try
                {
                    allClinics.Add(name, new Clinic(name, rooms));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
