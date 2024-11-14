

using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
public class Program

{

    static void Main(string[] args)
    {

        // the ourAnimals array will store the following: 
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";

        // variables that support data entry
        int maxPets = 6;
        string? readResult;
        string menuSelection = "";
        int petCount = 0;

        // array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, 6];


        // TODO: Convert the if-elseif-else construct to a switch statement

        // create some initial ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {

            switch (i)
            {
                case 0:
                    {
                        animalSpecies = "dog";
                        animalID = "d1";
                        animalAge = "2";
                        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                        animalPersonalityDescription = "";
                        animalNickname = "Thor";
                        break;
                    }
                case 1:
                    {
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "Loki";
                        break;
                    }
                case 2:
                    {
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                        animalNickname = "";
                        break;
                    }
                case 3:
                    {
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "?";
                        animalPhysicalDescription = "small black and white male weighing 9 pounds .litter box trained";
                        animalPersonalityDescription = "little bit lazy , but freindly and No harm to kids";
                        animalNickname = "Tony";
                        break;
                    }

                default:
                    {
                        animalSpecies = "";
                        animalID = "";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        break;
                    }
            }
            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
        }





        // display the top-level menu options

        

        Console.WriteLine("Welcome to the Contoso PetFriends app. \nYour main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
        Console.WriteLine(" 5. Edit an animal’s age");
        Console.WriteLine(" 6. Edit an animal’s personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");



        do
        {
            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();

                switch (menuSelection)
                {
                    case "1":
                        {
                            int noOfPets = 0; // Initialize a counter
                            Console.WriteLine("List of all our current pet information:");

                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != null && ourAnimals[i, 0] != "ID #: ")
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    noOfPets++; // Increment for each valid pet
                                    Console.WriteLine("\n");
                                }
                            }

                            Console.WriteLine($"There are currently {noOfPets} pets in our application.");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break; // Break to outer switch statement
                        }

                    case "2":
                        {
                            string anotherPet = "y";
                            petCount = 0; // Reset petCount if needed

                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != null && ourAnimals[i, 0] != "ID #: ")
                                {
                                    petCount++;
                                }
                            }

                            if (petCount < maxPets)
                            {
                                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.\n");
                            }

                            // Allow user to enter new pet info
                            while (anotherPet == "y" && petCount < maxPets)
                            {
                                petCount++; // Increment pet count for new entry
                                            // Check maxPet limit
                                if (petCount <= maxPets) // Allow for maxPets condition
                                {
                                    // Ask if user wants to enter another pet
                                    Console.WriteLine("Do you want to enter info for another pet (y/n)");

                                    do
                                    {
                                        readResult = Console.ReadLine();
                                        if (readResult != null)
                                        {
                                            anotherPet = readResult.ToLower();
                                        }
                                    } while (anotherPet != "y" && anotherPet != "n");

                                    // If the user doesn't want to add another pet, exit to outer switch
                                    if (anotherPet == "n")
                                    {
                                        break;  // Exits the inner loop, returns to outer switch
                                    }

                                    // Proceed to gather pet information
                                    bool validEntry = false;
                                    //string animalSpecies = "";

                                    // Get species (dog or cat)
                                    do
                                    {
                                        Console.WriteLine("\nEnter 'dog' or 'cat' to begin a new entry");
                                        readResult = Console.ReadLine();
                                        if (readResult != null)
                                        {
                                            animalSpecies = readResult.ToLower();
                                            validEntry = (animalSpecies == "dog" || animalSpecies == "cat");
                                        }
                                    } while (!validEntry);

                                    // Build the animal ID (e.g., C1, C2, D1)
                                    animalID = animalSpecies.Substring(0, 1) + petCount.ToString();

                                    // Get pet's age
                                    //string animalAge = "";
                                    validEntry = false;
                                    do
                                    {
                                        Console.WriteLine("Enter the pet's age or enter ? if unknown");
                                        readResult = Console.ReadLine();
                                        if (readResult != null)
                                        {
                                            animalAge = readResult;
                                            validEntry = (animalAge == "?" || int.TryParse(animalAge, out _));
                                        }
                                    } while (!validEntry);

                                    // Get physical description
                                    //string animalPhysicalDescription = "";
                                    do
                                    {
                                        Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                                        readResult = Console.ReadLine();
                                        if (readResult != null)
                                        {
                                            animalPhysicalDescription = readResult.ToLower();
                                            if (string.IsNullOrWhiteSpace(animalPhysicalDescription))
                                            {
                                                animalPhysicalDescription = "tbd";
                                            }
                                        }
                                    } while (string.IsNullOrWhiteSpace(animalPhysicalDescription));

                                    // Get personality description
                                    //string animalPersonalityDescription = "";
                                    do
                                    {
                                        Console.WriteLine("Enter a personality of the pet please.");
                                        readResult = Console.ReadLine();
                                        if (readResult != null)
                                        {
                                            animalPersonalityDescription = readResult.ToLower();
                                            if (string.IsNullOrWhiteSpace(animalPersonalityDescription))
                                            {
                                                animalPersonalityDescription = "tbd";
                                            }
                                        }
                                    } while (string.IsNullOrWhiteSpace(animalPersonalityDescription));

                                    // Get the pet's nickname
                                    //string animalNickname = "";
                                    do
                                    {
                                        Console.WriteLine("Enter a nickname for the pet");
                                        readResult = Console.ReadLine();
                                        if (readResult != null)
                                        {
                                            animalNickname = readResult.ToLower();
                                            if (string.IsNullOrWhiteSpace(animalNickname))
                                            {
                                                animalNickname = "tbd";
                                            }
                                        }
                                    } while (string.IsNullOrWhiteSpace(animalNickname));

                                    // Store the pet information in the ourAnimals array (zero based)
                                    ourAnimals[petCount - 1, 0] = "ID #: " + animalID; // Use petCount - 1 for zero-based index
                                    ourAnimals[petCount - 1, 1] = "Species: " + animalSpecies;
                                    ourAnimals[petCount - 1, 2] = "Age: " + animalAge;
                                    ourAnimals[petCount - 1, 3] = "Nickname: " + animalNickname;
                                    ourAnimals[petCount - 1, 4] = "Physical description: " + animalPhysicalDescription;
                                    ourAnimals[petCount - 1, 5] = "Personality: " + animalPersonalityDescription;
                                }
                                else
                                {
                                    Console.WriteLine("We have reached the maximum limit of pets...");
                                    break; // Exit the loop if the max limit is reached
                                }
                                
                            }
                            foreach (string item in ourAnimals)
                            {
                                Console.WriteLine(item);
                               
                            }
                            System.Console.WriteLine(" ");
                            // Pause for input before returning to the menu
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break; // Break to the outer switch statement
                        }

                    case "3":
                        {

                            // ensure animal ages and physicalDescrpitions are complete..
                            bool validEntry = false; 
                           
                            do
                            {
                                    
                                    System.Console.WriteLine("These are the pet id whose either age or phisical discription is unknown");
                                   
                                        for (int i= 0 ; i< maxPets ;i++)
                                        {
                                            if (ourAnimals[i,0] != null && ourAnimals[i,0] != "ID #: ")
                                            { 
                                                if (ourAnimals[i,2].Contains("?")|| ourAnimals[i ,2] == "Age: ")
                                                {
                                                    System.Console.WriteLine(ourAnimals[i,0]);
                                                    System.Console.WriteLine("");
                                                    int IndexOfC2 = ourAnimals[i,3].IndexOf("T") ;
                                                    System.Console.WriteLine($"The Age of {ourAnimals[i,3].Substring(IndexOfC2 ,4)} needs to updated. ");
                                                     bool isvalid = true;
                                                   do{
                                                    System.Console.Write("please enter the Age : ");
                                                    bool convertedAge = int.TryParse(Console.ReadLine() , out int Age);
                                                    System.Console.WriteLine(Age);
                                                    if (convertedAge == false)
                                                    {
                                                       isvalid = false;
                                                    }
                                                    else 
                                                    {
                                                        ourAnimals[i,2] = "Age :" + Age;
                                                        break;
                                                    }
                                                    
                                                   }while(!isvalid);
                                                    
                                                }
                                                else if (ourAnimals[i ,4] == "Physical description: ")
                                                {
                                                    System.Console.WriteLine(ourAnimals[i , 0]);
                                                    System.Console.WriteLine(" ");
                                                    int indexofD4 = ourAnimals[i,3].IndexOf("L");
                                                    
                                                    System.Console.WriteLine($"The physicalDiscrption of {ourAnimals[i,3].Substring(indexofD4 ,4)} needs to be updated.");
                                                    System.Console.Write("Enter the physical descrption : ");
                                                        string? description = Console.ReadLine();
                                                        ourAnimals[i , 4] = "Physical description: " + description;
     
                                                }
                                               
                                            }
                                          
                                        }   
                                   
                                    
                                   
                                break;
                                
                            } while (validEntry == false);
                             
                             System.Console.WriteLine("\n");
                              for (int i = 0; i < maxPets; i++)
                                    {
                                        if (ourAnimals[i, 0] != null && ourAnimals[i, 0] != "ID #: ")
                                        {
                                            for (int j = 0; j < 6; j++)
                                            {
                                                Console.WriteLine(ourAnimals[i, j]);
                                            }
                                            
                                            Console.WriteLine("\n");
                                        }
                                    }
                          
                            System.Console.WriteLine(" ");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break;
                        }
                
                    case "4":
                        {

                            // ensure animal nickname and PersonalityDescrption are complete..
                            bool validEntry = false; 
                           
                            do
                            {
                                    
                                    System.Console.WriteLine("These are the pet id whose either nickname and personality descrption are incomplete.");
                                   
                                        for (int i= 0 ; i< maxPets ;i++)
                                        {
                                            if (ourAnimals[i,0] != null && ourAnimals[i,0] != "ID #: ")
                                            { 
                                                if ( ourAnimals[i ,3] == "Nickname: ")
                                                {
                                                    System.Console.WriteLine(ourAnimals[i,0]);
                                                    System.Console.WriteLine("");
                                                    
                                                    System.Console.WriteLine($"The nickName of {ourAnimals[i,0]} needs to updated. ");
                                                     bool isvalid = false;
                                                   while(isvalid == false)
                                                   {
                                                    System.Console.Write("please enter the NickName : ");
                                                     string? nickName = Console.ReadLine();
                                                     if (nickName == "")
                                                       nickName = null;
                                                     if (nickName != null)
                                                     {
                                                        ourAnimals[i , 3] = "Nickname: " + nickName;
                                                        isvalid = true;
                                                     }else
                                                     {isvalid = false;}
                                                   }
                                                    
                                                }
                                                else if (ourAnimals[i ,5] == "Personality: ")
                                                {
                                                    System.Console.WriteLine(ourAnimals[i , 0]);
                                                    System.Console.WriteLine(" ");
                                                   
                                                    System.Console.WriteLine($"The Personality of {ourAnimals[i,0]} needs to be updated.");

                                                    bool isvalid = false;
                                                    while (isvalid == false)
                                                    {
                                                    System.Console.Write("Enter the Personality description : ");
                                                     string? description = Console.ReadLine();
                                                     if (description == "")
                                                     description = null;
                                                     if(description != null)
                                                     {
                                                        ourAnimals[i , 5] = "Personality: " + description;
                                                        isvalid = true;
                                                     }else
                                                     {
                                                     isvalid = false;
                                                     }
                                                   }
                                                }
                                               
                                            }
                                          
                                        }   
                                   
                                    
                                   
                                break;
                                
                            } while (validEntry == false);
                             
                             System.Console.WriteLine("\n");
                              for (int i = 0; i < maxPets; i++)
                                    {
                                        if (ourAnimals[i, 0] != null && ourAnimals[i, 0] != "ID #: ")
                                        {
                                            for (int j = 0; j < 6; j++)
                                            {
                                                Console.WriteLine(ourAnimals[i, j]);
                                            }
                                            
                                            Console.WriteLine("\n");
                                        }
                                    }
                          
                            System.Console.WriteLine(" ");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break;
                        }
                    case "5":
                        {

                            Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break;

                        }
                    case "6":
                        {
                            Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break;

                        }
                    case "7":
                        {
                            Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                            Console.WriteLine("Press the Enter key to continue.");
                            readResult = Console.ReadLine();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("please enter any options from the menu : ");
                            readResult = Console.ReadLine();
                            break;
                        }

                }

            } while (readResult == "exit");



            // pause code execution
            readResult = Console.ReadLine();

            Console.ReadLine();


        }while (readResult == "exit");
    } 
}



