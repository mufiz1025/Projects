using System;
using System.Reflection.Emit;

public class Program
{
    static void Main(string[] args)
    {

        // #1 the ourAnimals array will store the following: 
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";
        string suggestedDonation = "";

        // #2 variables that support data entry
        int maxPets = 8;
        string? readResult;
        string menuSelection = "";
        decimal decimalDonation = 0.00m;

        // #3 array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, 7];

        // #4 create sample data ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    suggestedDonation = "85.00";
                    break;

                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "oscar";
                    suggestedDonation = "93.00";
                    break;

                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "snow";
                    suggestedDonation = "73.06";
                    break;

                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "3";
                    animalPhysicalDescription = "medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                    animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
                    animalNickname = "Lion";
                    suggestedDonation = "89.90";
                    break;

                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    suggestedDonation = "";
                    break;

            }


            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "species :" + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;


            if (!decimal.TryParse(suggestedDonation, out decimalDonation))
            {
                decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
            }
            ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";

        }

        // #5 display the top-level menu options
        do
        {
            // NOTE: the Console.Clear method is throwing an exception in debug sessions
            Console.Clear();

            Console.WriteLine("Welcome to the Moroco PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            // use switch-case to process the selected menu option
            switch (menuSelection)
            {
                case "1":

                    // list all pet info
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 7; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }


                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "2":
                    {
                        // #1 Display all dogs with a multiple search characteristics
                        string dogCharacteristic = "";
                        string[] DogBehaviour = new string[5];

                        while (dogCharacteristic == "")
                        {
                            // #2 Prompt user for multiple comma-separated characteristics
                            Console.WriteLine("\r\nEnter multiple terms separated by comma to search for a desired dog characteristic:");
                            readResult = Console.ReadLine().ToLower().Trim();
                            if (!string.IsNullOrEmpty(readResult))
                            {
                                dogCharacteristic = readResult;
                                DogBehaviour = dogCharacteristic.Split(',').Select(d => d.Trim()).ToArray(); // Trim spaces during split
                                Console.WriteLine();
                            }
                        }

                        // Sort the characteristics in alphabetical order
                        Array.Sort(DogBehaviour);

                        foreach (string db in DogBehaviour)
                        {
                            Console.WriteLine(db);
                        }


                        bool found = true;
                        Console.WriteLine(DogBehaviour.Length);

                        // #4 "Rotating" animation setup
                        string[] searchingIcons = { "|", "/", "--", "*" };

                        // Loop through ourAnimals array to search for matching animals
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 1].Contains("dog"))
                            {
                                  // Reset for each dog
                                //Console.WriteLine($"This is for {ourAnimals[i, 3]}");

                                foreach (string icon in searchingIcons)
                                {
                                    Console.Write($"\rSearching our dog {ourAnimals[i, 3]}.. {icon}");
                                    Thread.Sleep(250);
                                }

                                for (int k = 0; k < DogBehaviour.Length; k++)
                                {
                                    if (ourAnimals[i, 4].Contains(DogBehaviour[k]) || ourAnimals[i, 5].Contains(DogBehaviour[k]))
                                    {
                                        
                                        Console.WriteLine($"The search for term '{DogBehaviour[k]}' is a match with dog '{ourAnimals[i, 3]}'");
                                        found = true;
                                    }
                                    else { found = false; }
                                    
                                }
                                foreach (string b in DogBehaviour)
                                    if (found == false)
                                    {
                                        Console.WriteLine($"There were no matches found for the {b} characteristics in {ourAnimals[i, 3]}.");
                                    }

                            }
                           
                        }

                        Console.ReadLine();

                        Console.WriteLine("\n\rPress the Enter key to continue");
                        readResult = Console.ReadLine();
                        break;
                    }


                default:
                    break;
            }

        } while (menuSelection != "exit");

        Console.ReadLine();


    }

}
