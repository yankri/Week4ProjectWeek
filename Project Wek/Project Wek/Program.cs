using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace Project_Wek
{
    class Program
    {
        public static bool Restart(int userInput)
        {
            if (userInput == 7)
            {
                return true;
            }

            return false;
        }

        public static bool Quit(int userInput)
        {
            if (userInput == 6)
            {
                return true;
            }

            return false;
        }

        public static bool AdminQuit(string userInput)
        {
            if (userInput == "F")
            {
                return true;
            }

            return false;
        }

        public static bool AdminRestart(string userInput)
        {
            if (userInput == "G")
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n\nWelcome to Bootcamp Resources Checkout System! \n\n\n\n");

            string password = "admin123";

            List<string> students = new List<string> { "Krista Scholdberg", "Ashley Stewart", "Cadale Thomas", "Lawrence Hudson", "Jennifer Evans", "Kimberly Vargas", "Jacob Lockyer", "Richard Raponi", "Imari Childress", "Mary Winkelman", "Cameron Robinson", "Margaret Landefield", "Quinn Bennett", "Sirahn CouldntFindHisLastName" };
            List<string> resources = new List<string> { "Visual C#", "C# Player's Guide", "Javascript for Kids", "HTML & CSS", "SQL Databases", "Git for Beginners", "Java for Dummies", "C# for Dummies", "Ruby on Rails", "Visual Studio for Beginners" };
            List<List<string>> checkedOutResources = new List<List<string>> (); //first index will be the index as a string of the person's name in students
            List<string> LCStudents = new List<string> ();
            List<string> LCResources = new List<string> ();

            for (int i = 0; i < students.Count; i++)
            {
                LCStudents.Add(students[i].ToLower());
            }

            for (int i = 0; i <resources.Count; i++)
            {
                LCResources.Add(resources[i].ToLower());
            }

            for (int i = 0; i < students.Count; i++)
            {
                checkedOutResources.Add(new List <string> ());
            }

            students.Sort();
            resources.Sort();
            LCResources.Sort();
            LCStudents.Sort();

            while(true)
            { 
                bool doubleContinue = false;
                bool doubleBreak = false;
                bool tripleContinue = false;

                bool result = false;
                int choice = 0;

                while (result == false)
                {
                    Console.WriteLine("Enter a number to select a menu option: \n");
                    Console.WriteLine("1 - View Students");
                    Console.WriteLine("2 - View Available Resources");
                    Console.WriteLine("3 - View Student Accounts");
                    Console.WriteLine("4 - Checkout Item");
                    Console.WriteLine("5 - Return Item");
                    Console.WriteLine("6 - Exit");
                    Console.WriteLine("7 - Start Over");
                    Console.WriteLine("8 - Admin Menu\n");

                    string menuChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    result = int.TryParse(menuChoice, out choice);
                   
                    if (Quit(choice))
                    {
                        Console.WriteLine("Quitting...\n");
                        doubleBreak = true;
                        break;
                    }

                    if (Restart(choice))
                    {
                        Console.WriteLine("Restarting...\n");
                        doubleContinue = true;
                        continue;
                    }

                    if (result == true)
                    {
                        break;
                    }
                }

                if (doubleBreak == true) //exits the program
                {
                    break;
                }
                if (doubleContinue == true) //restarts the program
                {
                    continue; 
                }

                

                switch (choice)
                {
                    case 1:
                        string resourceInput;
                        string resourcePosition;
                        string nameInput;
                        string namePosition;
                        Console.WriteLine("View the List of Current Students\n\n"); //print with correct capitalization
                        for (int i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine(students[i]);
                        }
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("Available Resources\n"); //print with correct capitalization

                        if (LCResources.Count == 0)
                        {
                            Console.WriteLine("All resources are checked out.");
                            break;
                        }
                        for (int i = 0; i < LCResources.Count; i++)
                        {
                            Console.WriteLine(LCResources[i]);
                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("View Student Accounts\n");
                        while (true)
                        {
                            Console.WriteLine("Enter a Name: \n");
                            nameInput = Console.ReadLine().ToLower();
                            Console.WriteLine();

                            if (!LCStudents.Contains(nameInput))
                            {
                                Console.WriteLine("ERROR: request unavailable");
                                continue;
                            }

                            namePosition = LCStudents.IndexOf(nameInput).ToString();

                            if (checkedOutResources[Convert.ToInt32(namePosition)].Count == 0)
                            {
                                Console.WriteLine("Nothing is checked out...\n");
                                break;
                            }

                            else
                            {
                                checkedOutResources[Convert.ToInt32(namePosition)].Sort();

                                for (int i = 0; i < checkedOutResources[Convert.ToInt32(namePosition)].Count; i++)
                                {
                                    Console.WriteLine(checkedOutResources[Convert.ToInt32(namePosition)][i]);
                                }
                                Console.WriteLine();
                                break;
                            }
                        }
                        break;

                    case 4:  //Item checkout
                        while (true)
                        {
                            Console.WriteLine("Checkout an Item\n");
                            Console.WriteLine("Enter a Name: \n");
                            nameInput = Console.ReadLine().ToLower();
                            namePosition = LCStudents.IndexOf(nameInput).ToString();

                            if (nameInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (nameInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (LCStudents.Contains(nameInput))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: Request Unavailable");
                            }
                        }

                        if (doubleContinue == true)
                        {
                            continue;
                        }

                        if (doubleBreak == true)
                        {
                            break;
                        }

                        while (true)
                        {
                            resources.Sort();

                            Console.WriteLine("Enter the name of the resource you want to checkout:\n");
                            resourceInput = Console.ReadLine().ToLower();
                            resourcePosition = LCResources.IndexOf(resourceInput).ToString();

                            if (resourceInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (resourceInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (!LCResources.Contains(resourceInput))
                            {
                                Console.WriteLine("That resource does not exist. Please try again. ");
                                continue;
                            }

                            if (checkedOutResources[Convert.ToInt32(namePosition)].Count == 3)
                            {
                                Console.WriteLine(nameInput + " has checked out the maximum number of resources.");
                                doubleContinue = true;
                                break;
                            }

                            if (!LCResources.Contains(resourceInput)) //checks to make sure the resource is available
                            {
                                Console.WriteLine("Error: Request Unavailable.\n");
                                continue;
                            }

                            if (LCResources.Contains(resourceInput)) //checks to make sure the resource is in resources List and then removes it from resources list to check it out
                            {
                                Console.WriteLine( nameInput + " has checked out " + resourceInput + ".");
                                LCResources.Remove(LCResources[Convert.ToInt32(resourcePosition)]);
                                LCResources.Sort();
                            }

                            checkedOutResources[Convert.ToInt32(namePosition)].Add(resourceInput); //adds the resource to the checked out resources

                            Console.WriteLine("Would you like to checkout another resource? Enter \"yes\" or \"no\".");

                            string moreCheckout = Console.ReadLine().ToLower();

                            if (moreCheckout == "no")
                            {
                                doubleContinue = true;
                                break;
                            }
                            if (moreCheckout == "yes")
                            {
                                continue;
                            }
                        }

                        if (doubleContinue == true)
                        {
                            continue;
                        }
                        break;

                    case 5:
                        Console.WriteLine("Return an Item\n");

                        while (true)
                        {
                            LCResources.Sort();

                            Console.WriteLine("Enter a name:");
                            nameInput = Console.ReadLine().ToLower();
                            namePosition = LCStudents.IndexOf(nameInput).ToString();
                            
                            if (nameInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (nameInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (!LCStudents.Contains(nameInput))
                            {
                                Console.WriteLine("That name does not exist. Please try again.");
                                continue;
                            }

                            Console.WriteLine("Enter the name of the resource you want to return: ");
                            resourceInput = Console.ReadLine().ToLower();

                            if (resourceInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (resourceInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (!checkedOutResources[Convert.ToInt32(namePosition)].Contains(resourceInput))
                            {
                                Console.WriteLine("Error: Request Unavailable");
                            }

                            if (checkedOutResources[Convert.ToInt32(namePosition)].Count == 0)
                            {
                                Console.WriteLine("You don't have any resources to return.");
                                doubleContinue = true;
                                break;
                            }
                            
                            if (!LCResources.Contains(resourceInput) && checkedOutResources[Convert.ToInt32(namePosition)].Contains(resourceInput))
                            {
                                LCResources.Add(resourceInput);
                                checkedOutResources[Convert.ToInt32(namePosition)].Remove(resourceInput);
                                Console.WriteLine(resourceInput + " has been returned.");
                                LCResources.Sort();
                            }

                            Console.WriteLine("Would you like to return another resource? Enter \"yes\" or \"no\".");

                            string moreReturn = Console.ReadLine().ToLower();

                            if (moreReturn == "no")
                            {
                                doubleContinue = true;
                                break;
                            }
                            if (moreReturn == "yes")
                            {
                                continue;
                            }
                        }
                        
                        if (doubleBreak == true)
                        {
                            break;
                        }
                        if (doubleContinue == true)
                        {
                            continue;
                        }

                        break;

                    case 6: //quit
                        Console.WriteLine("You want to quit");
                        doubleBreak = true;
                        break;

                    case 7: //restart
                        Console.WriteLine("You want to start over");
                        doubleContinue = true;
                        break;
                    
                    case 8: //admin menu
                        int counter = 0;
                        bool passwordEntered = false; 

                        while (true)
                        {
                            if (!passwordEntered) //makes you enter the password only once when entering the admin menu. needs to be entered each time you start the admin menu
                            {
                                Console.WriteLine("Please enter the administrator password: ");
                                string passwordInput = Console.ReadLine();

                                if (counter == 2)
                                {
                                    Console.WriteLine("You have entered the password wrong too many times. Restarting...");
                                    doubleContinue = true;
                                    break;
                                }

                                if (!passwordInput.Equals(password))
                                {
                                    Console.WriteLine("INVALID PASSWORD!!!");
                                    doubleContinue = true;
                                    counter++;
                                    continue;
                                }
                                else
                                {
                                    passwordEntered = true;
                                }
                            }

                            else
                            {
                                Console.WriteLine("Administrator Menu\n");
                                Console.WriteLine("Please choose an option: \n");

                                Console.WriteLine("A - Add a student");
                                Console.WriteLine("B - Add a resource");
                                Console.WriteLine("C - Delete a student");
                                Console.WriteLine("D - Delete a resource");
                                Console.WriteLine("E - Exit admin menu");
                                Console.WriteLine("F - Exit program");

                                string menuChoice = Console.ReadLine().ToUpper();
                                Console.WriteLine();

                                if (AdminQuit(menuChoice))
                                {
                                    Console.WriteLine("Quitting...\n");
                                    doubleBreak = true;
                                    break;
                                }

                                if (AdminRestart(menuChoice))
                                {
                                    Console.WriteLine("Restarting...\n");
                                    doubleContinue = true;
                                    continue;
                                }

                                switch (menuChoice)
                                {
                                    case "A": //add a student
                                        while (true)
                                        {
                                            Console.WriteLine("Add a student \n");
                                            Console.WriteLine("Enter the name of the student you wish to enter.");
                                            string newStudent = Console.ReadLine().ToLower();

                                            if (newStudent == "quit")
                                            {
                                                break;
                                            }

                                            if (newStudent == "restart")
                                            {
                                                continue;
                                            }

                                            LCStudents.Add(newStudent);
                                            LCStudents.Sort();

                                            Console.WriteLine("Would you like to enter another student? Enter \"yes\" or \"no\".");
                                            string addInput = Console.ReadLine().ToLower();

                                            if (addInput == "yes")
                                            {
                                                continue;
                                            }

                                            if (addInput == "no")
                                            {
                                                break;
                                            }
                                        }
                                        break;

                                    case "B": //add a resource
                                        Console.WriteLine("Add a resource\n");

                                        while (true)
                                        {
                                            Console.WriteLine("Enter the title you wish to enter: ");

                                            string newResource = Console.ReadLine().ToLower();

                                            if (newResource == "quit")
                                            {
                                                break;
                                            }

                                            if (newResource == "restart")
                                            {
                                                continue;
                                            }

                                            if (!LCResources.Contains(newResource))
                                            {
                                                LCResources.Add(newResource);
                                                Console.WriteLine(newResource + " has been added to the list.\n");
                                                LCResources.Sort();
                                            }
                                            else
                                            {
                                                Console.WriteLine("That resource is already in the list.");
                                                continue;
                                            }

                                            Console.WriteLine("Would you like to enter another resource? Type \"yes\" or \"no\".");

                                            string addInput = Console.ReadLine().ToLower();


                                            if (addInput == "yes")
                                            {
                                                continue;
                                            }

                                            if (addInput == "no")
                                            {
                                                break;
                                            }
                                        }
                                        break;

                                    case "C": //delete a student 
                                        while (true)
                                        {
                                            Console.WriteLine("Delete a Student\n");

                                            Console.WriteLine("Enter the name of the student you wish to delete: ");
                                            string deleteStudent = Console.ReadLine().ToLower();

                                            if (deleteStudent == "quit")
                                            {
                                                doubleBreak = true;
                                                break;
                                            }

                                            if (deleteStudent == "restart")
                                            {
                                                doubleContinue = true;
                                                continue;
                                            }

                                            if (LCStudents.Contains(deleteStudent))
                                            {
                                                LCStudents.Remove(deleteStudent);
                                                Console.WriteLine(deleteStudent + " has been removed.\n");
                                                LCStudents.Sort();
                                            }
                                            else
                                            {
                                                Console.WriteLine("ERROR: Request Unavailable. That student does not exist.");
                                                continue;
                                            }
                                            Console.WriteLine("Would you like to delete another student? Enter \"yes\" or \"no\".");
                                            string addInput = Console.ReadLine().ToLower();

                                            if (addInput == "yes")
                                            {
                                                continue;
                                            }

                                            if (addInput == "no")
                                            {
                                                break;
                                            }
                                        }

                                        if (doubleContinue == true)
                                        {
                                            continue;
                                        }

                                        if (doubleBreak == true)
                                        {
                                            break;
                                        }

                                        break;

                                    case "D": //delete a resource

                                        Console.WriteLine("Delete a Resource\n");

                                        while (true)
                                        {
                                            Console.WriteLine("Enter the name of the resource you wish to delete: ");
                                            string deleteResource = Console.ReadLine().ToLower();

                                            if (deleteResource == "quit")
                                            {
                                                doubleBreak = true;
                                                break;
                                            }

                                            if (deleteResource == "restart")
                                            {
                                                doubleContinue = true;
                                                continue;
                                            }

                                            if (LCResources.Contains(deleteResource))
                                            {
                                                LCResources.Remove(deleteResource);
                                                Console.WriteLine(deleteResource + " has been removed.\n");
                                                LCResources.Sort();
                                            }
                                            else
                                            {
                                                Console.WriteLine("ERROR: Request Unavailable. That resource does not exist.");
                                                continue;
                                            }
                                        }

                                        if (doubleContinue == true)
                                        {
                                            continue;
                                        }

                                        if (doubleBreak == true)
                                        {
                                            break;
                                        }

                                        break;

                                    case "E": // exit admin menu

                                        Console.WriteLine("Exiting admin menu...\n");
                                        doubleContinue = true;
                                        break;

                                    case "F": //exit program 

                                        Console.WriteLine("Exiting program...\n");
                                        doubleBreak = true;
                                        break;

                                    default: //restart admin menu
                                        Console.WriteLine("Restarting admin menu...\n");
                                        break;
                                }
                            }

                            if (doubleBreak == true)
                            {
                                break;
                            }
                            if (doubleContinue == true) 
                            {
                                break;
                            }
                            if (tripleContinue == true)
                            {
                                break;
                            }
                        }
                        
                        if (doubleContinue == true)
                        {
                            continue;
                        }
                        if (tripleContinue == true)
                        {
                            break;
                        }

                        break;
                    default: //default restarts since it wasn't a valid choice
                        Console.WriteLine("You didn't enter a valid menu choice. Restarting...");
                        doubleContinue = true;
                        break;
                }

                if (doubleBreak == true) //exits the program
                {
                    break;
                }
                if (doubleContinue == true) //restarts the program
                {
                    continue;
                }
                if (tripleContinue == true)
                {
                    continue;
                }

            }

            
        }
    }
}
